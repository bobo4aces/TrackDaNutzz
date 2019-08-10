using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Users;
using Xunit;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class UsersServiceTests
    {
        [Fact]
        public void TestGetCurrentlyLoggedUserId_WithInvalidUsername_ShouldThrowArgumentException()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);
            FakeSignInManager signInManager = new FakeSignInManager();
            UsersService usersService = new UsersService(context, signInManager);

            string username = "";

            Assert.Throws(typeof(ArgumentException), ()=> usersService.GetCurrentlyLoggedUserId(username));
        }

        
    }
}
