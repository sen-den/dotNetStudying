
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace bankClients
{
    /// <summary>
    /// Represents allowed operation types.
    /// Debit is account replenishment.
    /// Credit is account withdrawal.
    /// </summary>
    public enum operationType {Credit, Debit};

    /// <summary> 
    /// Represents clients operation.
    /// </summary>
    public class Operation
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public operationType OperationType;
        public float Amount;
        public DateTime Date;
    }

    /// <summary>
    /// Represents client's last-, first-, middle-name and his operations List.
    /// </summary>
    public class Client 
    {
        public String FirstName;
        public String LastName;
        public String MiddleName;
        public List<Operation> Operations;

        /// <summary> 
        /// Returns String client representation (Last name, first name, middle name and first debit date).
        /// </summary>
        public String getInfo()
        {
            var firstDebit = 
                Operations
                .OrderBy(x => x.Date)
                .First();
                               
            return String.Format(
                "{0} {1} {2} with first debit on {3}", 
                LastName, FirstName, MiddleName, firstDebit.Date
                );
        }
    }
}