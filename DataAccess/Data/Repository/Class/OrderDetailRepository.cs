using Models;

namespace DataAccess
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(OrderDetail obj)
        {
            var objFromDb = base.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
                objFromDb.Map(obj);

            _db.OrderDetail.Update(obj);
        }
    }
}
