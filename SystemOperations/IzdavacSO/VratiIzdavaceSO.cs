using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.IzdavacSO
{
    public class VratiIzdavaceSO:SystemOperationBase
    {
        public List<Izdavac> Result { get; set; }
        
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetAll(new Izdavac()).Cast<Izdavac>().ToList();
        }
    }
}
