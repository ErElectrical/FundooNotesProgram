// <copyright file="ILabelRL.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RepositoryLayer.InterFace
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CommonLayer.Model;

    /// <summary>
    /// Interface ILabelRL satisfied by LabelRL class.
    /// </summary>
    public interface ILabelRL
    {
        /// <summary>
        /// Method Add Label to Label Entity that will add data into Label table in DB.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="label">The label.</param>
        /// <returns>
        /// True if Lable added
        /// false if Label not added.
        /// </returns>
         public bool AddLabel(long noteId, LabelRequest label);

        /// <summary>
        /// DeleteLabel Method delete Label in Label table of DB.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>
        /// returns true if Label Deleted
        /// false if Label not deleted.
        /// </returns>
         public bool DeleteLabel(long labelId);

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <param name="label">The label.</param>
        /// <returns>
        /// True if Label updated.
        /// false if Label not updated.
        /// </returns>
         public bool UpdateLabel(long labelId, LabelRequest label);

        /// <summary>
        /// Gets all note of label.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>
        /// List of Email if true
        /// else null.
        /// </returns>
         public List<long> GetAllNoteOfLabel(long labelId);
    }
}
