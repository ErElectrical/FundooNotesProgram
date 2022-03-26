// <copyright file="UserEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RepositoryLayer.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using Repositorylayer.Entity;

    /// <summary>
    /// Poco class that shows a model of User Table.
    /// created in Database.
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// unique identitfication for each user.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the modified at.
        /// </summary>
        /// <value>
        /// The modified at.
        /// </value>
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// return type id Icollection of Notesentity.
        /// The ICollection interface in C# defines the size,
        /// enumerators, and synchronization methods for all nongeneric collections.
        /// It is the base interface for classes in the System. Collections namespace.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public ICollection<Notesentity> Notes { get; set; }

        /// <summary>
        /// Gets or sets the collab.
        /// return type is ICollection of CollabratorEntity.
        /// </summary>
        /// <value>
        /// The collab.
        /// </value>
        public ICollection<CollabratorEntity> collab { get; set; }
    }
}
