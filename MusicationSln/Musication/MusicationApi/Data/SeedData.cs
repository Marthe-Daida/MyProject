using MusicationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicationApi.Data
   {
    public class SeedData
    {
        public static void Initialize(MusicationApiContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new Models.User
                    {
                        UserName = "Marthe",
                        Email = "@gmail.com",
                        Gender = "Female",
                        Password = "123",

                    }
                );
                context.SaveChanges();
            }
        }
    }
}