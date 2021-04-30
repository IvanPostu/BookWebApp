﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookWCFService.BookDataService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BookDataService.IBookDataService")]
    public interface IBookDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookDataService/GetAllBooks", ReplyAction="http://tempuri.org/IBookDataService/GetAllBooksResponse")]
        Models.Book[] GetAllBooks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookDataService/GetAllBooks", ReplyAction="http://tempuri.org/IBookDataService/GetAllBooksResponse")]
        System.Threading.Tasks.Task<Models.Book[]> GetAllBooksAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IBookDataService/saveBook")]
        void saveBook(Models.Book book);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IBookDataService/saveBook")]
        System.Threading.Tasks.Task saveBookAsync(Models.Book book);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IBookDataService/updateBook")]
        void updateBook(Models.Book book);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IBookDataService/updateBook")]
        System.Threading.Tasks.Task updateBookAsync(Models.Book book);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IBookDataService/deleteBook")]
        void deleteBook(Models.Book book);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IBookDataService/deleteBook")]
        System.Threading.Tasks.Task deleteBookAsync(Models.Book book);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBookDataServiceChannel : BookWCFService.BookDataService.IBookDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BookDataServiceClient : System.ServiceModel.ClientBase<BookWCFService.BookDataService.IBookDataService>, BookWCFService.BookDataService.IBookDataService {
        
        public BookDataServiceClient() {
        }
        
        public BookDataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BookDataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookDataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookDataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Models.Book[] GetAllBooks() {
            return base.Channel.GetAllBooks();
        }
        
        public System.Threading.Tasks.Task<Models.Book[]> GetAllBooksAsync() {
            return base.Channel.GetAllBooksAsync();
        }
        
        public void saveBook(Models.Book book) {
            base.Channel.saveBook(book);
        }
        
        public System.Threading.Tasks.Task saveBookAsync(Models.Book book) {
            return base.Channel.saveBookAsync(book);
        }
        
        public void updateBook(Models.Book book) {
            base.Channel.updateBook(book);
        }
        
        public System.Threading.Tasks.Task updateBookAsync(Models.Book book) {
            return base.Channel.updateBookAsync(book);
        }
        
        public void deleteBook(Models.Book book) {
            base.Channel.deleteBook(book);
        }
        
        public System.Threading.Tasks.Task deleteBookAsync(Models.Book book) {
            return base.Channel.deleteBookAsync(book);
        }
    }
}
