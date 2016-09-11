using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace Contracts
{
    public interface IRegistrationAccessor
    {
        void AddRegistration(UserContext userContext, Registration registration);
        ICollection<Attendee> GetAllAttendees(UserContext uc);
    }
}
