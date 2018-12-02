using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;

namespace Sochckr.PostsChecker
{
    public class PostsCheckerModule : NancyModule
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public PostsCheckerModule(IPostsCheckerStore postsCheckerStore, IStackExchangeClient stackExchangeClient)
            : base("/posts")
        {
            Get("/check/{site:alpha}/{date:datetime}/{tags?}", parameters =>
            {
                var site = (string)parameters.site;
                var date = ((DateTime)parameters.date).ToUniversalTime(); //todo validate
                var tags = ((string)parameters.tags)?.Split(','); // todo validate

                return stackExchangeClient.GetPosts(site, date, tags).GetAwaiter().GetResult();
            });

            Get("/check/{site:alpha}/{date:int}/{tags?}", parameters =>
            {
                var site = (string)parameters.site;
                var date = DateTimeOffset.FromUnixTimeSeconds(parameters.date).DateTime;
                var tags = (string[])parameters.tags;

                return stackExchangeClient.GetPosts(site, date, tags).GetAwaiter().GetResult();
            });            
            
            Get("/status/{id:int}", parameters =>
            {
                var id = (int)parameters.id;
                return postsCheckerStore.GetJob(id);
            });

            Put("/start", parameters =>
            {
                // get params from request: site, tags, date

                // get sites, validate site
                // get startdate of site, validate date
                // get tags of site, validate tags
                
                var job = new PostsCheckerJob();

                // save details to database
                var jobId = postsCheckerStore.AddJob(job);

                // publish event to start job (or start checking on another thread)

                // return id
                return jobId;
            });

            Post("/stop/{id:int}", parameters =>
            {
                var id = (int)parameters.id;
                var job = postsCheckerStore.GetJob(id);

                // check job exists  

                job.StoppedAt = DateTime.UtcNow;

                // publish event to stop job (or stop job running another thread)

                postsCheckerStore.SaveJob(job);
                return null;
            });
        }
    }
}
