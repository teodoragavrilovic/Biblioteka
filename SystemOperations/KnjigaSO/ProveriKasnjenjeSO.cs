using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.KnjigaSO
{
    public class ProveriKasnjenjeSO : SystemOperationBase
    {
        public bool Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            List<Zaduzenje> lista = new List<Zaduzenje>();

            lista = repository.GetSpecific(entity).Cast<Zaduzenje>().ToList();
            if (lista[0].DatumDo > DateTime.Now)
                Result = true;
            else
                Result = false;

        }
    }
}
