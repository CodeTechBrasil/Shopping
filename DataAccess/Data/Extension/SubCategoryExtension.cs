using Models;
using System.Threading;

namespace DataAccess
{
    public static class SubCategoryExtension
    {
        public static void Map(this SubCategory objBanco, SubCategory objClasse)
        {
            objBanco.Name = objClasse.Name;
        }
    }
}
