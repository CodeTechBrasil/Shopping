using Models;

namespace DataAccess
{
    public static class InquiryHeaderExtension
    {
        public static void Map(this InquiryHeader objBanco, InquiryHeader objClasse)
        {
            objBanco.Email = objClasse.Email;
            objBanco.FullName= objClasse.FullName;
            objBanco.InquiryDate= objClasse.InquiryDate;
            objBanco.PhoneNumber= objClasse.PhoneNumber;
        }
    }
}
