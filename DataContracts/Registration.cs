using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataContracts
{
    [DataContract]
    public class Registration
    {
        [DataMember]
        public RegistrationType RegistrationType { get; set; }

        
       [DataMember]
       public virtual ICollection<Attendee> Attendees { get; set;}
        
    }
}
