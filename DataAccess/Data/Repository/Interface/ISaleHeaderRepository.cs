using Models;

namespace DataAccess
{
    public interface ISaleHeaderRepository : IRepository<SaleHeader>
    {
        void Update(SaleHeader obj);
    }
}
