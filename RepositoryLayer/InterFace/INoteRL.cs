using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using repositorylayer.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.InterFace
{
    public interface INoteRL
    {
        public Notesentity createNote(NoteCreation noteCreation, long Id);
        public List<Notesentity> GetAllNotes(long userId);

        public Notesentity UpdateNote(long noteId, long userId, NoteUpdation updation);

        public bool DeleteNote(long userId, long noteId);

        public bool Ispinned(long userId, long noteId);

        public bool IsTrash(long userId, long noteId);

        public bool IsArchieve(long userId, long noteId);

        public bool UploadImage(IFormFile file, long noteId);

        public bool ChangeColor(string color, long userId, long noteId);
        public Notesentity GetNote(long noteId);









    }
}
