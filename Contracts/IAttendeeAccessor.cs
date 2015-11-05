using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace Contracts
{
    public interface IAttendeeAccessor
    {
        Attendee AddAttendee(UserContext userContext, Attendee attendee);

        Attendee GetAttendeeByEmail(UserContext userContext, string email);
    }
}
