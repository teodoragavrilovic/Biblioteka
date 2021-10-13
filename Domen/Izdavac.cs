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
    public class Izdavac : IEntity
    {
        [Browsable(false)]
        public int IzdavacID { get; set; }
        public string NazivIzdavaca { get; set; }
        [Browsable(false)]
        public string TableName => "Izdavac";
        [Browsable(false)]
        public string InsertValues => "";
        [Browsable(false)]
        public string IdName => "IzdavacID";
        [Browsable(false)]
        public string JoinCondition => "";
        [Browsable(false)]
        public string JoinTable =>"";
        [Browsable(false)]
        public string TableAlias => "I";
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
                result.Add(new Izdavac
                {
                    IzdavacID = (int)reader[0],
                    NazivIzdavaca = (string)reader[1],

                });
            }
            return result;
        }
        public override string ToString()
        {
            return NazivIzdavaca;
        }
    }
}
