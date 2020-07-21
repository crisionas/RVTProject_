using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RVTLoadBalancer.Services
{
    public class CertificationValidationService
    {
        public bool ValidateCert(X509Certificate2 certificate)
        {



            return CheckThumbprintValidation(certificate.Thumbprint);
        }

        private bool CheckThumbprintValidation(string thumbprint)
        {
            var data = new List<string>
            {
                "CCE345C259D0F370FA14D53CFB932347C3F0C4E9",
                "fafba588bd359de75126c80f75b57f4f11dcd5a5"
            };

            if (data.Contains(thumbprint))
            { 
                return true;
            }

            else return false;
        }
    }
}
