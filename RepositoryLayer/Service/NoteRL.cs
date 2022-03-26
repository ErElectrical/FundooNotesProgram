// <copyright file="NoteRL.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RepositoryLayer.Service
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Http;
    using RepositoryLayer.Context;
    using Repositorylayer.Entity;
    using RepositoryLayer.InterFace;

    /// <summary>
    /// NoteRL satisfied the interface INoteRL.
    /// </summary>
    /// <seealso cref="RepositoryLayer.InterFace.INoteRL" />
    public class NoteRL : INoteRL
    {
        private readonly FundooContext fundooContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteRL"/> class.
        /// </summary>
        /// <param name="fundooContext">The fundoo context.</param>
        public NoteRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        /// <summary>
        /// Creates the note.
        /// </summary>
        /// <param name="noteCreation">The note creation.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// Noteentity if notecreted. 
        /// else null.
        /// </returns>
        public Notesentity createNote(NoteCreation noteCreation,long userId)
        {
            try
            {
                Notesentity note = new Notesentity();
                note.Title = noteCreation.Title;
                note.Description = noteCreation.Description;
                note.Colour = noteCreation.Colour;
                note.Image = noteCreation.Image;
                note.Reminder = noteCreation.Reminder;
                note.IsArchieve = noteCreation.IsArchieve;
                note.IsPinned = noteCreation.IsPinned;
                note.IsTrash = noteCreation.IsTrash;
                note.ModifiedAt = noteCreation.ModifiedAt;
                note.CreatedAt = noteCreation.CreatedAt;
                note.Id = userId;
                this.fundooContext.Notes.Add(note);
                int result = this.fundooContext.SaveChanges();
                if (result > 0)
                {
                    return note;
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

        /// <summary>
        /// Gets all notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// List of Notesentity.
        /// else return null.
        /// </returns>
        public List<Notesentity> GetAllNotes(long userId)
        {
            try
            {
                var result = this.fundooContext.Notes.Where(e => e.Id == userId).ToList();
                if (result != null)
                {
                    return result;
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

        /// <summary>
        /// Updates the note.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="updation">The updation.</param>
        /// <returns>
        /// Notesentity or  null.
        /// </returns>
        public Notesentity UpdateNote(long noteId , long userId , NoteUpdation updation)
        {
            // firstorDefault method returns first element of sequence or default when no element found
            try
            {
                var result = this.fundooContext.Notes.FirstOrDefault(e => e.NoteId == noteId && e.Id == userId);
                if (result != null)
                {
                    if (updation.Title != null)
                    {
                        result.Title = updation.Title;
                    }

                    if (updation.Description != null)
                    {
                        result.Description = updation.Description;
                    }

                    if (updation.Image != null)
                    {
                        result.Image = updation.Image;
                    }

                    result.ModifiedAt = DateTime.Now;
                    this.fundooContext.SaveChanges();
                    return result;
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

        /// <summary>
        /// Deletes the note.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// True or False
        /// </returns>
        public bool DeleteNote(long userId,long noteId)
        {
            try
            {
                var result = this.fundooContext.Notes.FirstOrDefault(e => e.Id == userId && e.NoteId == noteId);
                if (result != null)
                {
                    this.fundooContext.Notes.Remove(result);
                    this.fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Ispinneds the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// True or False
        /// </returns>
        public bool Ispinned(long userId,long noteId)
        {
            var result = this.fundooContext.Notes.FirstOrDefault(e => e.Id == userId && e.NoteId == noteId);
            if (result != null)
            {
                if (result.IsPinned == true)
                {
                    result.IsPinned = false;
                }
                else
                {
                    result.IsPinned = true;
                }

                this.fundooContext.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified user identifier is trash.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        ///   <c>true</c> if the specified user identifier is trash; otherwise, <c>false</c>.
        /// </returns>
        public bool IsTrash(long userId,long noteId)
        {
            var result = this.fundooContext.Notes.FirstOrDefault(e => e.Id == userId && e.NoteId == noteId);
            if (result != null)
            {
                if (result.IsTrash == true)
                {
                    result.IsTrash = false;
                }
                else
                {
                    result.IsTrash = true;
                }

                this.fundooContext.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified user identifier is archieve.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        ///   <c>true</c> if the specified user identifier is archieve; otherwise, <c>false</c>.
        /// </returns>
        public bool IsArchieve(long userId,long noteId)
        {
            var result = this.fundooContext.Notes.FirstOrDefault(e => e.Id == userId && e.NoteId == e.NoteId);
            if (result != null)
            {
                if (result.IsArchieve == true)
                {
                    result.IsArchieve = false;
                }
                else
                {
                    result.IsArchieve = true;
                }

                this.fundooContext.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Upload image on cloudinary through application.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="noteId"></param>
        /// <returns>
        /// True or False.
        /// </returns>
        public bool UploadImage(IFormFile file, long noteId)
        {
            try
            {

                // provide credentials to the constructor of cloudinary class
                var CloudinaryData = new CloudinaryDotNet.Cloudinary(new Account
                {
                    ApiKey = "489788912754161",
                    ApiSecret = "SgcAbpkm2vEoafLV5OhtOt_PJiU",
                    Cloud = "dwwotohwm"
                });

                // take the file into streams
                Stream s = file.OpenReadStream();

                // provide filename and stream of file to ImageUploadParams.
                var imageuploadparams = new ImageUploadParams()
                {
                    File = new FileDescription("Test", s)
                };

                // upload the file on cloudinary 
                var Result = CloudinaryData.Upload(imageuploadparams);
                // match the noteId with table noteId
                var result = this.fundooContext.Notes.FirstOrDefault(e => e.NoteId == noteId);
                // if found entry than provide the Url to image cloumn
                if (result != null)
                {
                    result.Image = Result.Url.ToString();
                    this.fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Changes the color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// True or False.
        /// </returns>
        public bool ChangeColor(string color,long userId,long noteId)
        {
            var result = this.fundooContext.Notes.FirstOrDefault(e => e.Id == userId && e.NoteId == noteId);
            if (result != null)
            {
                result.Colour = color;
                this.fundooContext.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the note.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns> 
        /// Notesentitiy else null.
        /// </returns>
        public Notesentity GetNote(long noteId)
        {
            return this.fundooContext.Notes.Find(noteId);
        }


    }
}
