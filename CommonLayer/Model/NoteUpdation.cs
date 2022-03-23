// <copyright file="NoteUpdation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CommonLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Poco class To update Notes.
    /// </summary>
    public class NoteUpdation
    {
        /// <summary>
        /// Gets or Sets value contains Title Of Note.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets value contains Description Of Note.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets value contains Image Of Note.
        /// </summary>
        public string Image { get; set; }
    }
}
