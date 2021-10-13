using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.NaslovSO
{
    public class VratiNaslovePoKriterijumuSO : SystemOperationBase
    {
        public List<Naslov> Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetSpecific(entity).Cast<Naslov>().ToList();
        }
    }
}
