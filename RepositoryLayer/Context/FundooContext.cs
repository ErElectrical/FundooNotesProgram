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
    /// Model of database table live here
    /// </summary>
    public class FundooContext : DbContext
    {
        public FundooContext(DbContextOptions options)
            : base(options)
        {
        }
        //table for user 
        public DbSet<UserEntity> User { get; set; }

        //table for notes
        public DbSet<Notesentity> Notes { get; set; }

        //table for collab
        public DbSet<CollabratorEntity> Collab { get; set; }

        //table for label
        public DbSet<LabelEntity> label { get; set; }
    }
}
