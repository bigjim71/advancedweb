﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServiceClient.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://service.bpel", ConfigurationName="ServiceReference2.UpperOperatorPortType")]
    public interface UpperOperatorPortType {
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="urn:upper", ReplyAction="urn:upperResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        WebServiceClient.ServiceReference2.upperResponse upper(WebServiceClient.ServiceReference2.upperRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="upper", WrapperNamespace="http://service.bpel", IsWrapped=true)]
    public partial class upperRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.bpel", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string str;
        
        public upperRequest() {
        }
        
        public upperRequest(string str) {
            this.str = str;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="upperResponse", WrapperNamespace="http://service.bpel", IsWrapped=true)]
    public partial class upperResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.bpel", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        public upperResponse() {
        }
        
        public upperResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UpperOperatorPortTypeChannel : WebServiceClient.ServiceReference2.UpperOperatorPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UpperOperatorPortTypeClient : System.ServiceModel.ClientBase<WebServiceClient.ServiceReference2.UpperOperatorPortType>, WebServiceClient.ServiceReference2.UpperOperatorPortType {
        
        public UpperOperatorPortTypeClient() {
        }
        
        public UpperOperatorPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UpperOperatorPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UpperOperatorPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UpperOperatorPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebServiceClient.ServiceReference2.upperResponse WebServiceClient.ServiceReference2.UpperOperatorPortType.upper(WebServiceClient.ServiceReference2.upperRequest request) {
            return base.Channel.upper(request);
        }
        
        public string upper(string str) {
            WebServiceClient.ServiceReference2.upperRequest inValue = new WebServiceClient.ServiceReference2.upperRequest();
            inValue.str = str;
            WebServiceClient.ServiceReference2.upperResponse retVal = ((WebServiceClient.ServiceReference2.UpperOperatorPortType)(this)).upper(inValue);
            return retVal.@return;
        }
    }
}
