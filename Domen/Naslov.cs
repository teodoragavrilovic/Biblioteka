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
    public class Naslov : IEntity
    {
        [Browsable(false)]
        public int NaslovID { get; set; }
        public string Naziv { get; set; }
       
        public Zanr Zanr { get; set; }
     

        public Autor Autor { get; set; }
        [Browsable(false)]
        public string TableName => "Naslov";
        [Browsable(false)]
        public string InsertValues => $"'{Naziv}','{Autor.AutorID}','{Zanr.ZanrID}'";
        [Browsable(false)]
        public string IdName =>"NaslovID";
        [Browsable(false)]
        public string JoinCondition => $"ON (N.ZanrID = Z.ZanrID) JOIN Autor A ON (N.AutorID = A.AutorID)";
        [Browsable(false)]
        public string JoinTable => $"JOIN Zanr Z";
        [Browsable(false)]
        public string TableAlias => "N";
        [Browsable(false)]
        public object SelectValues => "*";
        [Browsable(false)]
        public string WhereCondition => "";
        [Browsable(false)]
        public string GetUpdateValues => "";
        [Browsable(false)]
        public string GCondition;
        [Browsable(false)]
        public string GeneralCondition => $"{GCondition}";
        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                result.Add(new Naslov
                {
                    NaslovID = (int)reader[0],
                    Naziv = (string)reader[1],
                    Autor = new Autor()
                    {
                        AutorID = (int)reader[2],
                        ImePrezime = (string)reader[7],
                        //Prezime = (string)reader[8]
                    },
                    Zanr = new Zanr()
                    {
                        ZanrID = (int)reader[3],
                        NazivZanra = (string)reader[5]
                    }
                    
                });
            }
            return result;
        }
        public override string ToString()
        {
            return Naziv;
        }

    }
}
