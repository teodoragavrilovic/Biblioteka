using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.KnjigaSO
{
    public class UcitajKnjiguSO : SystemOperationBase
    {
        
        public Knjiga Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetSpecific(entity).Cast<Knjiga>().ToList()[0];
        }
    }
    
}
