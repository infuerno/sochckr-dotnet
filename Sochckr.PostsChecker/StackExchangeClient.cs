using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.StacMan;

namespace Sochckr.PostsChecker
{
    public interface IStackExchangeClient
    {
        Task<Post[]> GetPosts(string site, DateTime date, string[] tags);
        bool IsSite(string site);
    }

    public class StackExchangeClient : IStackExchangeClient
    {
        private const string ApiVersion = "2.2";
        private const string Filter = "!-*jbN-o8P3E5";

        public async Task<Post[]> GetPosts(string site, DateTime date, string[] tags)
        {
            var client = new StacManClient(null, ApiVersion);
            //var filterResponse = await client.Filters.Create("question.body;answer.body;question.answers");
            var postsResponse = await client.Posts.GetAll(site, Filter, null, 100, date);
            return postsResponse.Data.Items;
        }

        public bool IsSite(string site)
        {
            throw new NotImplementedException();
        }
    }
}