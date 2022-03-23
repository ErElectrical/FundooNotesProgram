// <copyright file="LabelEntity.cs" company="PlaceholderCompany">
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
    /// Poco class that is refernce of Label table in DB.
    /// </summary>
    public class LabelEntity
    {
        /// <summary>
        /// Gets or sets value of LabelId for Label Table.
        /// unique identity for each Label.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelId { get; set; }

        /// <summary>
        /// Gets or sets value of LabelName for Label Table.
        /// </summary>
        public string LabelName { get; set; }

        /// <summary>
        /// Gets or Sets value of NoteId for Label
        /// a foreign key dervied from NotesEntity class.
        /// </summary>
        [ForeignKey("Note")]

        public long NoteId { get; set; }

        /// <summary>
        /// Gets or Sets Note.
        /// return Type is NotesEntity.
        /// </summary>
        public Notesentity Note { get; set; }
    }
}
