using gls_assignment.Configurations;
using Microsoft.Extensions.Options;

namespace gls_assignment.Services
{
    public class DbService:IDbService
    {
        private readonly DbServiceOptions _options;

        public DbService(IOptions<DbServiceOptions> options)
        {
            _options = options.Value;
        }
        public string RetrieveData()
        {
            return "Some DBdata";
        }
    }
}
