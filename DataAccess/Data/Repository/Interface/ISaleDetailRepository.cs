using Models;

namespace DataAccess
{
    public interface ISaleDetailRepository : IRepository<SaleDetail>
    {
        void Update(SaleDetail obj);
    }
}
