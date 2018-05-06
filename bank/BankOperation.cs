using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace bank
{
    public enum operationType {Credit, Debit};
    [XmlRoot("operation")]
    public class Operation
    {
        [XmlAttribute("type")]
        private operationType type;

        public operationType Gettype()
        {
            return type;
        }

        public void Settype(operationType value)
        {
            type = value;
        }

        public void Settype(String value)
        {
            if (value == "income" || value == "Debit")
            {
                type = operationType.Debit; 
            } else 
            {
                type = operationType.Credit;
            }
        }

        [XmlElement("Amount")]
        public Double amount {get; set;}
        
        [XmlElement("Date")]
        public DateTime date {get; set;}
    }
}