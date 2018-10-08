using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sochckr.Web.Models;

//https://www.codeproject.com/Articles/832189/List-vs-IEnumerable-vs-IQueryable-vs-ICollection-v
namespace Sochckr.Web.Clients
{
    public interface IStackExchangeClient
    {
        IEnumerable<Site> GetSites();
        string GetFilter(string[] criteria);
        DateTime GetLaunchDate(string site);
        IEnumerable<Question> GetQuestions(string site, DateTime at);
    }

    public class StackExchangeClient : IStackExchangeClient
    {
        public IEnumerable<Site> GetSites()
        {
            throw new NotImplementedException();
        }

        public string GetFilter(string[] criteria)
        {
            throw new NotImplementedException();
        }

        public DateTime GetLaunchDate(string site)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetQuestions(string site, DateTime at)
        {
            throw new NotImplementedException();
        }
    }
}