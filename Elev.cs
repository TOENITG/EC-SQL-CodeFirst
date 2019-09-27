using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesDatabase
{
    public class Elev
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ElevID { get; set; }
        public int KursID { get; set; }
        public string Namn { get; set; }
        public Kurs Kurs { get; set; }
    }
}
