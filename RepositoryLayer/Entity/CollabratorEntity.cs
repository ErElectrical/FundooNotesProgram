// <copyright file="CollabratorEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RepositoryLayer.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using repositorylayer.entity;

    /// <summary>
    /// Poco class for Collab Table in DB.
    /// </summary>
    public class CollabratorEntity
    {
        /// <summary>
        /// Gets or Sets value contains CollabId Of Collabrator.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long CollabId { get; set; }

        /// <summary>
        /// Gets or Sets value contains NoteId for Collabrator.
        /// NoteId is a foreign key constraints.
        /// </summary>
        [ForeignKey("Note")]
        public long NoteId { get; set; }

        /// <summary>
        /// Gets or Sets values for Note
        /// return type is NoteEntity.
        /// </summary>
        public Notesentity Note { get; set; }

        /// <summary>
        /// Gets or Sets values for userId of collabrator.
        /// </summary>
        [ForeignKey("User")]

        public long Id { get; set; }

        /// <summary>
        /// Gets or Sets value for userId
        /// return type is userEntity.
        /// </summary>
        public UserEntity UserId { get; set; }
    }
}
