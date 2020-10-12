using LootLoOnline_FunctionApp.Interface;
using System.Linq;
using System.Threading.Tasks;
using Log = LootLoOnline_FunctionApp.Models.Log;

namespace LootLoOnline_FunctionApp.Repository
{
    public class LogsRepository : DataRepository<Log>, ILogsRepository
    {
        public LogsRepository(LootLoOnlineDbContext lootLoOnlineDbContext) : base(lootLoOnlineDbContext)
        {
        }

        public Task<IQueryable<Log>> GetAllLogsAsync()
        {

            return GetAll();
        }
    }

}
