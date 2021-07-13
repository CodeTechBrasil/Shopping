using Models;

namespace DataAccess
{
    public class SaleHeaderRepository : Repository<SaleHeader>, ISaleHeaderRepository
    {
        private readonly ApplicationDbContext _db;
        public SaleHeaderRepository(ApplicationDbContext db): base(db) => _db = db;

        public void Update(SaleHeader obj) => _db.SaleHeader.Update(obj);
    }
}
