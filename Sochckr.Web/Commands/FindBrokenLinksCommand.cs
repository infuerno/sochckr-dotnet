using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sochckr.Web.Clients;

namespace Sochckr.Web.Commands
{
    public interface IFindBrokenLinksCommand
    {
        void Execute();
    }

    public class FindBrokenLinksCommand : IFindBrokenLinksCommand
    {
        private IStackExchangeClient _stackExchangeClient;
        private string _site;
        private DateTime _minDateFrom;
        private DateTime _maxDateTo;

        public FindBrokenLinksCommand(string site, IStackExchangeClient client, DateTime? minDateFrom, DateTime? maxDateTo)
        {
            _stackExchangeClient = client;
            _site = site;

            _minDateFrom = minDateFrom ?? _stackExchangeClient.GetLaunchDate(_site);
            _maxDateTo = maxDateTo ?? DateTime.UtcNow;
        }

        public void Execute()
        {

        }



    }
}