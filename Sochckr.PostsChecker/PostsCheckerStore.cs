using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sochckr.PostsChecker
{
    public interface IPostsCheckerStore
    {
        PostsCheckerJob GetJob(int jobId);
        int AddJob(PostsCheckerJob job);
        void SaveJob(PostsCheckerJob job);
        void AddQuestion(Question question);
        Question GetQuestion(int questionId);
    }

    public class PostsCheckerStore : IPostsCheckerStore
    {
        private static readonly Dictionary<int, PostsCheckerJob> jobsDb = new Dictionary<int, PostsCheckerJob>();
        private static readonly Dictionary<int, Question> questionsDb = new Dictionary<int, Question>();

        public PostsCheckerJob GetJob(int jobId)
        {
            return jobsDb[jobId];
        }

        public int AddJob(PostsCheckerJob job)
        {
            int nextId = jobsDb.Keys.Count + 1;
            jobsDb[nextId] = job;
            return nextId;
        }

        public void SaveJob(PostsCheckerJob job)
        {
            jobsDb[job.Id] = job;
        }

        public void AddQuestion(Question question)
        {
            questionsDb[question.Id] = question;
        }

        public Question GetQuestion(int questionId)
        {
            return questionsDb[questionId];
        }

    }
}
