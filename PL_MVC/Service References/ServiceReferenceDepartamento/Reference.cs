﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL_MVC.ServiceReferenceDepartamento {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceDepartamento.IServiceDepartamento")]
    public interface IServiceDepartamento {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDepartamento/AddDepartamento", ReplyAction="http://tempuri.org/IServiceDepartamento/AddDepartamentoResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SL_WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        SL_WCF.Result AddDepartamento(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDepartamento/AddDepartamento", ReplyAction="http://tempuri.org/IServiceDepartamento/AddDepartamentoResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> AddDepartamentoAsync(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDepartamento/UpdateDepartamento", ReplyAction="http://tempuri.org/IServiceDepartamento/UpdateDepartamentoResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SL_WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        SL_WCF.Result UpdateDepartamento(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDepartamento/UpdateDepartamento", ReplyAction="http://tempuri.org/IServiceDepartamento/UpdateDepartamentoResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> UpdateDepartamentoAsync(ML.Departamento departamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDepartamento/DeleteDepartamento", ReplyAction="http://tempuri.org/IServiceDepartamento/DeleteDepartamentoResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        SL_WCF.Result DeleteDepartamento(int IdDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDepartamento/DeleteDepartamento", ReplyAction="http://tempuri.org/IServiceDepartamento/DeleteDepartamentoResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> DeleteDepartamentoAsync(int IdDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDepartamento/GetAllDepartamento", ReplyAction="http://tempuri.org/IServiceDepartamento/GetAllDepartamentoResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        SL_WCF.Result GetAllDepartamento();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDepartamento/GetAllDepartamento", ReplyAction="http://tempuri.org/IServiceDepartamento/GetAllDepartamentoResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> GetAllDepartamentoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDepartamento/GetByIdDepartamento", ReplyAction="http://tempuri.org/IServiceDepartamento/GetByIdDepartamentoResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        SL_WCF.Result GetByIdDepartamento(int IdDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDepartamento/GetByIdDepartamento", ReplyAction="http://tempuri.org/IServiceDepartamento/GetByIdDepartamentoResponse")]
        System.Threading.Tasks.Task<SL_WCF.Result> GetByIdDepartamentoAsync(int IdDepartamento);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceDepartamentoChannel : PL_MVC.ServiceReferenceDepartamento.IServiceDepartamento, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceDepartamentoClient : System.ServiceModel.ClientBase<PL_MVC.ServiceReferenceDepartamento.IServiceDepartamento>, PL_MVC.ServiceReferenceDepartamento.IServiceDepartamento {
        
        public ServiceDepartamentoClient() {
        }
        
        public ServiceDepartamentoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceDepartamentoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDepartamentoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDepartamentoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SL_WCF.Result AddDepartamento(ML.Departamento departamento) {
            return base.Channel.AddDepartamento(departamento);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> AddDepartamentoAsync(ML.Departamento departamento) {
            return base.Channel.AddDepartamentoAsync(departamento);
        }
        
        public SL_WCF.Result UpdateDepartamento(ML.Departamento departamento) {
            return base.Channel.UpdateDepartamento(departamento);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> UpdateDepartamentoAsync(ML.Departamento departamento) {
            return base.Channel.UpdateDepartamentoAsync(departamento);
        }
        
        public SL_WCF.Result DeleteDepartamento(int IdDepartamento) {
            return base.Channel.DeleteDepartamento(IdDepartamento);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> DeleteDepartamentoAsync(int IdDepartamento) {
            return base.Channel.DeleteDepartamentoAsync(IdDepartamento);
        }
        
        public SL_WCF.Result GetAllDepartamento() {
            return base.Channel.GetAllDepartamento();
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> GetAllDepartamentoAsync() {
            return base.Channel.GetAllDepartamentoAsync();
        }
        
        public SL_WCF.Result GetByIdDepartamento(int IdDepartamento) {
            return base.Channel.GetByIdDepartamento(IdDepartamento);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Result> GetByIdDepartamentoAsync(int IdDepartamento) {
            return base.Channel.GetByIdDepartamentoAsync(IdDepartamento);
        }
    }
}