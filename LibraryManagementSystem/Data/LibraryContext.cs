﻿using LibraryManagementSystem.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<LibraryManagementSystem.Models.AdminModel> AdminModel { get; set; } = default!;
        public DbSet<LibraryManagementSystem.Models.UserModel> UserModel { get; set; } = default!;
    }
}
