using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace bank
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlBankClientSerializer = new XmlSerializer(typeof(BankClient));

            var client = new BankClient
            {
                firstName = "Ivan";
                lastName = "Petrov";
            }

            var writer = new System.IO.StreamWriter("test1.xml");
            xmlBankClientSerializer.Serialize(writer, client);
        }
    }
}