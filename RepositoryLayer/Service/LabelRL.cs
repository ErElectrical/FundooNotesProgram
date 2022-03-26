// <copyright file="LabelRL.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RepositoryLayer.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CommonLayer.Model;
    using RepositoryLayer.Context;
    using RepositoryLayer.Entity;
    using RepositoryLayer.InterFace;

    /// <summary>
    /// LabelRL satisfied the interface ILabelRL.
    /// </summary>
    /// <seealso cref="RepositoryLayer.InterFace.ILabelRL" />
    public class LabelRL : ILabelRL
    {
        private readonly FundooContext fundooContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelRL"/> class.
        /// </summary>
        /// <param name="fundooContext">The fundoo context.</param>
        public LabelRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        /// <summary>
        /// Method Add Label to Label Entity that will add data into Label table in DB.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="Label">The label.</param>
        /// <returns>
        /// True if Lable added
        /// false if Label not added.
        /// </returns>
        public bool AddLabel(long noteId, LabelRequest Label)
        {
            try
            {
                if (Label.labelName == null)
                {
                    return false;
                }

                this.fundooContext.label.Add(new Entity.LabelEntity()
                {
                    LabelName = Label.labelName,
                    NoteId = noteId,
                });

                var result = this.fundooContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>
        /// True or False.
        /// </returns>
        public bool DeleteLabel(long labelId)
        {
            var result = this.fundooContext.label.FirstOrDefault(e => e.LabelId == labelId);
            if (result != null)
            {
                this.fundooContext.label.Remove(result);
                this.fundooContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="LabelId">The label identifier.</param>
        /// <param name="Label">The label.</param>
        /// <returns>
        /// True if Label updated.
        /// false if Label not updated.
        /// </returns>
        public bool UpdateLabel(long LabelId, LabelRequest Label)
        {
            try
            {
                var result = this.fundooContext.label.FirstOrDefault(e => e.LabelId == LabelId);
                if (result != null)
                {
                    result.LabelName = Label.labelName;
                    this.fundooContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all note of label.
        /// </summary>
        /// <param name="LabelId">The label identifier.</param>
        /// <returns>
        /// List of noteId if true
        /// else null.
        /// </returns>
        public List<long> GetAllNoteOfLabel(long LabelId)
        {
            try
            {
                var result = this.fundooContext.label.Where(e => e.LabelId == LabelId).Select(e => e.NoteId).ToList();
                if (result != null)
                {
                    List<long> noteId = new List<long>();
                    foreach (var x in result)
                    {
                        noteId.Add(x);
                    }

                    return noteId;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
