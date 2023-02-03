using EternalLove.Server.Data;
using EternalLove.Server.IRepository;
using EternalLove.Server.Models;
using EternalLove.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EternalLove.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<UserDetail> _UserDetails;
        private IGenericRepository<Gender> _Genders;
        private IGenericRepository<Match> _Matchs;
        private IGenericRepository<Location> _Locations;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<UserDetail> UserDetails
            => _UserDetails ??= new GenericRepository<UserDetail>(_context);
        public IGenericRepository<Gender> Genders
            => _Genders ??= new GenericRepository<Gender>(_context);

        public IGenericRepository<Match> Matchs
            => _Matchs ??= new GenericRepository<Match>(_context);

        public IGenericRepository<Location> Locations
            => _Locations ??= new GenericRepository<Location>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}