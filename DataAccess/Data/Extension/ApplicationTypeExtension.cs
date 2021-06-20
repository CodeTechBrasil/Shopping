using Models;
using System.Threading;

namespace DataAccess
{
    public static class ApplicationTypeExtension
    {
        public static void Map(this ApplicationType objBanco, ApplicationType objClasse)
        {
            objBanco.Name = objClasse.Name;
        }
    }
}
