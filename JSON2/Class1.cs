using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JSON2
{
    [DataContract]
    public class Players
    {
        [DataMember]
        public string PlayerName { get; set; }

        [DataMember]
        public string Team { get; set; }

        [DataMember]
        public int Score { get; set; }
    }
}
