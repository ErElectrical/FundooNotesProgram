// <copyright file="FundooContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RepositoryLayer.Context
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using repositorylayer.entity;
    using RepositoryLayer.Entity;

    /// <summary>
    /// FundooContext is the class where connection with database occur.
    /// Model of database table live here.
    /// </summary>
    public class FundooContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FundooContext"/> class.
        /// </summary>
        /// <param name="options">
        /// parameter is of DbContextOptions class type.
        /// </param>
        public FundooContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or Sets User Table instance.
        /// </summary>
        public DbSet<UserEntity> User { get; set; }

        /// <summary>
        /// Gets or Sets Notes table  instance.
        /// </summary>
        public DbSet<Notesentity> Notes { get; set; }

        /// <summary>
        /// Gets or Sets Collabrator  Table instance.
        /// </summary>
        public DbSet<CollabratorEntity> Collab { get; set; }

        /// <summary>
        /// Gets or Sets label Table instance.
        /// </summary>
        public DbSet<LabelEntity> label { get; set; }
    }
}
