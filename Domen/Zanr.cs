using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Zanr : IEntity
    {
        [Browsable(false)]
        public int ZanrID { get; set; }
        public string NazivZanra { get; set; }
        [Browsable(false)]
        public string TableName => "Zanr";
        [Browsable(false)]
        public string InsertValues => throw new NotImplementedException();
        [Browsable(false)]
        public string IdName => "ZanrID";
        [Browsable(false)]
        public string JoinCondition => "";
        [Browsable(false)]
        public string JoinTable =>"";
        [Browsable(false)]
        public string TableAlias => "Z";
        [Browsable(false)]
        public object SelectValues => "*";
        [Browsable(false)]
        public string WhereCondition => "";
        [Browsable(false)]
        public string GetUpdateValues => "";

        [Browsable(false)]
        public string GeneralCondition => "";
        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                result.Add(new Zanr
                {
                    ZanrID= (int)reader[0],
                    NazivZanra = (string)reader[1],
                    
                });
            }
            return result;
        }
        public override string ToString()
        {
            return NazivZanra;
        }
    }
}
