﻿using KernelLogic.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelLogic.DataBaseObjects
{
    public class IDentityContext : IdentityDbContext<IdentityUser>
    {
        private readonly UserManager<IdentityUser>? _userManager;
        public IDentityContext(DbContextOptions options): base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration())
        }
    }
}
