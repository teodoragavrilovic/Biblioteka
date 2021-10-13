using DatabaseBroker;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Implementation.SqlServer
{
    public class GenericRepository : IGenericRepository
    {
        private Broker broker = new Broker();
        public void BeginTransaction()
        {
            broker.BeginTransaction();
        }

        public void CloseConnection()
        {
            broker.CloseConnection();
        }
        public List<IEntity> GetSpecific(IEntity entity)
        {
            return broker.GetSpecific(entity);
        }
        public void Commit()
        {
            broker.Commit();
        }

        public List<IEntity> GetAll(IEntity entity)
        {
            return broker.GetAll(entity);
        }

        public int GetNewId(IEntity e)
        {
            return broker.GetNewId(e);
        }

        public void OpenConnection()
        {
            broker.OpenConnection();
        }

        public void Rollback()
        {
            broker.Rollback();
        }

        public void Save(IEntity entity)
        {
            broker.Save(entity);
        }
        public void Update(IEntity entity)
        {
            broker.Update(entity);
        }
    }
}
