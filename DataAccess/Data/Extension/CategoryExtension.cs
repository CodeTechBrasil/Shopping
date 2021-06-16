using Models;
using System.Threading;

namespace DataAccess
{
    public static class CategoryExtension
    {
        public static void Map(this Category objBanco,Category objClasse)
        {
            objBanco.Name = objClasse.Name;
            objBanco.DisplayOrder = objClasse.DisplayOrder;
        }
    }
}
