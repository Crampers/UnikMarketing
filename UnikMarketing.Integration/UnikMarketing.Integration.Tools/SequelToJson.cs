using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using UnikMarketing.Integration.Tools.Extensions;
using UnikMarketing.Integration.Tools.Models;

namespace UnikMarketing.Integration.Tools
{
    public class SequelToJson
    {
        #region Sql
        private const string RentalSql = @"
        SELECT 
            us.UdlejningsSagId
            , us.Titel 
            , us.Beskrivelse
            , us.Depositum
            , us.ForudbetaltLeje
            , us.LinkTilProspekt
            , us.GyldigFraDato
            , us.GyldigTilDato
            , us.LedigPrDato
            , us.VisesPaaNettet
            , us.UdlejningKommentar
            , us.StatusGodkendt
            , us.StatusGodkendtBrugerInit
            , us.StatusGodkendtDato
            , us.StatusProspektAjourfoert
            , le.Adresse1 
            , le.Adresse2
        FROM UdlejningsSag us
        INNER JOIN UdlejningsSagTomgang uts ON uts.UdlejningsSagId = us.UdlejningsSagId
            INNER JOIN Lejer lej ON lej.LejerId = uts.LejerId
            INNER JOIN Lejemaal le ON
        le.SelskabNr = lej.SelskabNr AND
        le.EjendomNr = lej.EjendomNr AND
        le.LejemaalNr = lej.LejemaalNr";
        #endregion

        private static SqlCommand CreateRentalCommand(SqlConnection sqlConnection)
        {
            return new SqlCommand(RentalSql, sqlConnection);
        }

        private static ICollection<RentalObjectDto> GetAll(SqlConnection sqlConnection)
        {
            List<RentalObjectDto> result = new List<RentalObjectDto>();
            sqlConnection.Open();
            using (SqlDataReader dataReader = CreateRentalCommand(sqlConnection).ExecuteReader())
            {
                    foreach (IDataRecord dataRecord in dataReader)
                    {
                        result.Add(new RentalObjectDto
                        {
                            RentalObjectId = (int) dataRecord["UdlejningsSagId"],
                            Titel = (string) dataRecord["Titel"],
                            Description = dataRecord.SafeGetString("Beskrivelse"),
                            Deposit = dataRecord.SafeGetDecimal("Depositum"),
                            PrepaidRent = dataRecord.SafeGetDecimal("ForudbetaltLeje"),
                            LinkToProspect = dataRecord.SafeGetString("LinkTilProspekt"),
                            FromDate = dataRecord.SafeGetDateTime("GyldigFraDato"),
                            ToDate = dataRecord.SafeGetDateTime("GyldigTilDato"),
                            AvailableFromDate = dataRecord.SafeGetDateTime("LedigPrDato"),
                            ShowOnSite = (bool) dataRecord["VisesPaaNettet"],
                            AppartmentComment = dataRecord.SafeGetString("UdlejningKommentar"),
                            StatusProved = (bool) dataRecord["StatusGodkendt"],
                            StatusApprovedInitials = dataRecord.SafeGetString("StatusGodkendtBrugerInit"),
                            StatusApprovedDate = dataRecord.SafeGetDateTime("StatusGodkendtDato"),
                            StatusProspectUpToDate = (bool) dataRecord["StatusProspektAjourfoert"],
                            Address1 = dataRecord.SafeGetString("Adresse1"),
                            Address2 = dataRecord.SafeGetString("Adresse2")
                        });
                    }
            }
            return result;
        }

        public static string GetJson(string connectionString)
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
                return JsonConvert.SerializeObject(GetAll(sqlConn));
        }
    }
}