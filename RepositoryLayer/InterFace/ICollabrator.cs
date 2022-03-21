using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.InterFace
{
    public interface ICollabratorRL
    {
        public bool AddCollabrator(long noteId, long userId);

        public bool DeleteCollabrator(long noteId, long userId);

        public List<string> GetCollabrator(long noteId);



    }
}
