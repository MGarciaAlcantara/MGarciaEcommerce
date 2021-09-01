using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Departamento
    {
        public static ML.Result GetAll()
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

                        string Query = "SELECT	IdDepartamento,	Nombre,	IdArea	FROM Departamento";

                        cmd.CommandText = Query;
                        cmd.Connection = context;
                       

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable tableProducto = new DataTable();
                        da.Fill(tableProducto);

                        context.Open();


                        if (tableProducto.Rows.Count > 0)
                        {

                            result.Objects = new List<object>();

                            foreach (DataRow row in tableProducto.Rows)
                            {

                                ML.Departamento departamento = new ML.Departamento();

                                departamento.IdDepartamento = int.Parse(row[0].ToString());
                                departamento.Nombre = row[1].ToString();
                                departamento.Area = new ML.Area();
                                departamento.Area.IdArea = int.Parse(row[2].ToString()); 

                                result.Objects.Add(departamento);


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
      
        public static ML.Result Add(ML.Departamento departamento){
       
          
            ML.Result result=new ML.Result ();
        

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string Query = "INSERT INTO [Departamento]([Nombre],[IdArea]) VALUES(@Nombre,@IdArea)";

                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[2];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = departamento.Nombre;

                        collection[1] = new SqlParameter("IdArea", SqlDbType.Int);
                        collection[1].Value = departamento.Area.IdArea;

                       
                        
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

        public static ML.Result Update(ML.Departamento departamento) {

            ML.Result result = new ML.Result();

            Console.WriteLine("---------------------------------------Metodo sin SP--------------------------------------");
            Console.WriteLine("");
           
 try 
      {           
        using(SqlConnection context= new SqlConnection(DL.Conexion.GetConnectionString()))
        
        {
               
                    using (SqlCommand cmd = new SqlCommand())
                  
                    {

                        string Query = "update departamento set Nombre=@Nombre, IdArea=@IdArea where IdDepartamento=@IdDepartamento;";

                        cmd.CommandText = Query;
                        cmd.Connection = context;


                        SqlParameter[] Collection = new SqlParameter[3];

                        Collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        Collection[0].Value = departamento.Nombre;

                        Collection[1] = new SqlParameter("IdArea", SqlDbType.Int);
                        Collection[1].Value = departamento.Area.IdArea;
                        Collection[2] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        Collection[2].Value = departamento.IdDepartamento;

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
                            result.ErrorMessage = "Error al modificar el departamento";
                             }
                    }
                }
 }
                    catch(Exception ex){
                    
                    result.Correct=false;

                        result.ErrorMessage=ex.Message;
                    
                    }
                
            
         return result;
        }

        public static ML.Result Delete(ML.Departamento departamento)
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

                        string Query = "delete from Departamento where IdDepartamento=@IdDepartamento";

                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = departamento.IdDepartamento;

                   

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

                        string Query = "DepartamentoGetAll";

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

                                ML.Departamento departamento = new ML.Departamento();

                                departamento.IdDepartamento = int.Parse(row[0].ToString());
                                departamento.Nombre = row[1].ToString();
                                departamento.Area = new ML.Area();
                                departamento.Area.IdArea = int.Parse(row[2].ToString());

                                result.Objects.Add(departamento);


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

        public static ML.Result AddSP(ML.Departamento departamento) {

            ML.Result result = new ML.Result();

            Console.WriteLine("---------------------------------------Metodo con SP--------------------------------------");
            Console.WriteLine("");

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string Query = "EXEC DepartamentoAdd @Nombre, @IdArea";

                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[2];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = departamento.Nombre;

                        collection[1] = new SqlParameter("IdArea", SqlDbType.Int);
                        collection[1].Value = departamento.Area.IdArea;



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

        public static ML.Result UpdateSP(ML.Departamento departamento)
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

                        string Query = "EXEC DepartamentoUpdate @IdDepartamento,@Nombre,@IdArea;";

                        cmd.CommandText = Query;
                        cmd.Connection = context;


                        SqlParameter[] Collection = new SqlParameter[3];

                        Collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        Collection[0].Value = departamento.Nombre;

                        Collection[1] = new SqlParameter("IdArea", SqlDbType.Int);
                        Collection[1].Value = departamento.Area.IdArea;
                        Collection[2] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        Collection[2].Value = departamento.IdDepartamento;

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
                            result.ErrorMessage = "Error al modificar el departamento";
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

        public static ML.Result DeleteSP(ML.Departamento departamento)
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

                        string Query = "EXEC DepartamentoDelete @IdDepartamento;";

                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = departamento.IdDepartamento;



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

        public static ML.Result AddEF(ML.Departamento departamento){
            Console.WriteLine("METODO CON  ENTITY FRAMEWORK");
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.MGarciaEcommerceEntities context = new DL_EF.MGarciaEcommerceEntities())
                {
                    var query = context.DepartamentoAdd(departamento.Nombre,departamento.Area.IdArea);
                
                if(query>0)
                {
                    result.Correct=true;
                    
                }
                else
                {
                    result.Correct=false;
                    result.ErrorMessage="Error al insertar departamento";
                }
                
                
                }

            }
            
            catch(Exception ex) {
             result.Correct=false;
             result.ErrorMessage=ex.Message;
            
            }


            return result;        
        
        
        }

        public static ML.Result UpdateEF(ML.Departamento departamento)
        {

            Console.WriteLine("METODO UPDATE CON ENTITY FRAMEWORK");
            ML.Result result = new ML.Result();

            try
            {

            using(DL_EF.MGarciaEcommerceEntities context =new DL_EF.MGarciaEcommerceEntities())
               {
                 var query = context.DepartamentoUpdate(departamento.IdDepartamento,departamento.Nombre,departamento.Area.IdArea);

                  if(query>0)
                  {
                    result.Correct = true;

                  }
                 else
                  {
                    result.Correct = false;
                    result.ErrorMessage = "Error al actualizar";
                  }
              }

            }
            catch(Exception Ex)
            {
                result.ErrorMessage = Ex.Message;
                result.Correct = false;
                         
            }      
            
            return result;


        }

        public static ML.Result DeleteEF(int IdDepartamento)
        {
            Console.WriteLine("METODO CON  ENTITY FRAMEWORK");
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MGarciaEcommerceEntities context = new DL_EF.MGarciaEcommerceEntities())
                {
                    var query = context.DepartamentoDelete(IdDepartamento);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar departamento";
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
            Console.WriteLine("METODO CON  ENTITY FRAMEWORK");
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.MGarciaEcommerceEntities context=new DL_EF.MGarciaEcommerceEntities())
                {
                    var  query = context.DepartamentoGetAll().ToList();

                    result.Objects=new List<object>();

                    if(query!=null)
                    {
                       foreach(var objeto in query)
                       {
                           ML.Departamento departamento = new ML.Departamento();
                          
                           departamento.IdDepartamento = objeto.IdDepartamento;
                           departamento.Nombre = objeto.DepartamentoNombre;
                           departamento.Area = new ML.Area();
                           departamento.Area.IdArea = objeto.IdArea.Value;
                           departamento.Area.Nombre = objeto.AreaNombre;

                           result.Objects.Add(departamento);

                       }
                       result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al consultar";
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

        public static ML.Result GetByIdEF(int IdDepartamento)
        {
            Console.WriteLine("METODO CON  ENTITY FRAMEWORK");
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGarciaEcommerceEntities context = new DL_EF.MGarciaEcommerceEntities())
                {
                    ML.Departamento departamento = new ML.Departamento();
                    var query = context.DepartamentoGetByID(IdDepartamento).FirstOrDefault();

                    if (query != null)
                    {


                        departamento.IdDepartamento = IdDepartamento;
                         departamento.Nombre = query.Nombre;
                          departamento.Area = new ML.Area();
                            departamento.Area.IdArea = query.IdArea.Value;
                            
                             result.Object=departamento;

                        
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

        public static ML.Result GetByIdArea(int IdArea)
        {
            Console.WriteLine("METODO CON  ENTITY FRAMEWORK");
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGarciaEcommerceEntities context = new DL_EF.MGarciaEcommerceEntities())
                {

                    var query = context.AreaGetById(IdArea).ToList();

                    if (query != null)
                    {

                        result.Objects=new List<object>();         
                 foreach(var objeto in query){

                    ML.Departamento departamento = new ML.Departamento();

                       
                        departamento.IdDepartamento = objeto.IdDepartamento;
                      departamento.Area = new ML.Area();
                        departamento.Area.IdArea = objeto.IdArea.Value;
                        departamento.Nombre = objeto.Nombre;

                        result.Objects.Add(departamento);
                        result.Correct = true;
                    
                              }
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

        public static ML.Result GetAllLINQ()
        {
            Console.WriteLine("METODO GETALL CON LINQ DEPARTAMENTO");
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGarciaEcommerceEntities context = new DL_EF.MGarciaEcommerceEntities())
                {
                    var departamentoList = (from deptoDL in context.Departamento
                                            select new { 
                                            IdDepartamento=deptoDL.IdDepartamento,
                                            Nombre=deptoDL.Nombre,
                                            IdArea=deptoDL.Area.IdArea                                           
                                            }
                                            ).ToList();

                    result.Objects = new List<object>();

                    if (departamentoList != null)
                    {
                        foreach (var objeto in departamentoList)
                        {
                            ML.Departamento departamento = new ML.Departamento();

                          departamento.IdDepartamento = objeto.IdDepartamento;
                            departamento.Nombre = objeto.Nombre;
                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = objeto.IdArea;
                            result.Objects.Add(departamento);

                        }
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

        public static ML.Result GetByIdLINQ()
        {
            Console.WriteLine("METODO GET BY ID CON LINQ DEPARTAMENTO");
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MGarciaEcommerceEntities context = new DL_EF.MGarciaEcommerceEntities())
                {
                    var departamentoList = (from deptoDL in context.Departamento
                                            select deptoDL).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (departamentoList != null)
                    {
                     
                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = departamentoList.IdDepartamento;
                            departamento.Nombre = departamentoList.Nombre;
                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = departamentoList.IdArea.Value;
                            result.Object = departamento;

                        
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

        public static ML.Result AddLINQ(ML.Departamento departamento)
        {
            Console.WriteLine("METODO DE AGREGAR DEPARTAMENTO CON LINQ");
            ML.Result result = new ML.Result();
            result.Correct = true;

            try
            {

                using (DL_EF.MGarciaEcommerceEntities conexion = new DL_EF.MGarciaEcommerceEntities())
                {
                    DL_EF.Departamento departamentoDL = new DL_EF.Departamento();

                    departamentoDL.Nombre = departamento.Nombre;
                    departamentoDL.IdArea = departamento.Area.IdArea;

                    conexion.Departamento.Add(departamentoDL);
                    conexion.SaveChanges();


                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;


            }

            return result;

        }

        public static ML.Result UpdateLINQ(ML.Departamento departamento)
        {
            Console.WriteLine("METODO UPDATE DEPARTAMENTO CON LINQ");
            ML.Result result = new ML.Result();
            result.Correct = true;
            try
            {

                using (DL_EF.MGarciaEcommerceEntities conexion = new DL_EF.MGarciaEcommerceEntities())
                {

                    var query = (from depto in conexion.Departamento
                                 where depto.IdDepartamento ==departamento.IdDepartamento
                                 select depto).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = departamento.Nombre;
                        query.IdArea = departamento.Area.IdArea;
                      
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

        public static ML.Result DeleteLINQ(ML.Departamento departamento)
        {
            Console.WriteLine("METODO DELETE DEPARTAMENTO CON LINQ");
            ML.Result result = new ML.Result();

            try
            {

                using (DL_EF.MGarciaEcommerceEntities conexion = new DL_EF.MGarciaEcommerceEntities())
                {
                    var query = (from depto in conexion.Departamento
                                 where depto.IdDepartamento==departamento.IdDepartamento
                                 select depto).First();
                    conexion.Departamento.Remove(query);
                    conexion.SaveChanges();

                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                Console.WriteLine(result.ErrorMessage);
            }


            return result;


        }
    }





            
           
           
        
        
        
        }
    

