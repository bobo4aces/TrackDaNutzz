﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;

namespace TrackDaNutzz.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly TrackDaNutzzDbContext context;
        private readonly SignInManager<TrackDaNutzzUser> _signInManager;

        public UsersService(TrackDaNutzzDbContext context, SignInManager<TrackDaNutzzUser> signInManager)
        {
            this.context = context;
            this._signInManager = signInManager;
        }

        public string GetCurrentlyLoggedUserId(string username)
        {
            TrackDaNutzzUser trackDaNutzzUser = this.context.TrackDaNutzzUsers.SingleOrDefault(u => u.UserName == username);
            if (trackDaNutzzUser == null)
            {
                throw new ArgumentException($"Invalid username - {username}");
            }
            return trackDaNutzzUser.Id;
        }

        public string GetCurrentlyLoggedUsername()
        {
            return this._signInManager.Context.User.Identity.Name;
        }
    }
}
