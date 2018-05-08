using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sochckr.Web.Models
{
    public class Question : Post
    {
        public List<Answer> Answers { get; set; }
        public bool IsAnswered { get; set; }
        public string Title { get; set; }
    }
}