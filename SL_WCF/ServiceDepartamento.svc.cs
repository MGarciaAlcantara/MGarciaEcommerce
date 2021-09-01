using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceDepartamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceDepartamento.svc or ServiceDepartamento.svc.cs at the Solution Explorer and start debugging.
    public class ServiceDepartamento : IServiceDepartamento
    {
       
        public Result AddDepartamento(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.AddEF(departamento);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };

        }
        public Result UpdateDepartamento(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.UpdateEF(departamento);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };

        }
        public Result DeleteDepartamento(int IdDepartamento)
        {
            ML.Result result = BL.Departamento.DeleteEF(IdDepartamento);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };

        }
        public Result GetAllDepartamento()
        {

            ML.Result result = BL.Departamento.GetAllEF();

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Objects = result.Objects };

        }
        public Result GetByIdDepartamento(int IdDepartamento)
        {

            ML.Result result = BL.Departamento.GetByIdEF(IdDepartamento);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object };

        }
    }
}
