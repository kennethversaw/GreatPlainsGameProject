using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DataContracts;
using UnityResolver;

namespace RegistrationManager
{
    public class RegistrationManager : IRegistrationManager
    {
        public ICollection<Attendee> GetAllAttendees(UserContext uc)
        {
            return UnityCache.ResolveDefault<IRegistrationAccessor>().GetAllAttendees(uc);
        }

        public void ProcessRegistration(UserContext userContext, ICollection<Attendee> attendees)
        {
          
            Registration returnRegistration = new Registration();
            List<Attendee> registrationAttendees = new List<Attendee>(UnityCache.ResolveDefault<IRegistrationEngine>().ProcessAttendees(userContext, attendees));

           
            Registration newReg = new Registration();
            newReg.Attendees = registrationAttendees;

           UnityCache.ResolveDefault<IRegistrationAccessor>().AddRegistration(userContext, newReg);
         
        }
    }
}
