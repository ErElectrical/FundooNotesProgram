using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.InterFace
{
    public interface ILabelBL
    {
        public bool AddLabel(long noteId, LabelRequest Label);

        public bool DeleteLabel(long labelId);

        public bool UpdateLabel(long LabelId, LabelRequest Label);

        public List<long> GetAllNoteOfLabel(long LabelId);




    }
}
