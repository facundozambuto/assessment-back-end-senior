using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.Contracts
{
    public class PolicyRepository : IPolicyRepository
    {
        
        public IEnumerable<Policy> GetPolicies()
        {
            //Here there should be a real access to data such as Stored Procedures calls if we are using ADO.NET for instance. Then we will fetch our data from a database.
            List<Policy> policies = new List<Policy>()
            {
                new Policy(){Id = "880abb11-936a-45d0-880d-a9fb4d669086", AmountInsured = 2301.98, Email = "inesblankenship@quotezart.co",
                         InceptionDate = DateTime.ParseExact("2015-02-20T04:13:21Z", "yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture),
                         InstallmentPayment = false, ClientId = "a0ece5db-cd14-4f21-812f-966633e7be86" },

                new Policy(){Id = "065eb093-748e-4133-9884-0adc11e2fbfc", AmountInsured = 364.82, Email = "inesblankenship@quotezart.co",
                         InceptionDate = DateTime.ParseExact("2015-05-15T08:10:51Z", "yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture),
                         InstallmentPayment = false, ClientId = "e8fd159b-57c4-4d36-9bd7-a59ca13057bb" },

                new Policy(){Id = "011dd3d8-2d1e-4abe-9efc-006a1a4a0399", AmountInsured = 1458.82, Email = "inesblankenship@quotezart.co",
                         InceptionDate = DateTime.ParseExact("2016-09-12T04:28:09Z", "yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture),
                         InstallmentPayment = false, ClientId = "a0ece5db-cd14-4f21-812f-966633e7be86" },

                new Policy(){Id = "1f00dd51-3583-40a0-8350-a2df96b505a9", AmountInsured = 1476.25, Email = "inesblankenship@quotezart.co",
                        InceptionDate = DateTime.ParseExact("2014-12-30T08:55:23Z", "yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture),
                        InstallmentPayment = false, ClientId = "e8fd159b-57c4-4d36-9bd7-a59ca13057bb" },

                new Policy(){Id = "3a774f4e-0e70-488f-ac9f-ee211c8d5ece", AmountInsured = 1476.25, Email = "inesblankenship@quotezart.co",
                        InceptionDate = DateTime.ParseExact("2014-12-30T08:55:23Z", "yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture),
                        InstallmentPayment = false, ClientId = "e8fd159b-57c4-4d36-9bd7-a59ca13057bb" },

                new Policy(){Id = "0eba1179-6155-41b5-bdd8-f80e1ac94cab", AmountInsured = 1476.25, Email = "inesblankenship@quotezart.co",
                        InceptionDate = DateTime.ParseExact("2014-12-30T08:55:23Z", "yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture),
                        InstallmentPayment = false, ClientId = "e8fd159b-57c4-4d36-9bd7-a59ca13057bb" }

            };

            return policies;
        }
    }
}