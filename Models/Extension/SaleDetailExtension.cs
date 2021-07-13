using Models;

namespace Models
{
    public static class SaleDetailExtension
    {
        public static void Map(this SaleDetail objBanco, SaleDetail objClasse)
        {
            objBanco.SaleHeaderId = objClasse.SaleHeaderId;
            objBanco.ProductId = objClasse.ProductId;
            objBanco.Sqft = objClasse.Sqft;
            objBanco.PricePerSqFt = objClasse.PricePerSqFt;
        }
    }
}
