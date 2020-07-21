using System;
using System.Runtime.Serialization;

namespace RVT_Block_lib.Models
{
    public class ChooserLbMessage
    {

        [DataMember]
        public string IDNP { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public DateTime? Birth_date { get; set; }
        [DataMember]
        public DateTime Vote_date { get; set; }
        [DataMember]
        public int Region { get; set; }
        [DataMember]
        public string Phone_Number { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        /// <summary>
        /// IDUN ID unic numeric a votantului
        /// </summary>
        /// 

        public string IDVN { get; set; }

        [DataMember]
        public int PartyChoosed { get; set; }
    }
}
