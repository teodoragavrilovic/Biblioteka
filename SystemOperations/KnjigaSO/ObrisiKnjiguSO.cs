﻿using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.KnjigaSO
{
    public class ObrisiKnjiguSO : SystemOperationBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            repository.Update((Knjiga)entity);
        }
    }
}
