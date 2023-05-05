using eCommerace.Data.Base;
using eCommerace.Models;

namespace eCommerace.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDBContext context):base(context) { }
    }
}
