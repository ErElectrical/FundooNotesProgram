using repositorylayer.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class CollabratorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long CollabId { get; set; }

        [ForeignKey("Note")]
        public long NoteId { get; set; }

        public Notesentity Note { get; set; }
        
        [ForeignKey("User")]

        public long Id { get; set; }

        public UserEntity UserId{get; set; }

    }
}
