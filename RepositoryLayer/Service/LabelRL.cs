using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RepositoryLayer.Service
{
    public class LabelRL : ILabelRL
    {
        private readonly FundooContext fundooContext;

        public LabelRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
          
        }

        public bool AddLabel(long noteId, LabelRequest Label )
        {
            try
            {
                if (Label.labelName == null)
                    return false;
               this.fundooContext.label.Add(new Entity.LabelEntity()
                {
                    LabelName = Label.labelName,
                    NoteId = noteId
                });
                var result = this.fundooContext.SaveChanges();
                if(result > 0)
                {
                    return true;
                }
                return false;


            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool DeleteLabel(long labelId)
        {
            var result = this.fundooContext.label.FirstOrDefault(e => e.LabelId == labelId);
            if(result != null)
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
            catch(Exception)
            {
                throw;
            }
        }

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
                    return null;
            }
            catch(Exception)
            {
                throw;
            }
        }

        

    }
}
