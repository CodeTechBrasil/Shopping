using Models;

namespace DataAccess
{
    public static class OrderHeaderExtension
    {
        public static void Map(this OrderHeader objBanco, OrderHeader objClasse)
        {
            objBanco.OrderDate = objClasse.OrderDate;
            objBanco.ShippingDate = objClasse.ShippingDate;
            objBanco.FinalOrderTotal = objClasse.FinalOrderTotal;
            objBanco.OrderStatus = objClasse.OrderStatus;
            objBanco.PaymentDate = objClasse.PaymentDate;
            objBanco.TransactionId = objClasse.TransactionId;
            objBanco.PhoneNumber = objClasse.PhoneNumber;
            objBanco.StreetAddress = objClasse.StreetAddress;
            objBanco.City = objClasse.City;
            objBanco.State = objClasse.State;
            objBanco.PostalCode = objClasse.PostalCode;
            objBanco.FullName = objClasse.FullName;
            objBanco.Email = objClasse.Email;
        }
    }
}
