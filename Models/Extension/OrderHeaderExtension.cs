using Models;

namespace Models
{
    public static class OrderHeaderExtension
    {
        public static void Map(this OrderHeader objBanco, OrderHeader objClasse)
        {
            objBanco.Email = objClasse.Email;
            objBanco.FullName= objClasse.FullName;
            objBanco.InquiryDate= objClasse.InquiryDate;
            objBanco.PhoneNumber= objClasse.PhoneNumber;
        }
    }
}
