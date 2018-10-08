using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sochckr.PostsChecker
{
    public class Question
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string Title { get; set; }
        public int CheckedAt { get; set; }
    }
}
