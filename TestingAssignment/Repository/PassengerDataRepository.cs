using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingAssignment.Models;

namespace TestingAssignment.Repository
{
    public class PassengerDataRepository:IPassengerDataRepository
    {
        readonly Dictionary<Guid, Passenger> _passenger = new Dictionary<Guid, Passenger>();
        public PassengerDataRepository()
        {
            Guid id1 = new Guid();
            Guid id2 = new Guid();
            Guid id3 = new Guid();
            _passenger.Add(id1, new Passenger() { Id = id1, FirstName = "Arjun", LastName = "Chandarana", PhoneNumber = "8735972921" });
            _passenger.Add(id2, new Passenger() { Id = id2, FirstName = "Ram", LastName = "Patel", PhoneNumber = "8735972922" });
            _passenger.Add(id3, new Passenger() { Id = id3, FirstName = "Shyam", LastName = "Rana", PhoneNumber = "8735972923" });

        }
        public Passenger AddPassenger(Passenger passenger)
        {
            Guid newId = new Guid();
            passenger.Id = newId;
            _passenger.Add(newId, passenger);
            return passenger;
        }

        public bool Delete(Guid Id)
        {
            var result = _passenger.Remove(Id);
            return result;
        }

        public Passenger GetById(Guid id)
        {
            return _passenger.FirstOrDefault(x => x.Key == id).Value;
        }

        public IList<Passenger> getPassengersList()
        {
            return _passenger.Select(x => x.Value).ToList();
        }

        public Passenger Update(Passenger passenger)
        {
            Passenger obj = GetById(passenger.Id);
            if (obj == null)
                return null;
            _passenger[obj.Id] = passenger;
            return passenger;
        }
    }
}
