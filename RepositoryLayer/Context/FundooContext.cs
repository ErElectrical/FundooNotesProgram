using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using repositorylayer.entity;
using RepositoryLayer.Entity;


namespace RepositoryLayer.Context
{
    /// <summary>
    /// FundooContext is the class where connection with database occur 
    /// </summary>
    public class FundooContext : DbContext
    {
        public FundooContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<UserEntity> User { get; set; }

        public DbSet<Notesentity> Notes { get; set; }

        public DbSet<CollabratorEntity> Collab { get; set; }

        public DbSet<LabelEntity> label { get; set; }
    }
}
