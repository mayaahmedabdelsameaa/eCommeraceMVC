using eCommerace.Data.Base;
using eCommerace.Models;

namespace eCommerace.Data.Services
{
    public class CinemasService: EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDBContext context) : base(context) { }
    }
}
