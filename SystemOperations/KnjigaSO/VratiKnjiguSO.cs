using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SystemOperations.KnjigaSO
{
    public class VratiKnjiguSO:SystemOperationBase
    {
        public int Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetNewId(entity);


        }
    }
}
