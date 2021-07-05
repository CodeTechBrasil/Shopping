using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;

        public DbInitializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public async void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                      _db.Database.Migrate();

                    InitializeRegisterDefatult();
                }
            }
            catch (System.Exception ex)
            {

                System.Console.WriteLine(ex.Message);
            }
        }

        private void InitializeRegisterDefatult()
        {
            //if(_db.Category.Count() == 0)
                CreateCategory();

            //if (_db.ApplicationType.Count() == 0)
                CreateApplicationType();
        }

        private void CreateApplicationType()
        {
            var list = new List<SubCategory>
            {
                new SubCategory{Name = "Leite"},
                new SubCategory{Name = "Água"},
                new SubCategory{Name = "Misto"}
            };
            foreach (var item in list)
                _db.SubCategory.Add(item);

            _db.SaveChanges();
        }

        private void CreateCategory()
        {
            var list = new List<Category>
            {
                new Category{Name = "Sorvete",DisplayOrder = 1},
                new Category{Name = "Picolé Fruta",DisplayOrder = 2},
                new Category{Name = "Picolé Leite",DisplayOrder = 3},
                new Category{Name = "Paleta",DisplayOrder = 4}
            };
            foreach (var item in list)
                _db.Category.Add(item);

            _db.SaveChanges();
        }
    }
}
