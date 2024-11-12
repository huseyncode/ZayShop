﻿using Microsoft.EntityFrameworkCore;
using ZayShop.Entities;

namespace ZayShop.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<StyleCategory> StyleCategories { get; set; }
}