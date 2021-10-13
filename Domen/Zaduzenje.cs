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
    public class Zaduzenje : IEntity
    {

        public int BrojZaduzenja { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public string Napomena { get; set; }
        public Clan Clan { get; set; }
        public Knjiga Knjiga { get; set; }
        public bool Vracena { get; set; }
        [Browsable(false)]
        public string TableName => "Zaduzenje";
        [Browsable(false)]
        public string InsertValues => $"'{DatumOd}','{DatumDo}','{Napomena}','{Clan.BrojClanskeKarte}', '{Knjiga.PrimerakID}', '{Vracena}'";
        [Browsable(false)]
        public string IdName => "BrojZaduzenja";
        [Browsable(false)]
        public string JoinCondition => "ON (C.BrojClanskeKarte = ZD.ClanID) JOIN Knjiga K ON (K.PrimerakID = ZD.PrimerakID)";
        [Browsable(false)]
        public string JoinTable => $"JOIN Clan C";
        [Browsable(false)]
        public string TableAlias => "ZD";
        [Browsable(false)]
        public object SelectValues => "*";
        [Browsable(false)]
        public string WhereCondition => $"PrimerakID = {Knjiga.PrimerakID} AND ClanID = {Clan.BrojClanskeKarte}"; //$"BrojZaduzenja = {BrojZaduzenja}";

        [Browsable(false)]
        public string GCondition;
        [Browsable(false)]
        public string GetUpdateValues => $"Vracena = 1";
        [Browsable(false)]
        public string GeneralCondition => $"{GCondition}";
        [Browsable(false)]
        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                result.Add(new Zaduzenje
                {
                    BrojZaduzenja = (int)reader[0],
                    DatumOd = (DateTime)reader[1],
                    DatumDo = (DateTime)reader[2],
                    Napomena = (string)reader[3],
                    Clan = new Clan
                    {
                        BrojClanskeKarte = (int)reader[4],
                    },
                    Knjiga = new Knjiga
                    {
                        PrimerakID =(int)reader[5],
                    },
                    Vracena = (bool)reader[6]
                });
            }
            return result;
        }
    }
}
