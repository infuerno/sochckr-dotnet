using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sochckr.PostsChecker
{
    public class PostsCheckerJob
    {
        public int Id { get; set; }
        public string Site { get; set; }
        public string[] Tags { get; set; }
        public DateTime PostsPublishedFrom { get; set; }
        public DateTime PostsPublishedTo { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime StoppedAt { get; set; }

        public int NumberQuestionsChecked { get; set; }
        public int NumberAnswersChecked { get; set; }
        public int NumberBrokenLinks { get; set; }

        public PostsCheckerJob()
        {
            StartedAt = DateTime.UtcNow;
        }

        public PostsCheckerJob(string site, DateTime postsPublishedFrom, DateTime postsPublishedTo)
        : this()
        {
            Site = site;
            PostsPublishedFrom = postsPublishedFrom;
            PostsPublishedTo = postsPublishedTo;
        }
    }
}
