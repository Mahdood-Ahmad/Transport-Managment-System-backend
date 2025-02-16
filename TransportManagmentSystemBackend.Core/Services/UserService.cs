﻿using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportManagmentSystemBackend.Core.Domain.Models;
using TransportManagmentSystemBackend.Core.Interfaces.Repositories;

namespace TransportManagmentSystemBackend.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public UserService(IUserRepository repo)
        {
            this._repo = repo;
        }

        public async Task<UserResponse> AddUser(UserRequest request)
        {
            if (request == null)
            {
                Logger.Error("UserService.AddUser is called and getting null exception for add user");
                throw new ArgumentException(nameof(AddUser));
            }
            else
            {
                return await _repo.InsertUser(request);
            }
        }
    }
}
