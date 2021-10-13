using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.AutorSO
{
    public class VratiAutoreSO : SystemOperationBase
    {
        public List<Autor> Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetAll(new Autor()).Cast<Autor>().ToList();
        }
    }
}
