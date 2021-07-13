using Models;

namespace DataAccess
{
    public class SaleDetailRepository : Repository<SaleDetail>, ISaleDetailRepository
    {
        private readonly ApplicationDbContext _db;
        public SaleDetailRepository(ApplicationDbContext db): base(db) => _db = db;

        public void Update(SaleDetail obj) => _db.SaleDetail.Update(obj);
    }
}
