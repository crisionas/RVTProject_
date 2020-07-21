using System;

namespace RVT_Block_lib.Responses
{
    public class RegLbResponse
    {
        /// <summary>
        /// Clasa aceasta este raspuns de catre LoadBalancer catre Administrator. Adica cind am primit raspuns de la nod (NodeRegResponse) convertam in RegLbResponse si transmitem la Admin
        /// </summary>
        public bool Status { get; set; }
        public string Message { get; set; }
        public DateTime ProcessedTime { get; set; }
        public string IDVN { get; set; }
        public string VnPassword { get; set; }
    }
}
