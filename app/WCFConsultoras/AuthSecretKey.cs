using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WCFConsultoras
{
    class AuthSecretKey
    {

        Conexion MiConexion = new Conexion();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
        bool vexito = false;

        public bool validar(string secretkey)
        {
           

             const string sKy = "lkirwf897+22#bbtrm8814z5qq=498j5"; //32 chr shared ascii string (32 * 8 = 256 bit)
             const string sIV = "741952hheeyy66#cs!9hjv887mxx7@8y"; //32 chr shared ascii string (32 * 8 = 256 bit)
            
                 if (!string.IsNullOrEmpty(secretkey))
                 {
                     string sk = Crypter.DecryptRJ256(sKy, sIV, secretkey);

                     return consultarKey(sk);
                 }
                 else
                 {
                     return false;
                 }
           
        }

        public bool consultarKey(string sk)
        {
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx("MASTER");
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPLMS_Obtener_Aplicaciones";

                //Agregamos el parametro para el SP
                cmd.Parameters.Add(new SqlParameter("@secretKey", SqlDbType.NVarChar, 128));
                cmd.Parameters["@secretKey"].Value = sk;
                cnx.Open();
                dtr = cmd.ExecuteReader();

                if (dtr.HasRows == true)
                {
                    return vexito=true;
                }
            }
            catch (SqlException ex)
            {
                return vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }

            return vexito;

            

        }

    }
}
