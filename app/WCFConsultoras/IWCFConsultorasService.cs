using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Contracts;
using Contracts.Requests;
using Contracts.Responses;
using NameSpaces;

namespace WCFConsultoras
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCFConsultorasService" in both code and config file together.
   [ServiceContract(Namespace = ConstNameSpaces.ServiceRoot, SessionMode = SessionMode.Allowed)]
    public interface IWCFConsultorasService
    {
       [OperationContract]
       GetConsultorasResponse get_consultoras(GetConsultorasRequest request);

        [OperationContract]
        GetConsultoraResponse get_consultora(GetConsultoraRequest request);

        [OperationContract]
        string get_prueba();
    }

}
