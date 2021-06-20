﻿using Models;

namespace DataAccess
{
    public class InquiryHeaderRepository : Repository<InquiryHeader>, IInquiryHeaderRepository
    {
        private readonly ApplicationDbContext _db;
        public InquiryHeaderRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(InquiryHeader obj)
        {
            var objFromDb = base.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
                objFromDb.Map(obj);

            _db.InquiryHeader.Update(obj);
        }
    }
}