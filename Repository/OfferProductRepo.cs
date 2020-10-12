using LootLoOnline_FunctionApp.Interface;
using LootLoOnline_FunctionApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace LootLoOnline_FunctionApp.Repository
{
    public class OfferProductRepository : DataRepository<OfferProduct>, IOfferProductRepository
    {
        //private IConfiguration configuration;
        //public IMemoryCache MemoryCache { get; }
        // public IDataRepository<OfferProduct> dataRepository;
        ////public OfferProductRepo(IConfiguration config, IMemoryCache memoryCache)
        ////{
        ////    configuration = config;
        ////    MemoryCache = memoryCache;
        ////    dataRepository = new DataRepository<OfferProduct>();
        ////}

        //public OfferProductRepository(LootLoOnlineDbContext lootLoOnlineDbContext)
        //{
        //    dataRepository = new DataRepository<OfferProduct>(lootLoOnlineDbContext);
        //}
        public OfferProductRepository(LootLoOnlineDbContext lootLoOnlineDbContext) : base(lootLoOnlineDbContext)
        {
        }

        public Task<IQueryable<OfferProduct>> GetAllProductOffersAsync()
        {

            return GetAll();
        }

    }
}
