using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace Contracts
{
    [ServiceContract]
    public interface IEventManager
    {
        [OperationContract]
        void RegisterNewEvent(UserContext userContext, Event newEvent);
    }
}
