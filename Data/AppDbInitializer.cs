﻿using Downstream.Models;

namespace Downstream.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Ticket.Any())
                {
                    context.Ticket.AddRange(new List<Ticket>()
                    {
                        new Ticket()
                        {
                            Title = "Can't login to company email",
                            IssueType = "Locked Out",
                            TimeEntered = DateTime.Now,
                            RequiredResolutionTime = Convert.ToDateTime("12/11/2022")

                        },

                        new Ticket()
                        {
                            Title = "Need License for Photoshop",
                            IssueType = "Software Request",
                            TimeEntered = DateTime.Now,
                            RequiredResolutionTime = Convert.ToDateTime("12/28/2022")

                        }

                    });
                    context.SaveChanges();

                        

                }
            }
        }
    }
}