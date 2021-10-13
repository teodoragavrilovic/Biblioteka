using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.ClanSO
{
    public class VratiClanaSO : SystemOperationBase
    {
        public int Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetNewId(entity);

                
        }
    }
}
