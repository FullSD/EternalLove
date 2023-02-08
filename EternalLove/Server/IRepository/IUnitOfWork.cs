
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EternalLove.Shared.Domain;

namespace EternalLove.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<UserDetail> UserDetails { get; }
        IGenericRepository<Gender> Genders { get; }
        IGenericRepository<Match> Matchs { get; }
        IGenericRepository<Location> Locations { get; }
        IGenericRepository<Report> Reports { get; }
        IGenericRepository<Review> Reviews { get; }
    }
}