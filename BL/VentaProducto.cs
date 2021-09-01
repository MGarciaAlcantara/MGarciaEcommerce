using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class VentaProducto
    {
        public static ML.Result AddSP(ML.VentaProducto ventaProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        
                        string Query = "VentaProductoAdd";
                        cmd.CommandText = Query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] Collection = new SqlParameter[3];
                        Collection[0] = new SqlParameter("IdVenta", SqlDbType.Int);
                        Collection[0].Value = ventaProducto.Venta.IdVenta;

                        Collection[1] = new SqlParameter("Cantidad", SqlDbType.Decimal);
                        Collection[1].Value = ventaProducto.Cantidad;

                        Collection[2] = new SqlParameter("IdProducto", SqlDbType.Int);
                        Collection[2].Value = ventaProducto.Producto.IdProducto;

                        cmd.Parameters.AddRange(Collection);

                        context.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true; ;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Error al modificar la ventaProducto";
                        }

                    }

                }

            }
            catch (Exception ex)
            {

                result.Correct = false;

                result.ErrorMessage = ex.Message;

            }



            return result;

        }
  
        public static ML.Result AddEF(ML.VentaProducto ventaProducto){
            ML.Result result = new ML.Result();
            try { 
            
                using(DL_EF.MGarciaEcommerceEntities context =new DL_EF.MGarciaEcommerceEntities())
                {
                    var query=context.VentaProductoAdd(ventaProducto.Venta.IdVenta,ventaProducto.Cantidad,ventaProducto.Producto.IdProducto);
                }
            

            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        
        
        }
    
    
    
    }


}
