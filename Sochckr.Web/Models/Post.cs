using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Sochckr.Web.Models
{
    public abstract class Post
    {
        [DisplayName("Post ID")]
        public int Id { get; set; }
        public int Score { get; set; }
        public virtual ICollection<BrokenLink> BrokenLinks { get; set; }

    }
}