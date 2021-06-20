using Models;

namespace DataAccess
{
    public static class InquiryDetailExtension
    {
        public static void Map(this InquiryDetail objBanco, InquiryDetail objClasse)
        {
            objBanco.InquiryHeaderId = objClasse.InquiryHeaderId;
            objBanco.ProductId= objClasse.ProductId;
        }
    }
}
