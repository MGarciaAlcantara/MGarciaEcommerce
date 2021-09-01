using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Objects;

using System.Data.SqlClient;

namespace BL
{
  public  class Venta
    {
        public static ML.Result AddSP(ML.Venta venta, List<object> Objects) {
            ML.Result result = new ML.Result();
        
          try{  using (SqlConnection context= new SqlConnection(DL.Conexion.GetConnectionString())){

                using (SqlCommand cmd=new SqlCommand()){
                
                string Query="VentaAdd";
                      cmd.CommandText=Query;
                      cmd.Connection = context;
                      cmd.CommandType = CommandType.StoredProcedure;
                  
                  SqlParameter[] Collection = new SqlParameter[4];
                        Collection[0] = new SqlParameter("IdCliente", SqlDbType.Int);
                        Collection[0].Value = venta.Cliente.IdCliente;
                    
                        Collection[1] = new SqlParameter("Total", SqlDbType.Decimal);
                        Collection[1].Value = venta.Total;       
                       
                        Collection[2] = new SqlParameter("IdMetodoPago", SqlDbType.Int);
                        Collection[2].Value = venta.MetodoPago.IdMetodoPago;

                        Collection[3] = new SqlParameter("IdVenta", SqlDbType.Int);
                        Collection[3].Direction = ParameterDirection.Output;
                        //cmd.Parameters.AddWithValue("@IdVenta", SqlDbType.Int).Direction = ParameterDirection.Output;
                
                        cmd.Parameters.AddRange(Collection);
                       
                        context.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        venta.IdVenta = Convert.ToByte(cmd.Parameters["IdVenta"].Value);

                     foreach(ML.VentaProducto ventaproducto in Objects)
                     {
                            ventaproducto.Venta=new ML.Venta();
                            ventaproducto.Venta.IdVenta=venta.IdVenta;                       

                         BL.VentaProducto.AddSP(ventaproducto);
                    }

                        if (RowsAffected > 0)
                        {
                          Console.WriteLine("ID ingresado es " + venta.IdVenta);
                          
                            result.Correct = true; ;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Error al modificar la venta";
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

        public static ML.Result AddEF(ML.Venta venta, List<object> Objects)
        {
            System.Data.Entity.Core.Objects.ObjectParameter idVenta = new System.Data.Entity.Core.Objects.ObjectParameter("IdVenta", typeof(byte));
            ML.Result result = new ML.Result();
           try
           {
              using(DL_EF.MGarciaEcommerceEntities context =new DL_EF.MGarciaEcommerceEntities())
              {


                  var query = context.VentaAdd(venta.Cliente.IdCliente, venta.Total, venta.MetodoPago.IdMetodoPago, idVenta);
                                                   
                  if (query>0)
                  {
                      venta.IdVenta = (byte)idVenta.Value;

                    
                      foreach (ML.VentaProducto ventaproducto in Objects)
                      {
                           
                             
                          ventaproducto.Venta = new ML.Venta();
                          ventaproducto.Venta.IdVenta = venta.IdVenta;
                          ventaproducto.Producto.Stock=(byte) (ventaproducto.Producto.Stock - ventaproducto.Cantidad);

                          result=BL.Producto.UpdateEF(ventaproducto.Producto);
                         
                          
                      }
                      result.Correct = true;
                  }
                  else
                   {
                      result.Correct = false;
                      result.ErrorMessage = "Error al insertar venta";
                  }
                 
              }

           }
           catch(Exception ex)
           {
               result.Correct = false;
               result.ErrorMessage = ex.Message;

           }

           return result;


        }

      

        ML.Result result = new ML.Result();
     
         }


}
