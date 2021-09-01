using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;



namespace BL
{
    public class Producto
    {
        public static ML.Result GetAll()
        {
            Console.WriteLine("---------------------------------------Metodo sin SP--------------------------------------");
            Console.WriteLine("");

            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string Query = "SELECT IdProducto,	Nombre,	Precio,	Stock,	IdProveedor,IdDepartamento,	Descripcion FROM Producto";

                        cmd.CommandText = Query;
                        cmd.Connection = context;
                     

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable tableProducto = new DataTable();
                        da.Fill(tableProducto);

                        context.Open();

                        
                        if (tableProducto.Rows.Count > 0)
                        {

                            result.Objects = new List<object>();

                            foreach(DataRow row in tableProducto.Rows){

                                ML.Producto producto = new ML.Producto();

                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.Precio = decimal.Parse(row[2].ToString());
                                producto.Stock = byte.Parse(row[3].ToString());
                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor = int.Parse(row[4].ToString());
                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());
                                producto.Descripcion = row[6].ToString();

                                result.Objects.Add(producto);

                            
                            }

                            result.Correct = true;
                          

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla";
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

        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            Console.WriteLine("---------------------------------------Metodo sin SP--------------------------------------");
            Console.WriteLine("");


            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string Query = "INSERT INTO [Producto]([Nombre],[Precio],[Stock],[IdProveedor],[IdDepartamento],[Descripcion]) VALUES(@Nombre,@Precio, @Stock,@IdProveedor,@IdDepartamento,@Descripcion)";

                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[6];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("Precio", SqlDbType.Decimal);
                        collection[1].Value = producto.Precio;

                        collection[2] = new SqlParameter("Stock", SqlDbType.TinyInt);
                        collection[2].Value =producto.Stock;

                        collection[3] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[3].Value = producto.Proveedor.IdProveedor;

                        collection[4] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[4].Value = producto.Departamento.IdDepartamento;

                        collection[5] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;

                        
                        cmd.Parameters.AddRange(collection);

                        context.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al realizar la insercción del producto";
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

        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
          
            Console.WriteLine("---------------------------------------Metodo sin SP--------------------------------------");
            Console.WriteLine("");

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string Query = "Update Producto set Nombre=@Nombre, Precio =@Precio, Stock=@Stock,IdProveedor=@IdProveedor, IdDepartamento = @IdDepartamento, Descripcion=@Descripcion where IdProducto=@IdProducto;";

                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[7];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("Precio", SqlDbType.Decimal);
                        collection[1].Value = producto.Precio;

                        collection[2] = new SqlParameter("Stock", SqlDbType.TinyInt);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[3].Value = producto.Proveedor.IdProveedor;

                        collection[4] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[4].Value = producto.Departamento;

                        collection[5] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;

                        collection[6] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[6].Value = producto.IdProducto;
                        cmd.Parameters.AddRange(collection);

                        context.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al realizar la actualizacion del producto";
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

        public static ML.Result Delete(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            Console.WriteLine("---------------------------------------Metodo sin SP--------------------------------------");
            Console.WriteLine("");


            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string Query = "delete  from Producto where IdProducto=@IdProducto;";

                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = producto.IdProducto;

                       cmd.Parameters.AddRange(collection);

                        context.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error aleliminar el producto";
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

        public static ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();

            Console.WriteLine("---------------------------------------Metodo con SP--------------------------------------");
            Console.WriteLine("");
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string Query = "ProductoGetAll";

                        cmd.CommandText = Query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable tableProducto = new DataTable();
                        da.Fill(tableProducto);

                        context.Open();


                        if (tableProducto.Rows.Count > 0)
                        {

                            result.Objects = new List<object>();

                            foreach (DataRow row in tableProducto.Rows)
                            {

                                ML.Producto producto = new ML.Producto();

                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.Precio = decimal.Parse(row[2].ToString());
                                producto.Stock = byte.Parse(row[3].ToString());
                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor = int.Parse(row[4].ToString());
                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());
                                producto.Descripcion = row[6].ToString();

                                result.Objects.Add(producto);

                            }

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla";
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

        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();

            Console.WriteLine("---------------------------------------Metodo con SP--------------------------------------");
            Console.WriteLine("");
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string Query = "ProductoGetById";

                        cmd.CommandText = Query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        
                        context.Open();
                        SqlParameter []Collection=new SqlParameter[1];

                        Collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        Collection[0].Value = IdProducto;
                        cmd.Parameters.AddRange(Collection);

                        DataTable departamento = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(departamento);
                        if(departamento.Rows.Count>0)
                        {
                            DataRow row = departamento.Rows[0];
                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto = int.Parse(row[0].ToString());
                            producto.Nombre = row[1].ToString();
                            producto.Precio = decimal.Parse(row[2].ToString());
                            producto.Stock = byte.Parse(row[3].ToString());
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = int.Parse(row[4].ToString());
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());
                            producto.Descripcion = row[6].ToString();

                            result.Object=producto;
                            result.Correct=true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No hay registro con ese ID";
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

        public static ML.Result AddSP(ML.Producto producto)
        {
           
            ML.Result result = new ML.Result();
            Console.WriteLine("---------------------------------------Metodo con SP--------------------------------------");
            Console.WriteLine("");

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string Query = "ProductoAdd";

                        cmd.CommandText = Query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[6];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("Precio", SqlDbType.Decimal);
                        collection[1].Value = producto.Precio;

                        collection[2] = new SqlParameter("Stock", SqlDbType.TinyInt);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[3].Value = producto.Proveedor.IdProveedor;

                        collection[4] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[4].Value = producto.Departamento.IdDepartamento;

                        collection[5] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;


                        cmd.Parameters.AddRange(collection);

                        context.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al realizar la insercción del producto";
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

        public static ML.Result UpdateSP(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            Console.WriteLine("---------------------------------------Metodo con SP--------------------------------------");
            Console.WriteLine("");
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string Query = "ProductoUpdate";
                        cmd.CommandText = Query;

                        cmd.Connection = context;
                        cmd.CommandType=CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[7];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("Precio", SqlDbType.Decimal);
                        collection[1].Value = producto.Precio;

                        collection[2] = new SqlParameter("Stock", SqlDbType.TinyInt);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[3].Value = producto.Proveedor.IdProveedor;

                        collection[4] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[4].Value = producto.Departamento.IdDepartamento;

                        collection[5] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;

                        collection[6] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[6].Value = producto.IdProducto;
                        cmd.Parameters.AddRange(collection);

                        context.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al realizar la actualizacion del producto";
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

        public static ML.Result DeleteSP(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            Console.WriteLine("---------------------------------------Metodo con SP--------------------------------------");
            Console.WriteLine("");
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string Query = "ProductoDelete";

                        cmd.CommandText = Query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = producto.IdProducto;

                        cmd.Parameters.AddRange(collection);

                        context.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error aleliminar el producto";
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

        public static ML.Result GetAllEF()
        {
            Console.WriteLine("METODO GETALL CON ENTITY FRAMEWORK PRODUCTO");
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGarciaEcommerceEntities conexion = new DL_EF.MGarciaEcommerceEntities()) 
                {
                    var query = conexion.ProductoGetAll().ToList();
                    result.Objects=new List<object>();
                    if(query!=null)
                    {                               
                        foreach(var objeto in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = objeto.IdProducto;
                            producto.Nombre = objeto.NombreProducto;
                            producto.Precio = objeto.Precio.Value;
                            producto.Stock = objeto.Stock.Value;
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = objeto.IdDepartamento.Value;
                            producto.Departamento.Nombre = objeto.DepartamentoNombre;
                            producto.Departamento.Area = new ML.Area();
                            producto.Departamento.Area.IdArea = objeto.IdArea.Value;
                            producto.Departamento.Area.Nombre = objeto.NombreArea;
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = objeto.IdProveedor.Value;
                            producto.Proveedor.Nombre = objeto.NombreProveedor;
                            producto.Imagen = objeto.Imagen;                          
                            producto.Descripcion = objeto.Descripcion;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else 
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct=false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }

        public static ML.Result GetByIdEF(int IdProducto)
        {      
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGarciaEcommerceEntities context = new DL_EF.MGarciaEcommerceEntities())
                {
                    ML.Producto producto= new ML.Producto();
                    var query = context.ProductoGetById(IdProducto).FirstOrDefault();

                    if (query != null)
                    {
                        producto.IdProducto = query.IdProducto;
                        producto.Nombre = query.NombreProducto;
                        producto.Precio = query.Precio.Value;
                        producto.Stock = query.Stock.Value;
                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.IdProveedor = query.IdProveedor.Value;
                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.IdDepartamento = query.IdDepartamento.Value;
                        producto.Descripcion = query.Descripcion;
                        producto.Departamento.Area = new ML.Area();
                        producto.Departamento.Area.IdArea = query.IdArea.Value;
                        producto.Imagen = query.Imagen;
                        result.Object = producto;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al consultar";
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

        public static ML.Result AddEF(ML.Producto producto)
        {
      
        ML.Result result =new ML.Result();
        try
        {
            using( DL_EF.MGarciaEcommerceEntities conexion =new DL_EF.MGarciaEcommerceEntities())
            {
                var query = conexion.ProductoAdd(
                    producto.Nombre,
                    producto.Precio,
                    producto.Stock,
                    producto.Proveedor.IdProveedor,
                    producto.Departamento.IdDepartamento,
                    producto.Descripcion,
                    producto.Imagen);
                if (query > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Error al insertar Producto";
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

        public static ML.Result UpdateEF(ML.Producto producto)
        {        
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.MGarciaEcommerceEntities connection =new DL_EF.MGarciaEcommerceEntities())
                {
                    var query = connection.ProductoUpdate(
                        producto.IdProducto,
                        producto.Nombre,
                        producto.Precio,
                        producto.Stock,
                        producto.Proveedor.IdProveedor,
                        producto.Departamento.IdDepartamento,
                        producto.Descripcion,
                        producto.Imagen);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else 
                    {
                        result.Correct = false;
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

        public static ML.Result DeleteEF(int IdProducto)
        {
           
            ML.Result result=new ML.Result();
            try
            {
                using (DL_EF.MGarciaEcommerceEntities conexion = new DL_EF.MGarciaEcommerceEntities())
                {

                    var query = conexion.ProductoDelete(IdProducto);

                    if (query > 0)
                    {
                        
                        result.Correct = true;
                    }
                    else 
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar Producto";
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

        public static ML.Result GetAllLINQ()
        {
            Console.WriteLine("METODO GETALL CON LINQ  EN PRODUCTO");
            ML.Result result = new ML.Result();

            try
            {

                using (DL_EF.MGarciaEcommerceEntities conexion = new DL_EF.MGarciaEcommerceEntities())
                {
                  //  DL_EF.Departamento departamentoDL = new DL_EF.Departamento();

                    var productoList = (from productoDL in conexion.Producto
                                            select new
                                            {
                                              IdProducto=productoDL.IdProducto,
                                              Nombre=productoDL.Nombre,
                                              Precio=productoDL.Precio,
                                              Stock=productoDL.Stock,
                                              IdProveedor=productoDL.IdProveedor,
                                              IdDepartamento=productoDL.IdDepartamento,
                                              Descripcion=productoDL.Descripcion

                
                                              }).ToList();

                    result.Objects = new List<object>();
                    if (productoList != null)
                    {


                        foreach (var objeto in productoList)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = objeto.IdProducto;
                            producto.Nombre = objeto.Nombre;
                            producto.Stock = objeto.Stock.Value;
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = objeto.IdProveedor.Value;
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = objeto.IdDepartamento.Value;
                            producto.Descripcion = objeto.Descripcion;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;

                    }
                    else
                    {

                        result.Correct = false;
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

        public static ML.Result GetByIdLINQ(int IdProducto)
        {
            Console.WriteLine("METODO GETBYID CON LINQ  EN PRODUCTO");
            ML.Result result = new ML.Result();

            try
            {

                using (DL_EF.MGarciaEcommerceEntities conexion = new DL_EF.MGarciaEcommerceEntities())
                {
                    //  DL_EF.Departamento departamentoDL = new DL_EF.Departamento();

                    var productoList = (from productoDL in conexion.Producto
                                        where  IdProducto == productoDL.IdProducto
                                        select new

                                        {
                                          //  IdProducto = productoDL.IdProducto,
                                            Nombre = productoDL.Nombre,
                                            Precio = productoDL.Precio,
                                            Stock = productoDL.Stock,
                                            IdProveedor = productoDL.IdProveedor,
                                            IdDepartamento = productoDL.IdDepartamento,
                                            Descripcion = productoDL.Descripcion
                                        }).FirstOrDefault();
                
                    if (productoList != null)
                    {
       
                            ML.Producto producto = new ML.Producto();
                        //   producto.IdProducto = productoList.IdProducto;
                            producto.Nombre = productoList.Nombre;
                            producto.Stock = productoList.Stock.Value;
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = productoList.IdProveedor.Value;
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = productoList.IdDepartamento.Value;
                            producto.Descripcion = productoList.Descripcion;

                            result.Object = producto;
                         
          
                        result.Correct = true;

                    }
                    else
                    {

                        result.Correct = false;
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

        public static ML.Result AddLINQ(ML.Producto producto)
        {
            Console.WriteLine("METODO DE AGREGAR PRODUCTO CON LINQ");
            ML.Result result = new ML.Result();
            result.Correct=true;

            try
            {
                
                using(DL_EF.MGarciaEcommerceEntities conexion=new DL_EF.MGarciaEcommerceEntities())
                {
                    DL_EF.Producto productoDL = new DL_EF.Producto();
                    productoDL.Nombre = producto.Nombre;
                    productoDL.Precio = producto.Precio;
                    productoDL.Stock = producto.Stock;
                  //  producto.Proveedor = new ML.Proveedor();
                    productoDL.IdProveedor = producto.Proveedor.IdProveedor;
                    //producto.Departamento = new ML.Departamento();
                    productoDL.IdDepartamento = producto.Departamento.IdDepartamento;
                    productoDL.Descripcion = producto.Descripcion;

                    conexion.Producto.Add(productoDL);
                    conexion.SaveChanges();

                  
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;


            }

            return result;

        }

        public static ML.Result UpdateLINQ(ML.Producto producto)
        {
            Console.WriteLine("METODO UPDATE PRODUCTO CON LINQ");
            ML.Result result = new ML.Result();
            result.Correct = true;
            try
            {

                using (DL_EF.MGarciaEcommerceEntities conexion = new DL_EF.MGarciaEcommerceEntities())
                {

                    var query = (from a in conexion.Producto
                                 where a.IdProducto == producto.IdProducto
                                 select a).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = producto.Nombre;
                        query.Precio = producto.Precio;
                        query.Stock = producto.Stock;
                        query.IdProveedor = producto.Proveedor.IdProveedor;
                        query.IdDepartamento = producto.Departamento.IdDepartamento;
                        query.Descripcion = producto.Descripcion;
                        conexion.SaveChanges();

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "ERROR AL EDITAR CON LINQ";
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

        public static ML.Result  DeleteLINQ(ML.Producto producto)
        {
            Console.WriteLine("METODO DELETE PRODUCTO CON LINQ");
            ML.Result result= new ML.Result();

            try
            {

                using(DL_EF.MGarciaEcommerceEntities conexion= new DL_EF.MGarciaEcommerceEntities())
                {
                    var query=(from a in conexion.Producto
                                   where a.IdProducto==producto.IdProducto
                                   select a).First();
                    conexion.Producto.Remove(query);
                    conexion.SaveChanges();

                    result.Correct = true;
                }

            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                Console.WriteLine(result.ErrorMessage);
            }


            return result;


        }

        //public static ML.Result GetAllByAPI()
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {

        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("http://localhost:13192/");

        //            var responseTask = client.GetAsync("api/producto");
        //            responseTask.Wait();

        //            var resultServicio = responseTask.Result;

        //            if (resultServicio.IsSuccessStatusCode)
        //            {
        //                var readTask = resultServicio.Content.ReadAsAsync<List<ML.Producto>>();
        //                readTask.Wait();

        //                foreach (var resultItem in readTask.Result)
        //                {
        //                    //ML.SubCategoria resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.SubCategoria>(resultItem.ToString());
        //                    result.Objects.Add(resultItem);
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return result;
        //}


        //public static ML.Result AddByAPI(ML.Producto producto)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {

        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("http://localhost:13192/");

        //            var postTask = client.PostAsJsonAsync<ML.Producto>("producto/Add", producto);
        //            responseTask.Wait();

        //            var resultServicio = responseTask.Result;

        //            if (resultServicio.IsSuccessStatusCode)
        //            {
        //                var readTask = resultServicio.Content.ReadAsAsync<List<ML.Producto>>();
        //                readTask.Wait();

        //                foreach (var resultItem in readTask.Result)
        //                {
        //                    //ML.SubCategoria resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.SubCategoria>(resultItem.ToString());
        //                    result.Objects.Add(resultItem);
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return result;
        //}

    }

     

}
