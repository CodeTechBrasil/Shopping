using Models;

namespace Models
{
    public static class OrderDetailExtension
    {
        public static void Map(this OrderDetail objBanco, OrderDetail objClasse)
        {
            objBanco.OrderHeaderId = objClasse.OrderHeaderId;
            objBanco.ProductId= objClasse.ProductId;
        }
    }
}
