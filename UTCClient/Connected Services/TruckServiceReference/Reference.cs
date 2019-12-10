﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UTCClient.TruckServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Truck", Namespace="http://schemas.datacontract.org/2004/07/UTCService")]
    [System.SerializableAttribute()]
    public partial class Truck : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BrandField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CarStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ColorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FuelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MileageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ModelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TotalCostField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int YearOfProductionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Brand {
            get {
                return this.BrandField;
            }
            set {
                if ((object.ReferenceEquals(this.BrandField, value) != true)) {
                    this.BrandField = value;
                    this.RaisePropertyChanged("Brand");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CarStatus {
            get {
                return this.CarStatusField;
            }
            set {
                if ((object.ReferenceEquals(this.CarStatusField, value) != true)) {
                    this.CarStatusField = value;
                    this.RaisePropertyChanged("CarStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Color {
            get {
                return this.ColorField;
            }
            set {
                if ((object.ReferenceEquals(this.ColorField, value) != true)) {
                    this.ColorField = value;
                    this.RaisePropertyChanged("Color");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Fuel {
            get {
                return this.FuelField;
            }
            set {
                if ((object.ReferenceEquals(this.FuelField, value) != true)) {
                    this.FuelField = value;
                    this.RaisePropertyChanged("Fuel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Mileage {
            get {
                return this.MileageField;
            }
            set {
                if ((this.MileageField.Equals(value) != true)) {
                    this.MileageField = value;
                    this.RaisePropertyChanged("Mileage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Model {
            get {
                return this.ModelField;
            }
            set {
                if ((object.ReferenceEquals(this.ModelField, value) != true)) {
                    this.ModelField = value;
                    this.RaisePropertyChanged("Model");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TotalCost {
            get {
                return this.TotalCostField;
            }
            set {
                if ((this.TotalCostField.Equals(value) != true)) {
                    this.TotalCostField = value;
                    this.RaisePropertyChanged("TotalCost");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int YearOfProduction {
            get {
                return this.YearOfProductionField;
            }
            set {
                if ((this.YearOfProductionField.Equals(value) != true)) {
                    this.YearOfProductionField = value;
                    this.RaisePropertyChanged("YearOfProduction");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TruckServiceReference.ITruckService")]
    public interface ITruckService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITruckService/GetTrucks", ReplyAction="http://tempuri.org/ITruckService/GetTrucksResponse")]
        UTCClient.TruckServiceReference.Truck[] GetTrucks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITruckService/GetTrucks", ReplyAction="http://tempuri.org/ITruckService/GetTrucksResponse")]
        System.Threading.Tasks.Task<UTCClient.TruckServiceReference.Truck[]> GetTrucksAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITruckService/AddTruck", ReplyAction="http://tempuri.org/ITruckService/AddTruckResponse")]
        void AddTruck(UTCClient.TruckServiceReference.Truck newTruck);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITruckService/AddTruck", ReplyAction="http://tempuri.org/ITruckService/AddTruckResponse")]
        System.Threading.Tasks.Task AddTruckAsync(UTCClient.TruckServiceReference.Truck newTruck);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITruckService/UpdateTruck", ReplyAction="http://tempuri.org/ITruckService/UpdateTruckResponse")]
        void UpdateTruck(UTCClient.TruckServiceReference.Truck newTruck);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITruckService/UpdateTruck", ReplyAction="http://tempuri.org/ITruckService/UpdateTruckResponse")]
        System.Threading.Tasks.Task UpdateTruckAsync(UTCClient.TruckServiceReference.Truck newTruck);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITruckService/DeleteTruck", ReplyAction="http://tempuri.org/ITruckService/DeleteTruckResponse")]
        void DeleteTruck(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITruckService/DeleteTruck", ReplyAction="http://tempuri.org/ITruckService/DeleteTruckResponse")]
        System.Threading.Tasks.Task DeleteTruckAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITruckServiceChannel : UTCClient.TruckServiceReference.ITruckService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TruckServiceClient : System.ServiceModel.ClientBase<UTCClient.TruckServiceReference.ITruckService>, UTCClient.TruckServiceReference.ITruckService {
        
        public TruckServiceClient() {
        }
        
        public TruckServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TruckServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TruckServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TruckServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public UTCClient.TruckServiceReference.Truck[] GetTrucks() {
            return base.Channel.GetTrucks();
        }
        
        public System.Threading.Tasks.Task<UTCClient.TruckServiceReference.Truck[]> GetTrucksAsync() {
            return base.Channel.GetTrucksAsync();
        }
        
        public void AddTruck(UTCClient.TruckServiceReference.Truck newTruck) {
            base.Channel.AddTruck(newTruck);
        }
        
        public System.Threading.Tasks.Task AddTruckAsync(UTCClient.TruckServiceReference.Truck newTruck) {
            return base.Channel.AddTruckAsync(newTruck);
        }
        
        public void UpdateTruck(UTCClient.TruckServiceReference.Truck newTruck) {
            base.Channel.UpdateTruck(newTruck);
        }
        
        public System.Threading.Tasks.Task UpdateTruckAsync(UTCClient.TruckServiceReference.Truck newTruck) {
            return base.Channel.UpdateTruckAsync(newTruck);
        }
        
        public void DeleteTruck(int id) {
            base.Channel.DeleteTruck(id);
        }
        
        public System.Threading.Tasks.Task DeleteTruckAsync(int id) {
            return base.Channel.DeleteTruckAsync(id);
        }
    }
}