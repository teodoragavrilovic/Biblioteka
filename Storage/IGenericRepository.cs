using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IGenericRepository
    {
        void Save(IEntity entity);
        void Update(IEntity entity);
        List<IEntity> GetAll(IEntity e);
        int GetNewId(IEntity e);
        List<IEntity> GetSpecific(IEntity entity);
        void OpenConnection();
        void CloseConnection();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
