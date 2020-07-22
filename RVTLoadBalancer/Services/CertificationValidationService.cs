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
                "CCE345C259D0F370FA14D53CFB932347C3F0C4E9",//Node1
                "6F4DCF62CE043F3E79CD27BEDC7D3B3585C62360", //Node2
                "E0E9777D0CAFC1F8248E310C6F6245619881A6F4", // Node3
                "1AA777C4BB46997EC50BEB8040A330AAD99870AC", // 4
                "627B1A87FA77D497824F1AFE14D134E175D11192",//admin
            };

            if (data.Contains(thumbprint))
            { 
                return true;
            }

            else return false;
        }
    }
}
