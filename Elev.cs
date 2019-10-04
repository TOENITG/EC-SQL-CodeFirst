using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesDatabase
{
    public class Elev
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ElevID { get; set; }
        public string Namn { get; set; }
        public int Alder { get; set; }
    }
}
