using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.NaslovSO
{
    public class DodajNaslovSO : SystemOperationBase
    {
        
        protected override void ExecuteOperation(IEntity entity)
        {
            repository.Save((Naslov)entity);
        }
    }
}
