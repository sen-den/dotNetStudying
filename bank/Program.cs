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
            // First task
            using (var reader = new System.IO.StreamReader("inputData/clientinfo_input.xml"))
            {
                var xmlOldBankClientSerializer = new XmlSerializer(typeof(OldBankClient));
                var xmlNewBankClientSerializer = new XmlSerializer(typeof(NewBankClient));

                var oldClient = xmlOldBankClientSerializer.Deserialize(reader);
                var newClient = new NewBankClient((OldBankClient)oldClient);

                using (var writer = new System.IO.StreamWriter("outputData/clientinfo_output.xml"))
                {
                    xmlNewBankClientSerializer.Serialize(writer, newClient);
                }

                var jsonNewBankClient = JsonConvert.SerializeObject(newClient, Formatting.Indented);
                using (var writer = new System.IO.StreamWriter("outputData/clientinfo_output.json"))
                {
                    writer.Write(jsonNewBankClient);
                }

                var workAddress = newClient.workAddress;
                var xmlNewBankClientAddressSerializer = new XmlSerializer(typeof(Address));
                using (var writer = new System.IO.StreamWriter("outputData/workaddress_output.xml"))
                {
                    xmlNewBankClientAddressSerializer.Serialize(writer, workAddress);
                }

                var homeAddress = newClient.homeAddress;
                var jsonNewBankClientHomeAddress = JsonConvert.SerializeObject(homeAddress, Formatting.Indented);
                using (var writer = new System.IO.StreamWriter("outputData/homeaddress_output.json"))
                {
                    writer.Write(jsonNewBankClientHomeAddress);
                }
            }



        }
    }
}