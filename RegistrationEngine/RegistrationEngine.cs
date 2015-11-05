using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DataContracts;
using UnityResolver;


namespace RegistrationEngine
{
    public class RegistrationEngine : IRegistrationEngine       
    {
        public ICollection<Attendee> ProcessAttendees(UserContext userContext, ICollection<Attendee> attendees)
        {
            List<Attendee> registrationAttendees = new List<Attendee>();

            foreach (Attendee a in attendees)
            {
                if (a.Id == null)
                {
                    registrationAttendees.Add(UnityCache.ResolveDefault<IAttendeeAccessor>().AddAttendee(userContext, a));
                }
                else
                {
                    registrationAttendees.Add(a);
                }
            }

            return registrationAttendees;

        }
    }
}
