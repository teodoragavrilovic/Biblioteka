using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.ClanSO
{
    public class VratiClanaPoKriterijumuSO : SystemOperationBase
    {
        public bool Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            List<Clan> lista = new List<Clan>();

           lista = repository.GetSpecific(entity).Cast<Clan>().ToList();
            if (lista.Count==0)
                Result = true;
            else
                Result = false;
        }
    }
}
