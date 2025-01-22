﻿using EclipseWorks.Core.Interfaces;
using EclipseWorks.Core.Models;

namespace EclipseWorks.Infrastructure.Repositories
{
    public class UserRepository(DbContextClass dbContext) : GenericRepository<UserModel>(dbContext), IUserRepository
    {
    }
}