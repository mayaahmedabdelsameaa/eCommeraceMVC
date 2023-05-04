using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerace.Models
{
    public class Actor_Movie
    {
        public int MovieId { get; set; }

        //[ForeignKey("Movie")]
        public Movie Movie { get; set; }
        public int ActorId { get; set; }

        //[ForeignKey("Actor")]
        public Actor Actor { get; set; }
    }
}
