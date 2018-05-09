using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Converters;

namespace bankClients
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Client> bankClients;
            Results logger = new Results();
            using (var reader = new System.IO.StreamReader("processingFiles/bankClients.json"))
            {
                var rawBankClients = reader.ReadToEnd();
                bankClients = JsonConvert.DeserializeObject<List<Client>>(rawBankClients);
            }

            // 1. Calculating debit and credit sums in april
            float debitSum = 0;
            float creditSum = 0;
            foreach (var client in bankClients)
            {
                foreach (var operation in client.Operations)
                {
                    if (operation.Date.Month == 4)
                    {
                        if (operation.OperationType == operationType.Debit)
                        {
                            debitSum += operation.Amount;
                        }
                        else
                        {
                            creditSum += operation.Amount;
                        }
                    }
                }
            }

            Console.WriteLine(
                logger.log(String.Format(
                    "1. There were debit operations for {0}$ and credit for {1}$ in april.",
                    debitSum,
                    creditSum
                ))
            );

            // 2. Clients without credits in april
            List<Client> clientsWithoutCredits = new List<Client>();
            foreach (var client in bankClients)
            {
                bool hasCredit = false;
                foreach (var operation in client.Operations)
                {
                    if (operation.Date.Month == 4 && operation.OperationType == operationType.Credit)
                    {
                        hasCredit = true;
                        break;
                    }
                }

                if (!hasCredit)
                {
                    clientsWithoutCredits.Add(client);
                }
            }

            List<String> clientsWithoutCreditsInfo = new List<String>();
            foreach (var client in clientsWithoutCredits)
            {
                clientsWithoutCreditsInfo.Add(client.getInfo());
            }
            Console.WriteLine(logger.log(
                "2. Clients without credit operations in april: "
                + clientsWithoutCreditsInfo.ToString())
            ); // there aren't such clients?!

            // 3-4. Clients with max credit and debit sums
            var hasMaxCredit = new { clientObj = bankClients[0], sum = -1.0f };
            var hasMaxDebit = new { clientObj = bankClients[0], sum = -1.0f };
            foreach (var client in bankClients)
            {
                float clientCreditSum = 0;
                float clientDebitSum = 0;
                foreach (var operation in client.Operations)
                {
                    if (operation.OperationType == operationType.Debit)
                    {
                        clientDebitSum += operation.Amount;
                    }
                    else
                    {
                        clientCreditSum += operation.Amount;
                    }
                }

                if (clientCreditSum > hasMaxCredit.sum)
                {
                    hasMaxCredit = new { clientObj = client, sum = (float)clientCreditSum };
                }
                if (clientDebitSum > hasMaxDebit.sum)
                {
                    hasMaxDebit = new { clientObj = client, sum = (float)clientCreditSum };
                }
            }

            Console.WriteLine(logger.log(String.Format(
                "3. {0} has maximum credit operations sum.", hasMaxCredit.clientObj.getInfo())));
            Console.WriteLine(logger.log(String.Format(
                "4. {0} has maximum debit operations sum.", hasMaxDebit.clientObj.getInfo())));

            // 4. Largest balance on 1st may.
            var hasLargestBalance = new { clientObj = bankClients[0], sum = -1.0f };
            foreach (var client in bankClients)
            {
                float clientDebitSum =
                    (
                        from operations in client.Operations
                        where (
                            operations.Date.CompareTo(new DateTime(2018, 05, 01)) < 0
                            && operations.OperationType == operationType.Debit
                            )
                        select operations.Amount
                        ).Sum();

                float clientCreditSum =
                    (
                        from operations in client.Operations
                        where (
                            operations.Date.CompareTo(new DateTime(2018, 05, 01)) < 0
                            && operations.OperationType == operationType.Credit
                            )
                        select operations.Amount
                        ).Sum();

                float clientBalance = clientDebitSum - clientCreditSum;

                if (clientBalance > hasLargestBalance.sum)
                {
                    hasLargestBalance = new { clientObj = client, sum = clientBalance };
                }
            }

            Console.WriteLine(logger.log(String.Format(
                "5. {0} has largest ballance on 2018.05.01", hasLargestBalance.clientObj.getInfo())));

            logger.save("processingFiles/savedInfo.json");
        }
    }
}
