﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRazorEFC
{
    //[Table("courses")]
    public class Course
    {
        //[Key]
        public int Id { get; set; }
        public string Title { get; set; }

        //[Column("Length")]
        [Range(8, 48, ErrorMessage = "Duration out of [8,48]")]
        public int Duration { get; set; }

        //[NotMapped]
        public string Description { get; set; }
    }
}
