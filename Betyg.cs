using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesDatabase
{
    public class Betyg
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BetygID { get; set; }
        public char BetygsBokstav { get; set; }
        public int KursID { get; set; }
        public Kurs Kurs { get; set; }
        public int ElevID { get; set; }
        public Elev Elev { get; set; }
    }
}
