using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAssignment.Models;

namespace TestingAssignment.Repository
{
    public interface IPassengerDataRepository
    {
        Passenger AddPassenger(Passenger passenger);
        bool Delete(Guid Id);
        Passenger GetById(Guid id);
        IList<Passenger> getPassengersList();
        Passenger Update(Passenger passenger);
    }
}
