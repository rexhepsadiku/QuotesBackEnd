using Microsoft.Extensions.Logging;
using Quotes.Domain.Constants.Identity;
using Quotes.Domain.Entities;
using Quotes.Domain.Entities.Identity;

namespace Quotes.Infrastructure.Persistence
{
    public class QuotesDbContextInitializer
    {
        public static async Task SeedAsync(QuotesDbContext db, ILogger<QuotesDbContextInitializer> logger)
        {
            if (!db.Users.Any() && !db.Roles.Any() && !db.UserRoles.Any() && !db.Images.Any())
            {
                db.Users.AddRange(GetPreconfiguredUsers());
                db.Roles.AddRange(GetPreconfiguredRoles());
                db.UserRoles.AddRange(GetPreconfiguredUserRoles());
                db.Images.AddRange(GetPreconfiguredImages());
                await db.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(QuotesDbContext).Name);
            }
        }

        private static IEnumerable<User> GetPreconfiguredUsers()
        {
            return new List<User>
            {
                new User()
                {
                   Id = new Guid("fbacdbdd-7ab5-468a-a21e-eb86233447d2"),
                   FirstName = "Rexhep",
                   LastName = "Sadiku",
                   UserName = "rexhep",
                   Email = "sadikurexhep@outlook.com",
                   PasswordHash = "AQAAAAEAACcQAAAAEECaLdsJubFYPfPWCUqe+T2LKQFNKgAmpUgyUGlNWpVp0nFrk1ybA9B5bvsvocwHBA==",
                   NormalizedEmail = "SADIKUREXHEP@OUTLOOK.COM",
                   NormalizedUserName = "REXHEP"
                }
            };
        }

        private static IEnumerable<Role> GetPreconfiguredRoles()
        {
            return new List<Role>
            {
                new Role()
                {
                    Id = new Guid("fab4fac1-c546-41de-aebc-a14da6895711"),
                    Name = RolesEnum.Administrator,
                    ConcurrencyStamp = "1",
                    NormalizedName = RolesEnum.Administrator.ToUpper()
                },
                new Role()
                {
                    Id = new Guid("fab4fac1-c546-41de-aebc-a14da6895713"),
                    Name = RolesEnum.User,
                    ConcurrencyStamp = "1",
                    NormalizedName = RolesEnum.User.ToUpper()
                }
            };
        }

        private static IEnumerable<UserRole> GetPreconfiguredUserRoles()
        {
            return new List<UserRole>
            {
                new UserRole()
                {
                    RoleId = new Guid("fab4fac1-c546-41de-aebc-a14da6895711"),
                    UserId = new Guid("fbacdbdd-7ab5-468a-a21e-eb86233447d2")
                }
            };
        }

        private static IEnumerable<Image> GetPreconfiguredImages()
        {
            return new List<Image>
            {
                new Image()
                {
                    Id = new Guid("95ed40b3-a70d-48bb-8845-7daa0a187768"),
                    Url = "https://i.imgur.com/jg2lbSQ.jpg"
                },
                new Image()
                {
                    Id = new Guid("e84f9280-289d-4765-ba43-5c496ebb8710"),
                    Url = "https://i.imgur.com/EQoqiKS.jpg"
                },
                new Image()
                {
                    Id = new Guid("5c24b555-83ad-4782-a2d9-c829d9954bbd"),
                    Url = "https://i.imgur.com/Mfw3kdm.jpg"
                },
                new Image()
                {
                    Id = new Guid("a6da7935-7b4e-4589-aae6-bb88114a161a"),
                    Url = "https://i.imgur.com/Ky2XcfS.jpg"
                },
                new Image()
                {
                    Id = new Guid("d7d948e8-9036-45f1-a4b7-770fca20ffdc"),
                    Url = "https://i.imgur.com/hrVqKjC.jpg"
                },
                new Image()
                {
                    Id = new Guid("df90c845-2022-4c0a-901e-a60bf30888c2"),
                    Url = "https://i.imgur.com/lSzAY4d.jpg"
                },
                new Image()
                {
                    Id = new Guid("62ce912b-944d-41dd-afcc-d9da17be1ed5"),
                    Url = "https://i.imgur.com/9alnoph.jpg"
                },
                new Image()
                {
                    Id = new Guid("35246410-5426-4010-b987-57e1a591967f"),
                    Url = "https://i.imgur.com/KSxNlQ2.jpg"
                },
                new Image()
                {
                    Id = new Guid("4472a19a-30d2-41e4-881f-807bb9137ef8"),
                    Url = "https://i.imgur.com/VOZqOdd.jpg"
                },
                new Image()
                {
                    Id = new Guid("e28267fc-f79b-46ff-bb77-859fe79b7607"),
                    Url = "https://i.imgur.com/Ay7z8kZ.jpg"
                },
            };
        }
    }
}
