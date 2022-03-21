using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.InterFace
{
    public interface ICollabratorBL
    {
        public bool AddCollabrator(long userId, long noteId, CollabratorRequest email);

        public List<string> GetAllColabator(long noteId, long userId);

        public bool DeleteCollabrator(long noteId, long userId, CollabratorRequest email);


    }
}
