using RepositoryLayer.Context;
using RepositoryLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RepositoryLayer.Service
{
   public class CollabratorRL : ICollabratorRL
    {
        private readonly FundooContext fundooContext;

        public CollabratorRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        public bool AddCollabrator(long noteId,long userId)
        {
            fundooContext.Collab.Add(new Entity.CollabratorEntity()
            {
                Id = userId,
                NoteId = noteId
            });
            var result = fundooContext.SaveChanges();
            if(result > 0)
            {
                return true;
            }
            return false;

        }

        public bool DeleteCollabrator(long noteId,long userId)
        {
            var result = this.fundooContext.Collab.FirstOrDefault(e => e.Id == userId && e.NoteId == noteId);
            if(result != null)
            {
                this.fundooContext.Collab.Remove(result);
                fundooContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<string> GetCollabrator(long noteId)
        {
            var result = this.fundooContext.Collab.Where(e => e.NoteId.Equals(noteId)).Select(e => e.UserId).ToList();
            if(result.Count > 0)
            {
                List<string> Emails = new List<string>();
                foreach(var collab in result)
                {
                    Emails.Add(GetUserIdbyMail(collab.Id));
                }
                return Emails;
            }
            return null;
        }

        private string GetUserIdbyMail(long Id)
        {
            var result = this.fundooContext.User.Find(Id);
            return result.Email;

        }
    }
}
