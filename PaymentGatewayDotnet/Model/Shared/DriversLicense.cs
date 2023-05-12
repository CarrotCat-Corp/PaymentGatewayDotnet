using System;
using System.Collections.Generic;

namespace PaymentGatewayDotnet.Model.Shared
{
    public sealed class DriversLicense
    {
        /// <summary>
        /// Driver's license number.
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// Driver's license date of birth.
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        
        /// <summary>
        /// The state that issued the customer's driver's license.
        /// </summary>
        public string State { get; set; }
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            if (Number == null) throw new ArgumentNullException(nameof(Number));
            if (DateOfBirth == null) throw new ArgumentNullException(nameof(DateOfBirth));
            if (State == null) throw new ArgumentNullException(nameof(State));
            
            return new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("drivers_license_number", Number),
                new KeyValuePair<string, string>("drivers_license_dob", DateOfBirth?.ToString("d")),
                new KeyValuePair<string, string>("drivers_license_state", State)
            };
        }
    }
}