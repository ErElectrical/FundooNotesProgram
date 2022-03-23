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

        public string Description { get; set; }

        public DateTime? Reminder { get; set; }

        public string Colour { get; set; }

        public string Image { get; set; }

        public bool IsTrash { get; set; }

        public bool IsArchieve { get; set; }

        public bool IsPinned { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [ForeignKey("user")]

        public long Id { get; set; }

        public UserEntity user { get; set; }

        public ICollection<CollabratorEntity> collab { get; set; }

       

      



    }
}
