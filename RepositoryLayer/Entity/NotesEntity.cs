// <copyright file="NotesEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repositorylayer.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using RepositoryLayer.Entity;

    /// <summary>
    /// Poco class for Notes represents Notes in DB.
    /// </summary>
    public class Notesentity
    {
        /// <summary>
        /// Gets or Sets value For NoteId of notes table
        /// unique identity for each note.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NoteId { get; set; }

        /// <summary>
        /// Gets or Sets value For Title of notes table.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets value For Description of notes table.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets value For Reminder of notes table.
        /// </summary>
        public DateTime? Reminder { get; set; }

        /// <summary>
        /// Gets or Sets value For colour of notes table.
        /// </summary>
        public string Colour { get; set; }

        /// <summary>
        /// Gets or Sets value For Image of notes table.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets value For IsTrash of notes table.
        /// </summary>
        public bool IsTrash { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets value For IsArchieve of notes table.
        /// </summary>
        public bool IsArchieve { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets value For IsPinned of notes table.
        /// </summary>
        public bool IsPinned { get; set; }

        /// <summary>
        /// Gets or Sets value For Date Time createdAt of notes table.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets value For ModifiedAt of notes table.
        /// </summary>
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Gets or Sets value For Id of userId
        /// unique identity of every  User.
        /// </summary>
        [ForeignKey("user")]

        public long Id { get; set; }

        /// <summary>
        /// Gets or Sets user and returns userEntity.
        /// </summary>
        public UserEntity user { get; set; }

        /// <summary>
        /// Gets or Sets value of collab.
        /// </summary>
        public ICollection<CollabratorEntity> collab { get; set; }
    }
}
