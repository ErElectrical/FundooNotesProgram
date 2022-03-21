using repositorylayer.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long LabelId { get; set; } 

        public string LabelName { get; set; }

        [ForeignKey("Note")]

        public long NoteId { get; set; }

        public Notesentity Note { get; set; }

    }
}
