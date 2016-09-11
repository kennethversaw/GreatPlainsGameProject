using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Contracts;
using DataContracts;

namespace DataAccessor
{
    public class RegistrationAccessor : IRegistrationAccessor
    {
        public void AddRegistration(UserContext userContext, Registration registration)
        {
            using (GPGFDb gpgfDB = new GPGFDb(userContext))
            {
                foreach (Attendee at in registration.Attendees)
                {
                    gpgfDB.Attendees.Add(at);

                }

                gpgfDB.SaveChanges();
            }
        }

        public ICollection<Attendee> GetAllAttendees(UserContext uc)
        {
            List<Attendee> returnAttendees = new List<Attendee>();
            using (GPGFDb gpgfDB = new GPGFDb(uc))
            {
                returnAttendees = gpgfDB.Attendees.ToList();
            }

            return returnAttendees;
        }



    }
}
