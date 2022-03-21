using BussinessLayer.InterFace;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using repositorylayer.entity;
using RepositoryLayer.Context;
using RepositoryLayer.InterFace;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class NoteBL : INoteBL
    {
        private readonly INoteRL noteRL;


        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;

        }

        public Notesentity CreateNote(NoteCreation noteCreation, long userId)
        {
            try
            {
                return noteRL.createNote(noteCreation, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Notesentity> GetAllNotes(long userId)
        {
            try
            {
                return this.noteRL.GetAllNotes(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Notesentity UpdateNotes(long noteId, long userId, NoteUpdation updation)
        {
            try
            {
                return this.noteRL.UpdateNote(noteId, userId, updation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNote(long userId, long noteId)
        {
            try
            {
                return this.noteRL.DeleteNote(userId, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Ispinned(long userId, long noteId)
        {
            try
            {
                return this.noteRL.Ispinned(userId, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsArchieve(long userId, long noteId)
        {
            try
            {
                return this.noteRL.IsArchieve(userId, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsTrash(long userId, long noteId)
        {
            try
            {
                return this.noteRL.IsTrash(userId, noteId);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool UploadImage(IFormFile file, long noteId)
        {
            try
            {
                return noteRL.UploadImage(file, noteId);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool ChangeColor(string color, long userId, long noteId)
        {
            try
            {
                return this.noteRL.ChangeColor(color, userId, noteId);
            }
            catch(Exception)
            {
                throw;
            }
        }





    }
}
