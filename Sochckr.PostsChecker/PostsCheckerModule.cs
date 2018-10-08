using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;

namespace Sochckr.PostsChecker
{
    public class PostsCheckerModule : NancyModule
    {
        public PostsCheckerModule(IPostsCheckerStore postsCheckerStore)
            : base("/checkposts")
        {
            Get("/status/{id:int}", parameters =>
            {
                var id = (int)parameters.id;
                return postsCheckerStore.GetJob(id);
            });

            Put("/start", parameters =>
            {
                // get params from request: site, tags, startdate, enddate
                var job = new PostsCheckerJob();

                // validate site, get startdate of site
                // validate startdate

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
