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
    public class Knjiga : IEntity
    {
        public int PrimerakID { get; set; }
        public string ISBN { get; set; }
        public int Godina { get; set; }
        public Izdavac Izdavac { get; set; }
        public Naslov Naslov { get; set; }
        public bool Aktuelna { get; set; }
        public bool Dostupna { get; set; }
        [Browsable(false)]
        public string TableName => "Knjiga";
        [Browsable(false)]
        public string InsertValues => $"'{ISBN}','{Naslov.NaslovID}','{Izdavac.IzdavacID}','{Godina}','{Aktuelna}','{Dostupna}'";
        [Browsable(false)]
        public string IdName => "PrimerakID";
        [Browsable(false)]
        public string JoinCondition => "ON (K.NaslovID = N.NaslovID) JOIN Izdavac I ON (K.IzdavacID = I.IzdavacID) JOIN Autor A ON (A.AutorID = N.AutorID) JOIN Zanr Z ON (Z.ZanrID = N.ZanrID)";
        [Browsable(false)]
        public string JoinTable => $"JOIN Naslov N";
        [Browsable(false)]
        public string TableAlias => "K";
        [Browsable(false)]
        public object SelectValues => "*";
        [Browsable(false)]
        public string WhereCondition => $"PrimerakID = {PrimerakID}";

        [Browsable(false)]
        public string GCondition;
        [Browsable(false)]
        public string GetUpdateValues => $"{GCondition}";
        [Browsable(false)]
        public string GeneralCondition => $"{GCondition}";
        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                result.Add(new Knjiga
                {
                    PrimerakID = (int)reader[0],
                    ISBN = (string)reader[1],
                    Godina = (int)reader[4],
                    Aktuelna = (bool)reader[5],
                    Dostupna = (bool)reader[6],
                    Naslov = new Naslov()
                    {
                        Autor = new Autor() {
                            AutorID = (int)reader[9],
                            ImePrezime = (string)reader[14],
                            
                        },
                        Zanr = new Zanr()
                        {
                            ZanrID = (int)reader[10],
                            NazivZanra = (string)reader[16]
                        },
                        Naziv = (string)reader[8],
                        NaslovID = (int)reader[2]
                    },
                    Izdavac = new Izdavac()
                    {
                        IzdavacID = (int)reader[3],
                        NazivIzdavaca = (string)reader[12]

                    }

                }); 
            }
            return result;

        }
        public override string ToString()
        {
            return Naslov.Naziv + " šifra: " + PrimerakID;
        }

    }
}
