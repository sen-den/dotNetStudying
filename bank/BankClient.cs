using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace bank
{
    [XmlRoot("cl")]
    class OldBankClient
    {
        [XmlElement("fn")]
        public String firstName {get; set;}

        [XmlElement("ln")]
        public String lastName {get; set;}
    }


}