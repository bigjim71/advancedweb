﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelloWorld.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://service.bpel", ConfigurationName="ServiceReference1.UpperOperatorPortType")]
    public interface UpperOperatorPortType {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:upper", ReplyAction="urn:upperResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        HelloWorld.ServiceReference1.upperResponse upper(HelloWorld.ServiceReference1.upperRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
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
}
