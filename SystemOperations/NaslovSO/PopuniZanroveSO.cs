using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.NaslovSO
{
    public class PopuniZanroveSO : SystemOperationBase
    {
        public List<Zanr> Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetAll(new Zanr()).Cast<Zanr>().ToList();
        }
    }
}
