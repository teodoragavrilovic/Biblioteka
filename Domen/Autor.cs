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
    public class Autor : IEntity
    {
        [Browsable(false)]
        public int AutorID { get; set; }
        public string ImePrezime { get; set; }
        [Browsable(false)]
        public string TableName => "Autor";

        [Browsable(false)]
        public string InsertValues =>"";
        [Browsable(false)]
        public string IdName => "AutorID";
        [Browsable(false)]
        public string JoinCondition => "";
        [Browsable(false)]
        public string JoinTable => "";
        [Browsable(false)]
        public string TableAlias => "A";
        [Browsable(false)]
        public object SelectValues => "*";
        [Browsable(false)]
        public string WhereCondition => "";
        [Browsable(false)]
        public string GetUpdateValues =>"";
        [Browsable(false)]
        public string GeneralCondition => "";
        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                result.Add(new Autor
                {
                    AutorID = (int)reader[0],
                   ImePrezime = (string)reader[1],
                   

                });
            }
            return result;
        }

        public override string ToString()
        {
            return ImePrezime;
        }
    }
}
