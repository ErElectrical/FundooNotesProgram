using BussinessLayer.InterFace;
using CommonLayer.Model;
using RepositoryLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class LabelBL : ILabelBL
    {
        private readonly ILabelRL labelRL;

        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }

        public bool AddLabel(long noteId, LabelRequest Label)
        {
            try
            {
                return this.labelRL.AddLabel(noteId, Label);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool DeleteLabel(long labelId)
        {
            try
            {
                return this.labelRL.DeleteLabel(labelId);

            }
            catch(Exception)
            {
                throw;
            }

        }

        public bool UpdateLabel(long LabelId, LabelRequest Label)
        {
            try
            {
                return this.labelRL.UpdateLabel(LabelId, Label);
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
                return this.labelRL.GetAllNoteOfLabel(LabelId);
            }
            catch(Exception)
            {
                throw;
            }
        }




    }

}
