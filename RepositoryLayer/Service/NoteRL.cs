using CommonLayer.Model;
using repositorylayer.entity;
using RepositoryLayer.Context;
using RepositoryLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace RepositoryLayer.Service
{
    public class NoteRL : INoteRL
    {
        private readonly FundooContext fundooContext;

        public NoteRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

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
            catch(Exception)
            {
                throw;
            }
        }

        public List<Notesentity> GetAllNotes(long userId)
        {
            try
            {


                var result = fundooContext.Notes.Where(e => e.Id == userId).ToList();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        
        public Notesentity UpdateNote(long noteId,long userId,NoteUpdation updation)
        {
            //firstorDefault method returns first element of sequence or default when no element found
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
            catch(Exception)
            {
                throw;
            }
        }

        public bool DeleteNote(long userId,long noteId)
        {
            try
            {


                var result = this.fundooContext.Notes.FirstOrDefault(e => e.Id == userId && e.NoteId == noteId);
                if (result != null)
                {
                    this.fundooContext.Notes.Remove(result);
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool Ispinned(long userId,long noteId)
        {
            var result = this.fundooContext.Notes.FirstOrDefault(e => e.Id == userId && e.NoteId == noteId);
            if(result != null)
            {
                if(result.IsPinned == true)
                {
                    result.IsPinned = false;
                }
                else
                {
                    result.IsPinned = true;
                }

                fundooContext.SaveChanges();
                return true;

                
            }
            return false;
        }

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

                fundooContext.SaveChanges();
                return true;


            }
            return false;
        }

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

                fundooContext.SaveChanges();
                return true;


            }
            return false;
        }

        public bool UploadImage(IFormFile file, long noteId)
        {
            try
            {


                var CloudinaryData = new CloudinaryDotNet.Cloudinary(new Account
                {
                    ApiKey = "489788912754161",
                    ApiSecret = "SgcAbpkm2vEoafLV5OhtOt_PJiU",
                    Cloud = "dwwotohwm"
                });

                Stream s = file.OpenReadStream();

                var imageuploadparams = new ImageUploadParams()
                {
                    File = new FileDescription("Test", s)
                };

                var Result = CloudinaryData.Upload(imageuploadparams);

                var result = this.fundooContext.Notes.FirstOrDefault(e => e.NoteId == noteId);
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

        public Notesentity GetNote(long noteId)
        {
            return this.fundooContext.Notes.Find(noteId);
        }


    }
}
