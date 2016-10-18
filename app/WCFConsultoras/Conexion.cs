using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WCFConsultoras
{
    class Conexion
    {
        

        public string GetCnx(string pais)
        {
            string strCnx = ConfigurationManager.ConnectionStrings[pais].ConnectionString;
           
            if (object.ReferenceEquals(strCnx, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strCnx;
            }
          
           
        }



        
        
    }
}
