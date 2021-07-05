using Models;

namespace DataAccess
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public SubCategoryRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public void Update(SubCategory obj)
        {
            _db.Update(obj);
        }
    }
}
