﻿using KernelLogic.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KernelLogic.DataBaseObjects
{
    public class IDentityContext : IdentityDbContext<IdentityUser>
    {
        public IDentityContext(DbContextOptions options): base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
