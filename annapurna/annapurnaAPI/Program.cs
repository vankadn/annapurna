using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using annapurnaAPI.Context;
using System.Diagnostics;

namespace annapurnaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create an user instance and save the entity to the database
            using (var context = new UserContext())
            {
                // Create database
                context.Database.EnsureCreated();
                // Init sample data
                var user = new User { fname = "Ankan", lname = "Giri" };
                context.Add(user);
                context.SaveChanges();
            }

            BuildWebHost(args).Run();          
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();


    }
}
