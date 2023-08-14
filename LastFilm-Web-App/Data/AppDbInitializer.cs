using LastFilm_Web_App.Data.Enums;
using LastFilm_Web_App.Data.Static;
using LastFilm_Web_App.Models;
using Microsoft.AspNetCore.Identity;

namespace LastFilm_Web_App.Data;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder builder)
    {
        using var serviceScope = builder.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
        context!.Database.EnsureCreated();

        #region Cinema

        if (!context.Cinemas.Any())
        {
            context.Cinemas.AddRange(new List<Cinema>()
            {
                new Cinema()
                {
                    Name = "Cinema 1",
                    Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                    Description = "This is the description of the first cinema"
                },
                new Cinema()
                {
                    Name = "Cinema 2",
                    Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                    Description = "This is the description of the first cinema"
                },
                new Cinema()
                {
                    Name = "Cinema 3",
                    Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                    Description = "This is the description of the first cinema"
                },
                new Cinema()
                {
                    Name = "Cinema 4",
                    Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                    Description = "This is the description of the first cinema"
                },
                new Cinema()
                {
                    Name = "Cinema 5",
                    Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                    Description = "This is the description of the first cinema"
                },
            });

            context.SaveChanges();
        }

        #endregion

        #region Actors

        if (!context.Actors.Any())
        {
            context.Actors.AddRange(new List<Actor>()
            {
                new Actor()
                {
                    FullName = "Actor 1",
                    Bio = "This is the Bio of the first actor",
                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                },
                new Actor()
                {
                    FullName = "Actor 2",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                },
                new Actor()
                {
                    FullName = "Actor 3",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                },
                new Actor()
                {
                    FullName = "Actor 4",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                },
                new Actor()
                {
                    FullName = "Actor 5",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                }
            });

            context.SaveChanges();
        }

        #endregion

        #region Producers

        if (!context.Producers.Any())
        {
            context.Producers.AddRange(new List<Producer>()
            {
                new Producer()
                {
                    FullName = "Producer 1",
                    Bio = "This is the Bio of the first actor",
                    ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                },
                new Producer()
                {
                    FullName = "Producer 2",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                },
                new Producer()
                {
                    FullName = "Producer 3",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                },
                new Producer()
                {
                    FullName = "Producer 4",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                },
                new Producer()
                {
                    FullName = "Producer 5",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                }
            });

            context.SaveChanges();
        }

        #endregion

        #region Movies

        if (!context.Movies.Any())
        {
            context.Movies.AddRange(new List<Movie>()
            {
                new Movie()
                {
                    Name = "Life",
                    Description = "This is the Life movie description",
                    Price = 39.50,
                    ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = DateTime.Now.AddDays(10),
                    CinemaId = 3,
                    ProducerId = 3,
                    MovieCategory = MovieCategory.Documentary
                },
                new Movie()
                {
                    Name = "The Shawshank Redemption",
                    Description = "This is the Shawshank Redemption description",
                    Price = 29.50,
                    ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(3),
                    CinemaId = 1,
                    ProducerId = 1,
                    MovieCategory = MovieCategory.Action
                },
                new Movie()
                {
                    Name = "Ghost",
                    Description = "This is the Ghost movie description",
                    Price = 39.50,
                    ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    CinemaId = 4,
                    ProducerId = 4,
                    MovieCategory = MovieCategory.Horror
                },
                new Movie()
                {
                    Name = "Race",
                    Description = "This is the Race movie description",
                    Price = 39.50,
                    ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = DateTime.Now.AddDays(-5),
                    CinemaId = 1,
                    ProducerId = 2,
                    MovieCategory = MovieCategory.Documentary
                },
                new Movie()
                {
                    Name = "Scoob",
                    Description = "This is the Scoob movie description",
                    Price = 39.50,
                    ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = DateTime.Now.AddDays(-2),
                    CinemaId = 1,
                    ProducerId = 3,
                    MovieCategory = MovieCategory.Cartoon
                },
                new Movie()
                {
                    Name = "Cold Soles",
                    Description = "This is the Cold Soles movie description",
                    Price = 39.50,
                    ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                    StartDate = DateTime.Now.AddDays(3),
                    EndDate = DateTime.Now.AddDays(20),
                    CinemaId = 1,
                    ProducerId = 5,
                    MovieCategory = MovieCategory.Drama
                }
            });

            context.SaveChanges();
        }

        #endregion

        #region Actors-Movies

        if (!context.ActorsMovies.Any())
        {
            context.ActorsMovies.AddRange(new List<ActorMovie>()
            {
                new ActorMovie()
                {
                    ActorId = 1,
                    MovieId = 1
                },
                new ActorMovie()
                {
                    ActorId = 3,
                    MovieId = 1
                },

                new ActorMovie()
                {
                    ActorId = 1,
                        MovieId = 2
                },
                new ActorMovie()
                {
                    ActorId = 4,
                    MovieId = 2
                },

                new ActorMovie()
                {
                    ActorId = 1,
                    MovieId = 3
                },
                new ActorMovie()
                {
                    ActorId = 2,
                    MovieId = 3
                },
                new ActorMovie()
                {
                    ActorId = 5,
                    MovieId = 3
                },

                new ActorMovie()
                {
                    ActorId = 2,
                    MovieId = 4
                },
                new ActorMovie()
                {
                    ActorId = 3,
                    MovieId = 4
                },
                new ActorMovie()
                {
                    ActorId = 4,
                    MovieId = 4
                },

                new ActorMovie()
                {
                    ActorId = 2,
                    MovieId = 5
                },
                new ActorMovie()
                {
                    ActorId = 3,
                    MovieId = 5
                },
                new ActorMovie()
                {
                    ActorId = 4,
                    MovieId = 5
                },
                new ActorMovie()
                {
                    ActorId = 5,
                    MovieId = 5
                },

                new ActorMovie()
                {
                    ActorId = 3,
                    MovieId = 6
                },
                new ActorMovie()
                {
                    ActorId = 4,
                    MovieId = 6
                },
                new ActorMovie()
                {
                    ActorId = 5,
                    MovieId = 6
                },
            });

            context.SaveChanges();
        }

        #endregion
    }

    public static async Task SeedUsersAndRoles(IApplicationBuilder builder)
    {
        using var serviceScope = builder.ApplicationServices.CreateScope();
        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        await SeedRoleAsync(roleManager, UserRoles.Admin);
        await SeedRoleAsync(roleManager, UserRoles.User);

        await SeedUserAsync(
            userManager,
            "admin@lastfilm.com",
            "Admin User",
            "admin",
            "qwerty123!U",
            UserRoles.Admin);

        await SeedUserAsync(
            userManager,
            "user@lastfilm.com",
            "Application User",
            "appUser",
            "qwerty123@!U",
            UserRoles.User);
    }

    private static async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager, string role)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    private static async Task SeedUserAsync(
        UserManager<ApplicationUser> userManager,
        string email,
        string fullName,
        string userName,
        string password,
        string role)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            var newUser = new ApplicationUser()
            {
                FullName = fullName,
                UserName = userName,
                Email = email,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(newUser, password);
            await userManager.AddToRoleAsync(newUser, role);
        }
    }
}
