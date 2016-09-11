using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace Contracts
{
    public interface IRegistrationManager
    {
        void ProcessRegistration(UserContext userContext, ICollection<Attendee> attendees);
        ICollection<Attendee> GetAllAttendees(UserContext uc);
    }
}
