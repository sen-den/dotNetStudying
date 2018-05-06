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
            var xmlOldBankClientSerializer = new XmlSerializer(typeof(OldBankClient));
            var xmlNewBankClientSerializer = new XmlSerializer(typeof(NewBankClient));

            var clientReader = new System.IO.StreamReader("inputData/clientinfo_input.xml");
            var clientWriter = new System.IO.StreamWriter("outputData/clientinfo_output.xml");

            var oldClient = xmlOldBankClientSerializer.Deserialize(clientReader);
            var newClient = new NewBankClient((OldBankClient)oldClient);

            xmlNewBankClientSerializer.Serialize(clientWriter, newClient);
        }
    }
}