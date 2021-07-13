using Models;
using System.Threading;

namespace Models
{
    public static class SubCategoryExtension
    {
        public static void Map(this SubCategory objBanco, SubCategory objClasse)
        {
            objBanco.Name = objClasse.Name;
        }
    }
}
