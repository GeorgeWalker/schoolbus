﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using SchoolBusAPI.Services;
using Newtonsoft.Json;

namespace SchoolBusAPI.Services.Impl
{
    /// <summary>
    /// Implementation for the UserAPIService
    /// </summary>
    public class UserApiService : IUserApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public UserApiService(DbAppContext context)
        {
            _context = context;
        }
        public IActionResult UsersIdFavouritesGetAsync(int id)
        {
            var result = "";
            // Need to add this object to the model.
            // var result = _context.UserFavourites.All(a => a.User.Id == id);
            return new ObjectResult(result);
        }

        public IActionResult UsersIdGetAsync(int id)
        {
            var result = _context.Users.First(a => a.Id == id);
            return new ObjectResult(result);
        }

        public IActionResult UsersIdNotificationGetAsync(int id)
        {
            var result = _context.Notifications.All(a => a.User.Id == id);
            return new ObjectResult(result);
        }
    }
}