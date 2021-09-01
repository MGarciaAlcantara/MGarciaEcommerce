using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceProducto
    { [OperationContract]
        Result AddProducto(ML.Producto producto);

        [OperationContract]
    Result UpdateProducto(ML.Producto producto);

        [OperationContract]
        Result DeleteProducto(int IdProducto);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))]
        Result GetAllProducto();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))]
        Result GetByIdProducto(int IdProducto);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    [DataContract]
    public class Result
    {

        [DataMember]
        public bool Correct { get; set; }

        [DataMember]
        public object Object { get; set; }

        [DataMember]
        public List<object> Objects { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public Exception Ex { get; set; }
    }
}
