using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceDepartamento" in both code and config file together.
    [ServiceContract]
    public interface IServiceDepartamento
    {
         [OperationContract]
        Result AddDepartamento(ML.Departamento departamento);

        [OperationContract]
         Result UpdateDepartamento(ML.Departamento departamento);

        [OperationContract]
        Result DeleteDepartamento(int IdDepartamento);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Departamento))]
        Result GetAllDepartamento();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Departamento))]
        Result GetByIdDepartamento(int IdDepartamento);
    }
   
   
}
