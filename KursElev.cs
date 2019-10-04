using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesDatabase
{
    public class KursElev
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KursElevID { get; set; }
        public int KursID { get; set; }
        public Kurs Kurs { get; set; }
        public int ElevID { get; set; }
        public Elev Elev { get; set; }
        public char Betyg { get; set; }
    }
}
