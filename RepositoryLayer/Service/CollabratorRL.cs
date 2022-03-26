// <copyright file="CollabratorRL.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RepositoryLayer.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RepositoryLayer.Context;
    using RepositoryLayer.InterFace;

    /// <summary>
    /// CollabratorRL satisfied the ICollabratorRL.
    /// </summary>
    public class CollabratorRL : ICollabratorRL
    {
        private readonly FundooContext fundooContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollabratorRL"/> class.
        /// </summary>
        /// <param name="fundooContext">The fundoo context.</param>
        public CollabratorRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        /// <summary>
        /// Adds the collabrator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// True or False.
        /// </returns>
        public bool AddCollabrator(long noteId,long userId)
        {
            this.fundooContext.Collab.Add(new Entity.CollabratorEntity()
            {
                Id = userId,
                NoteId = noteId,
            });
            var result = this.fundooContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// Deletes the collabrator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// True or False.
        /// </returns>
        public bool DeleteCollabrator(long noteId , long userId)
        {
            var result = this.fundooContext.Collab.FirstOrDefault(e => e.Id == userId && e.NoteId == noteId);
            if (result != null)
            {
                this.fundooContext.Collab.Remove(result);
                this.fundooContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Gets the collabrator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// List of Emails.
        /// </returns>
        public List<string> GetCollabrator(long noteId)
        {
            var result = this.fundooContext.Collab.Where(e => e.NoteId.Equals(noteId)).Select(e => e.UserId).ToList();
            if (result.Count > 0)
            {
                List<string> emails = new List<string>();
                foreach (var collab in result)
                {
                    emails.Add(this.GetUserIdbyMail(collab.Id));
                }

                return emails;
            }

            return null;
        }

        /// <summary>
        /// Gets the user idby mail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns emails of collabrator.
        /// </returns>
        private string GetUserIdbyMail(long id)
        {
            var result = this.fundooContext.User.Find(id);
            return result.Email;

        }
    }
}
