using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceClient.ServiceReference2;

namespace WebServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string s = client.GetData(9);
            Console.WriteLine(s);
            Console.WriteLine("_______");
            //Console.ReadLine();

            ServiceReference2.UpperOperatorPortTypeClient c2 = new UpperOperatorPortTypeClient("UpperOperatorSOAP12port_http");
            string upper = c2.upper("lowercase");
            Console.WriteLine(upper);
            Console.ReadLine();

            //ServiceReference2.UpperOperatorPortTypeClient c2 = UpperOperatorPortTypeClient("lowercase");
        }
    }
}
