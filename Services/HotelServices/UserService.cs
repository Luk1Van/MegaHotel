﻿using MegaHotel.DataBase;
using MegaHotel.Models.UserModels;
using MegaHotel.Services.IHotelServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace MegaHotel.Services.HotelServices
{
    public class UserService : IUserService
    {
        private readonly HotelDbContext _hotelDbContext;

        public UserService(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public async Task<string> AddUser(string email, string password)
        {
            User newUser = new User { Email = email, Password = password };
            await _hotelDbContext.AddAsync(newUser);
            await _hotelDbContext.SaveChangesAsync();
            return "New user added successfully";
        }

        public IEnumerable<User> CheckUser(string email, string password)
        {
            var user = from c in _hotelDbContext.Users
                       where c.Email == email   && c.Password == password
                       select c;
            return user;
        }

        public IEnumerable<User> CheckUserEmail(string email)
        {
            var user = from c in _hotelDbContext.Users
                       where c.Email == email
                       select c;
            return user;
        }
    }
}
