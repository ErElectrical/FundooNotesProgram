using BussinessLayer.InterFace;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class CollabratorBL : ICollabratorBL
    {
        private readonly ICollabratorRL collabratorRL;
        private readonly INoteRL noteRL;
        private readonly IUserRL userRL;

        public CollabratorBL(ICollabratorRL collabratorRL, INoteRL noteRL, IUserRL userRL)
        {
            this.collabratorRL = collabratorRL;
            this.noteRL = noteRL;
            this.userRL = userRL;
        }

        public bool AddCollabrator(long userId,long noteId, CollabratorRequest email)
        {
            var note = this.noteRL.GetNote(noteId);
            if(note != null)
            {
                if(!note.Id.Equals(userId))
                {
                    return false;
                }
                var user = this.userRL.GetUserByEmail(email.Email);
                if(user == null)
                {
                    return false;
                }
            }
            return this.collabratorRL.AddCollabrator(noteId, userId);
        }

        public bool DeleteCollabrator(long noteId, long userId, CollabratorRequest email)
        {

            var result = this.noteRL.GetNote(noteId);
            if (!result.Id.Equals(userId))
            {
                return false;
            }

            var Email = this.userRL.GetUserByEmail(email.Email);
            if(Email == null)
            {
                return false;
            }
            return this.collabratorRL.DeleteCollabrator(noteId, userId);
            
        }

        public List<string> GetAllColabator(long noteId,long userId)
        {
            try
            {


                var note = this.noteRL.GetNote(userId);
                if (!note.Id.Equals(userId))
                {
                    return null;
                }
                return this.collabratorRL.GetCollabrator(noteId);
            }
            catch(Exception)
            {
                throw;
            }

        }

    }
}
