﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MGarciaEcommerceEntities : DbContext
    {
        public MGarciaEcommerceEntities()
            : base("name=MGarciaEcommerceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<MetodoPago> MetodoPago { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<VentaProducto> VentaProducto { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
    
        public virtual int DepartamentoAdd(string nombre, Nullable<int> idArea)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var idAreaParameter = idArea.HasValue ?
                new ObjectParameter("IdArea", idArea) :
                new ObjectParameter("IdArea", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DepartamentoAdd", nombreParameter, idAreaParameter);
        }
    
        public virtual int DepartamentoDelete(Nullable<int> idDepartamento)
        {
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("IdDepartamento", idDepartamento) :
                new ObjectParameter("IdDepartamento", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DepartamentoDelete", idDepartamentoParameter);
        }
    
        public virtual int DepartamentoUpdate(Nullable<int> idDepartamento, string nombre, Nullable<int> idArea)
        {
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("IdDepartamento", idDepartamento) :
                new ObjectParameter("IdDepartamento", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var idAreaParameter = idArea.HasValue ?
                new ObjectParameter("IdArea", idArea) :
                new ObjectParameter("IdArea", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DepartamentoUpdate", idDepartamentoParameter, nombreParameter, idAreaParameter);
        }
    
        public virtual int ProductoDelete(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoDelete", idProductoParameter);
        }
    
        public virtual int VentaProductoAdd(Nullable<byte> idVenta, Nullable<int> cantidad, Nullable<int> idProducto)
        {
            var idVentaParameter = idVenta.HasValue ?
                new ObjectParameter("IdVenta", idVenta) :
                new ObjectParameter("IdVenta", typeof(byte));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VentaProductoAdd", idVentaParameter, cantidadParameter, idProductoParameter);
        }
    
        public virtual ObjectResult<DepartamentoGetByID_Result> DepartamentoGetByID(Nullable<int> idDepartamento)
        {
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("IdDepartamento", idDepartamento) :
                new ObjectParameter("IdDepartamento", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DepartamentoGetByID_Result>("DepartamentoGetByID", idDepartamentoParameter);
        }
    
        public virtual int VentaAdd(Nullable<int> idCliente, Nullable<decimal> total, Nullable<int> idMetodoPago, ObjectParameter idVenta)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("Total", total) :
                new ObjectParameter("Total", typeof(decimal));
    
            var idMetodoPagoParameter = idMetodoPago.HasValue ?
                new ObjectParameter("IdMetodoPago", idMetodoPago) :
                new ObjectParameter("IdMetodoPago", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VentaAdd", idClienteParameter, totalParameter, idMetodoPagoParameter, idVenta);
        }
    
        public virtual ObjectResult<AreaGetAll_Result> AreaGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AreaGetAll_Result>("AreaGetAll");
        }
    
        public virtual ObjectResult<DepartamentoGetAll_Result> DepartamentoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DepartamentoGetAll_Result>("DepartamentoGetAll");
        }
    
        public virtual ObjectResult<ProveedorGetAll_Result> ProveedorGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProveedorGetAll_Result>("ProveedorGetAll");
        }
    
        public virtual ObjectResult<AreaGetById_Result> AreaGetById(Nullable<int> idArea)
        {
            var idAreaParameter = idArea.HasValue ?
                new ObjectParameter("IdArea", idArea) :
                new ObjectParameter("IdArea", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AreaGetById_Result>("AreaGetById", idAreaParameter);
        }
    
        public virtual int ProductoAdd(string nombre, Nullable<decimal> precio, Nullable<byte> stock, Nullable<int> idProveedor, Nullable<int> idDepartamento, string descripcion, byte[] imagen)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("Stock", stock) :
                new ObjectParameter("Stock", typeof(byte));
    
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("IdDepartamento", idDepartamento) :
                new ObjectParameter("IdDepartamento", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoAdd", nombreParameter, precioParameter, stockParameter, idProveedorParameter, idDepartamentoParameter, descripcionParameter, imagenParameter);
        }
    
        public virtual ObjectResult<ProductoGetAll_Result> ProductoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetAll_Result>("ProductoGetAll");
        }
    
        public virtual ObjectResult<ProductoGetById_Result> ProductoGetById(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetById_Result>("ProductoGetById", idProductoParameter);
        }
    
        public virtual int ProductoUpdate(Nullable<int> idProducto, string nombre, Nullable<decimal> precio, Nullable<byte> stock, Nullable<int> idProveedor, Nullable<int> idDepartamento, string descripcion, byte[] imagen)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("Stock", stock) :
                new ObjectParameter("Stock", typeof(byte));
    
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("IdDepartamento", idDepartamento) :
                new ObjectParameter("IdDepartamento", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoUpdate", idProductoParameter, nombreParameter, precioParameter, stockParameter, idProveedorParameter, idDepartamentoParameter, descripcionParameter, imagenParameter);
        }
    
        public virtual int RolAdd(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RolAdd", nombreParameter);
        }
    
        public virtual int UsuarioDelete(Nullable<int> idUduario)
        {
            var idUduarioParameter = idUduario.HasValue ?
                new ObjectParameter("IdUduario", idUduario) :
                new ObjectParameter("IdUduario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioDelete", idUduarioParameter);
        }
    
        public virtual ObjectResult<RolGetAll_Result> RolGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RolGetAll_Result>("RolGetAll");
        }
    
        public virtual ObjectResult<UsuarioGetAll_Result> UsuarioGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetAll_Result>("UsuarioGetAll");
        }
    
        public virtual ObjectResult<UsuarioGetById_Result> UsuarioGetById(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetById_Result>("UsuarioGetById", idUsuarioParameter);
        }
    
        public virtual ObjectResult<UsuarioGetAllTest_Result> UsuarioGetAllTest(string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetAllTest_Result>("UsuarioGetAllTest", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter);
        }
    
        public virtual ObjectResult<string> UsuarioUpdate(Nullable<int> idUsuario, string email, string usuarioPassword, string nombre, string apellidoPaterno, string apellidoMaterno, string fechaNacimiento, string sexo, Nullable<bool> usuarioStatus, Nullable<int> idDireccion, Nullable<int> idRol, string telefono)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var usuarioPasswordParameter = usuarioPassword != null ?
                new ObjectParameter("UsuarioPassword", usuarioPassword) :
                new ObjectParameter("UsuarioPassword", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var usuarioStatusParameter = usuarioStatus.HasValue ?
                new ObjectParameter("UsuarioStatus", usuarioStatus) :
                new ObjectParameter("UsuarioStatus", typeof(bool));
    
            var idDireccionParameter = idDireccion.HasValue ?
                new ObjectParameter("IdDireccion", idDireccion) :
                new ObjectParameter("IdDireccion", typeof(int));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("UsuarioUpdate", idUsuarioParameter, emailParameter, usuarioPasswordParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, fechaNacimientoParameter, sexoParameter, usuarioStatusParameter, idDireccionParameter, idRolParameter, telefonoParameter);
        }
    
        public virtual ObjectResult<string> UsuarioAdd(string email, string usuarioPassword, string nombre, string apellidoPaterno, string apellidoMaterno, string fechaNacimiento, string sexo, Nullable<bool> usuarioStatus, Nullable<int> idDireccion, Nullable<int> idRol, string telefono)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var usuarioPasswordParameter = usuarioPassword != null ?
                new ObjectParameter("UsuarioPassword", usuarioPassword) :
                new ObjectParameter("UsuarioPassword", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var usuarioStatusParameter = usuarioStatus.HasValue ?
                new ObjectParameter("UsuarioStatus", usuarioStatus) :
                new ObjectParameter("UsuarioStatus", typeof(bool));
    
            var idDireccionParameter = idDireccion.HasValue ?
                new ObjectParameter("IdDireccion", idDireccion) :
                new ObjectParameter("IdDireccion", typeof(int));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("UsuarioAdd", emailParameter, usuarioPasswordParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, fechaNacimientoParameter, sexoParameter, usuarioStatusParameter, idDireccionParameter, idRolParameter, telefonoParameter);
        }
    
        public virtual ObjectResult<UsuarioGetByEmail_Result> UsuarioGetByEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetByEmail_Result>("UsuarioGetByEmail", emailParameter);
        }
    }
}