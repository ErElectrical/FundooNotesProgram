// <copyright file="INoteRL.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RepositoryLayer.InterFace
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Http;
    using Repositorylayer.Entity;

    /// <summary>
    /// INoteRL is a interface that has function releated to notes.
    /// </summary>
    public interface INoteRL
    {
        /// <summary>
        /// Create Notes function
        /// </summary>
        /// <param name="noteCreation"></param>
        /// <param name="id"></param>
        /// <returns>
        /// Notesentity.
        /// </returns>
        public Notesentity createNote(NoteCreation noteCreation, long id);

        /// <summary>
        /// fetch all notes of a user.
        /// </summary>
        /// <param name="userId">
        /// 
        /// </param>
        /// <returns>
        /// List of NotesEntiity.
        /// </returns>
        public List<Notesentity> GetAllNotes(long userId);

        /// <summary>
        /// update notes
        /// </summary>
        /// <param name="noteId"></param>
        /// <param name="userId"></param>
        /// <param name="updation"></param>
        /// <returns>NotesEntiity</returns>
        public Notesentity UpdateNote(long noteId, long userId, NoteUpdation updation);

        /// <summary>
        /// Delete Note
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="noteId"></param>
        /// <returns>
        /// True or False.
        /// </returns>
        public bool DeleteNote(long userId, long noteId);

        /// <summary>
        /// IsPinned or not.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="noteId"></param>
        /// <returns>
        /// True or False.
        /// </returns>
        public bool Ispinned(long userId, long noteId);

        /// <summary>
        /// IsTrash or not.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="noteId"></param>
        /// <returns>
        /// True or False.
        /// </returns>
        public bool IsTrash(long userId, long noteId);

        /// <summary>
        /// IsArchieve or not
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="noteId"></param>
        /// <returns>
        /// True or False.
        /// </returns>
        public bool IsArchieve(long userId, long noteId);

        /// <summary>
        /// Upload a Image for Note
        /// </summary>
        /// <param name="file"></param>
        /// <param name="noteId"></param>
        /// <returns>
        /// True or false
        /// </returns>
        public bool UploadImage(IFormFile file, long noteId);

        /// <summary>
        /// Change color of notes
        /// </summary>
        /// <param name="color"></param>
        /// <param name="userId"></param>
        /// <param name="noteId"></param>
        /// <returns>
        /// True or False.
        /// </returns>
        public bool ChangeColor(string color, long userId, long noteId);

        /// <summary>
        /// Get note of specific noteid
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns>
        /// NotesEntiity or null.
        /// </returns>
        public Notesentity GetNote(long noteId);









    }
}
