using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.ClanarinaSO
{
    public class VratiClanaSaClanarinomSO : SystemOperationBase
    {
        public Clanarina Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
           List<Clanarina> lista = repository.GetSpecific(entity).Cast<Clanarina>().ToList();
            Result = lista[lista.Count - 1];

        }
    }
}
