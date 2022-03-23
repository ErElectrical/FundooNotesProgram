// <copyright file="NoteCreation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CommonLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Poco class to Feed NotesEntity.
    /// </summary>
    public class NoteCreation
    {
        /// <summary>
        /// Gets or Sets value contains Title Of Note.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets value contains DEscription Of Note.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets value contains Reminder Of Note.
        /// </summary>
        public DateTime? Reminder { get; set; }

        /// <summary>
        /// Gets or Sets value contains colour Of Note.
        /// </summary>
        public string Colour { get; set; }

        /// <summary>
        /// Gets or Sets value contains Image Of Note.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets value contains IsTrash Of Note.
        /// </summary>
        public bool IsTrash { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets value contains IsArchieve Of Note.
        /// </summary>
        public bool IsArchieve { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets value contains IsPinned Of Note.
        /// </summary>
        public bool IsPinned { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets value contains Date and time  CreatedAt Of Note.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets value contains Date and time  ModifiedAt Of Note.
        /// </summary>
        public DateTime? ModifiedAt { get; set; }
    }
}
