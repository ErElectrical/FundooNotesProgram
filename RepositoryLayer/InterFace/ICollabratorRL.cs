// <copyright file="ICollabrator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RepositoryLayer.InterFace
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// InterFace Created for CollabRL class.
    /// </summary>
    public interface ICollabratorRL
    {

        /// <summary>
        /// Adds the collabrator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// True or False.
        /// </returns>
        public bool AddCollabrator(long noteId, long userId);

        /// <summary>
        /// Deletes the collabrator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// True or False.
        /// </returns>
/        public bool DeleteCollabrator(long noteId, long userId);

        /// <summary>
        /// Gets the collabrator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// List Of Emails of user
        /// </returns>
/        public List<string> GetCollabrator(long noteId);



    }
}
