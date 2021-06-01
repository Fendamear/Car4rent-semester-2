using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Car4Rent.Interfaces;
using Car4Rent.Interfaces.Interfaces;


namespace Car4Rent.DAL
{
    public class AutoDAL : IAutoDAL
    {
        private DatabaseDAL dbs = new DatabaseDAL();

        public List<AutoDTO> GetAll(string begindatum, string einddatum)
        {
            SqlCommand getAutos = new SqlCommand($"select AutoID, merk,type_,KM_stand,Kenteken,Bouwjaar,Brandstof, Zitplaatsen, Versnellingsbak, url_, prijs from Auto_ " +
                                                 $"where AutoID not in (select distinct a.AutoID from Auto_ a left join boeking b on b.AutoID = a.AutoID " +
                                                 $"where '{begindatum}' <= b.Einddatum and b.Begindatum <= '{einddatum}')");

            getAutos.Parameters.AddWithValue("@Datum1", begindatum);
            getAutos.Parameters.AddWithValue("@Datum2", einddatum);

            DataTable dataTable = dbs.Query(getAutos);
            List<AutoDTO> autoDTOs = new List<AutoDTO>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                AutoDTO autoDTO = new AutoDTO();
                autoDTOs.Add(AutoDTOfill(autoDTO, dataRow));
            }

            return autoDTOs;
        }

        public List<AutoDTO> GetAllByGebruiker(int id)
        {
            SqlCommand getAllByGebruiker = new SqlCommand($"select AutoID, VerhuurderID, merk, Type_, KM_stand, Kenteken, Bouwjaar, Brandstof, Zitplaatsen, Versnellingsbak, url_, prijs from Auto_ " +
                                                          $"where verhuurderID = @id");

            getAllByGebruiker.Parameters.AddWithValue("@id", id);

            DataTable dataTable = dbs.Query(getAllByGebruiker);
            List<AutoDTO> autoDTOs = new List<AutoDTO>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                AutoDTO autoDTO = new AutoDTO();
                autoDTOs.Add(AutoDTOfill(autoDTO, dataRow));
            }

            return autoDTOs;
        }

        public AutoDTO GetByID(int autoID)
        {
            SqlCommand getCar = new SqlCommand("select AutoID, merk,type_,KM_stand,Kenteken,Bouwjaar,Brandstof, Zitplaatsen, Versnellingsbak, url_, prijs from Auto_  WHERE AutoID = @AutoID");

            getCar.Parameters.AddWithValue("@AutoID", autoID);

            DataTable dataTable = dbs.Query(getCar);
            AutoDTO autoDTO = new AutoDTO();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                autoDTO = AutoDTOfill(autoDTO, dataRow);
            }

            return autoDTO;
        }

        private AutoDTO AutoDTOfill(AutoDTO autoDTO, DataRow dataRow)
        {
            autoDTO.autoID = Convert.ToInt32(dataRow["AutoID"]);
            autoDTO.type = Convert.ToString(dataRow["type_"]);
            autoDTO.Merk = Convert.ToString(dataRow["merk"]);
            autoDTO.Kenteken = Convert.ToString(dataRow["Kenteken"]);
            autoDTO.KM_stand = Convert.ToInt32(dataRow["KM_stand"]);
            autoDTO.bouwjaar = Convert.ToInt32(dataRow["bouwjaar"]);
            autoDTO.Brandstof = Convert.ToString(dataRow["Brandstof"]);
            autoDTO.Zitplaatsen = Convert.ToInt32(dataRow["Zitplaatsen"]);
            autoDTO.Versnellingsbak = Convert.ToString(dataRow["versnellingsbak"]);
            autoDTO.prijs = Convert.ToDecimal(dataRow["prijs"]);
            autoDTO.Url = Convert.ToString(dataRow["url_"]);

            return autoDTO;
        }

        public void AutoToevoegen(AutoDTO autoDTO)
        {
            var Autotoevoegen = new SqlCommand($"INSERT INTO Auto_ (AutoID, VerhuurderID, merk, Type_, KM_stand, Kenteken, Bouwjaar, Brandstof, Zitplaatsen, Versnellingsbak, url_, prijs) " +
                                               $"VALUES (@AutoID, @VerhuurderID, @merk, @Type_, @KM_stand, @kenteken, @bouwjaar, @Brandstof, @Zitplaatsen, @Versnellingsbak, @url_, @prijs);");

            var query = new SqlCommand($"select MAX(AutoID) as AutoID from Auto_");
            string column = "AutoID";

            Autotoevoegen.Parameters.AddWithValue("@AutoID", dbs.GetMaxID(query, column));
            Autotoevoegen.Parameters.AddWithValue("@VerhuurderID", 1);
            Autotoevoegen.Parameters.AddWithValue("@merk", autoDTO.Merk);
            Autotoevoegen.Parameters.AddWithValue("@Type_", autoDTO.type);
            Autotoevoegen.Parameters.AddWithValue("@KM_stand", autoDTO.KM_stand);
            Autotoevoegen.Parameters.AddWithValue("@Kenteken", autoDTO.Kenteken);
            Autotoevoegen.Parameters.AddWithValue("@Bouwjaar", autoDTO.bouwjaar);
            Autotoevoegen.Parameters.AddWithValue("@Brandstof", autoDTO.Brandstof);
            Autotoevoegen.Parameters.AddWithValue("@Zitplaatsen", autoDTO.Zitplaatsen);
            Autotoevoegen.Parameters.AddWithValue("@Versnellingsbak", autoDTO.Versnellingsbak);
            Autotoevoegen.Parameters.AddWithValue("@url_", autoDTO.Url);
            Autotoevoegen.Parameters.AddWithValue("@prijs", autoDTO.prijs);

            dbs.ExecuteQuery(Autotoevoegen);
        }

        public void Delete(int AutoID)
        {
            SqlCommand deleteProduct = new SqlCommand($"Delete FROM Auto_" +
                                                      $"where AutoID = @AutoID");

            deleteProduct.Parameters.AddWithValue("@AutoID", AutoID);

            dbs.ExecuteQuery(deleteProduct);
        }
    }
}
