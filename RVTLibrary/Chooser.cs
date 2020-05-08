using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RVTLibrary
{
    [DataContract]
    public class Chooser
    {
        [DataMember]
        public int IDNP { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public DateTime Birth_date { get; set; }
        [DataMember]
        public DateTime Vote_date { get; set; }
        [DataMember]
        public int Party_Choosed { get; set; }
        [DataMember]
        public int Region { get; set; }
        [DataMember]
        public string Ip_address { get; set; }
        [DataMember]
        public string Phone_Number { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string IDUN { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
