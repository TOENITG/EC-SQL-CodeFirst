﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesDatabase
{
    public class Kurs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KursID { get; set; }
        public string Namn { get; set; }
        public int Sal { get; set; }
        public int LarareID { get; set; }
        public Larare Larare { get; set; }
    }
}
