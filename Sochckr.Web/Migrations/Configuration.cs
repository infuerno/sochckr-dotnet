using System.Collections.Generic;
using System.Net;
using Sochckr.Web.Models;

namespace Sochckr.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sochckr.Web.Models.SochckrDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // set back to false once the database is mature
            ContextKey = "Sochckr.Web.Models.SochckrDbContext";
        }

        protected override void Seed(Sochckr.Web.Models.SochckrDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Questions.AddOrUpdate(q => q.Id, new Question()
            {
                Id = 1,
                Title = "How do I find some broken links?",
                IsAnswered = false,
                Score = 3,
                BrokenLinks = new List<BrokenLink>()
                {
                    new BrokenLink()
                    {
                        Id = 1,
                        Link = "http://www.bbc.co.uk",
                        StatusCode = 404,
                        Text = "My favourite site 1"
                    },
                    new BrokenLink()
                    {
                        Id = 2,
                        Link = "http://www.bbc.co.uk",
                        StatusCode = 404,
                        Text = "My favourite site 2",
                    },
                    new BrokenLink()
                    {
                        Id = 3,
                        Link = "http://www.bbc.co.uk",
                        StatusCode = 500,
                        Text = "My favourite site 3",
                    }
                }
            });

            context.Answers.AddOrUpdate(a => a.Id, new Answer()
            {
                Id = 2,
                Score = 4,
                Question = context.Questions.Find(1),
                QuestionId = 1,
                BrokenLinks = new List<BrokenLink>()
                {
                    new BrokenLink()
                    {
                        Id = 4,
                        Link = "http://www.bbc.co.uk",
                        StatusCode = 500,
                        Text = "My favourite site 4"
                    }
                }
            });

            var values = Enum.GetValues(typeof(HttpStatusCode));
            var r = new Random();

            for (int i = 3; i < 1000; i++)
            {
                context.Questions.AddOrUpdate(q => q.Id, new Question()
                {
                    Id = i,
                    Title = $"Question{i}",
                    Score = r.Next(0,10),
                    BrokenLinks = new List<BrokenLink>()
                    {
                        new BrokenLink()
                        {
                            Id = i + 2, // starts at 5
                            Link = $"http://brokenlink{i}",
                            StatusCode = (int)values.GetValue(r.Next(values.Length)),
                            Text = $"My favourite site . {i}"
                        }
                    }
                });
            }

            context.SaveChanges();

        }
    }
}
