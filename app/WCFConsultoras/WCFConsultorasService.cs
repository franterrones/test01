using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Contracts.Requests;
using Contracts.Responses;
using DataTransferObjects;
using DataTransferObjects.ConsultorasService;
using System.Text;
using WCFConsultoras.Helpers;


namespace WCFConsultoras
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class WCFConsultorasService : IWCFConsultorasService
    {

        AuthSecretKey auth = new AuthSecretKey();
        Conexion MiConexion = new Conexion();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr = default(SqlDataReader);


        public GetConsultorasResponse get_consultoras(GetConsultorasRequest request)
        {
            List<Consultoras> Listconsultoras = new List<Consultoras>();

            if (auth.validar(request.SecretKey))
            {

                try
                {
                    cnx.ConnectionString = MiConexion.GetCnx(request.Pais);
                    cmd.Connection = cnx;
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cambiar el procedimiento almacenado por el que se usara.
                    cmd.CommandText = "SPLMS_Obtener_Consultoras";
                    cnx.Open();
                    dtr = cmd.ExecuteReader();

                    if (dtr.HasRows == true)
                    {
                        while (dtr.Read())
                        {
                            Consultoras objConsult = new Consultoras();

                            objConsult.isocodconsultora = dtr.GetValue(dtr.GetOrdinal("isoCodConsultora")).ToString();
                            objConsult.nombrecompleto = dtr.GetValue(dtr.GetOrdinal("NombreCompleto")).ToString();
                            objConsult.email = dtr.GetValue(dtr.GetOrdinal("eMail")).ToString();
                            objConsult.region = dtr.GetValue(dtr.GetOrdinal("region")).ToString();
                            objConsult.zona = dtr.GetValue(dtr.GetOrdinal("zona")).ToString();
                            objConsult.segmento = dtr.GetValue(dtr.GetOrdinal("segmento")).ToString();
                            objConsult.seccion = dtr.GetValue(dtr.GetOrdinal("seccion")).ToString();
                            objConsult.esconsultoralider = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("esConsultoraLider")).ToString());
                            objConsult.codigonivellider = dtr.GetValue(dtr.GetOrdinal("CodigoNivelLider")).ToString();
                            objConsult.campaniainiciolider = dtr.GetValue(dtr.GetOrdinal("CampaniaInicioLider")).ToString();
                            objConsult.secciongestionlider = dtr.GetValue(dtr.GetOrdinal("SeccionGestionLider")).ToString();
                            objConsult.nivelproyectado = dtr.GetValue(dtr.GetOrdinal("NivelProyectado")).ToString();
                            
                            Listconsultoras.Add(objConsult);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Excepcion: "+ ex.Message);
                }
                finally
                {
                    if (cnx.State == ConnectionState.Open)
                    {
                        cnx.Close();
                    }
                }

                var result = Listconsultoras.AsPagination<Consultoras>(request);
                return new GetConsultorasResponse() { ResultList = new Pagination<Consultoras>(result) };
            }
            else
            {
              throw new Exception("Error: clave secreta incorrecta");
            }

          
           
        }

        public GetConsultoraResponse get_consultora(GetConsultoraRequest request)
        {
            List<Consultoras> Listconsultoras = new List<Consultoras>();

            if (auth.validar(request.SecretKey))
            {

                try
                {
                    cnx.ConnectionString = MiConexion.GetCnx(request.Pais);
                    cmd.Connection = cnx;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SPLMS_Get_Consultora";
                    cmd.Parameters.Add("@CodigoConsultora", SqlDbType.VarChar).Value = request.CodConsultora;
                    cnx.Open();
                    dtr = cmd.ExecuteReader();

                    if (dtr.HasRows == true)
                    {
                        while (dtr.Read())
                        {
                            Consultoras objConsult = new Consultoras();

                            objConsult.isocodconsultora = dtr.GetValue(dtr.GetOrdinal("isoCodConsultora")).ToString();
                            objConsult.nombrecompleto = dtr.GetValue(dtr.GetOrdinal("NombreCompleto")).ToString();
                            objConsult.email = dtr.GetValue(dtr.GetOrdinal("eMail")).ToString();
                            objConsult.region = dtr.GetValue(dtr.GetOrdinal("region")).ToString();
                            objConsult.zona = dtr.GetValue(dtr.GetOrdinal("zona")).ToString();
                            objConsult.segmento = dtr.GetValue(dtr.GetOrdinal("segmento")).ToString();
                            objConsult.seccion = dtr.GetValue(dtr.GetOrdinal("seccion")).ToString();
                            objConsult.esconsultoralider = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("esConsultoraLider")).ToString());
                            objConsult.codigonivellider = dtr.GetValue(dtr.GetOrdinal("CodigoNivelLider")).ToString();
                            objConsult.campaniainiciolider = dtr.GetValue(dtr.GetOrdinal("CampaniaInicioLider")).ToString();
                            objConsult.secciongestionlider = dtr.GetValue(dtr.GetOrdinal("SeccionGestionLider")).ToString();
                            objConsult.nivelproyectado = dtr.GetValue(dtr.GetOrdinal("NivelProyectado")).ToString();

                            Listconsultoras.Add(objConsult);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Excepcion: " + ex.Message);
                }
                finally
                {
                    if (cnx.State == ConnectionState.Open)
                    {
                        cnx.Close();
                    }
                }

                var result = Listconsultoras.AsPagination<Consultoras>(request);
                return new GetConsultoraResponse() { ResultList = new Pagination<Consultoras>(result) };
            }
            else
            {
                throw new Exception("Error: clave secreta incorrecta");
            }



        }

        public string get_prueba()
        {
            return "Hola, mundo!";
        }
    }
}
