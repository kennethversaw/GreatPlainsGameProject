using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace DataContracts
{
    [DataContract]
    public class UserContext
    {
        [DataMember]
        public string AuditUserName { get; set; }

        [DataMember]
        public string MembershipUserName { get; set; }

        [DataMember]
        public string MembershipUserId { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string ConnectionString { get; set; }


    }
}
