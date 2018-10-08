using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Sochckr.Web.Models
{
    public class Answer : Post
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}