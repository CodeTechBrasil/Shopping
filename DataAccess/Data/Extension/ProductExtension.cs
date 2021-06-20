using Models;

namespace DataAccess
{
    public static class ProductExtension
    {
        public static void Map(this Product objBanco, Product objClasse)
        {
            objBanco.Name = objClasse.Name;
            objBanco.ShortDesc = objClasse.ShortDesc;
            objBanco.Description = objClasse.Description;
            objBanco.Price = objClasse.Price;
            objBanco.Image = objClasse.Image;
            objBanco.CategoryId = objClasse.CategoryId;
            objBanco.TempSqFt = objClasse.TempSqFt;
        }
    }
}
