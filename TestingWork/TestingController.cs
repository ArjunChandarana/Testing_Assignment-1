using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http.Results;
using TestingAssignment.Controllers;
using TestingAssignment.Repository;
using Xunit;

namespace TestingWork
{
    [TestClass]
    public class TestingController
    {
        private readonly Mock<IPassengerDataRepository> mockDataRepository = new Mock<IPassengerDataRepository>();
        private readonly PassengerController _passengerController;

        public TestingController()
        {
            _passengerController = new PassengerController(mockDataRepository.Object);
        }

        [Fact]
        public void Test_GetPassenger()
        {
            // Arrange
            var resultObj = mockDataRepository.Setup(x => x.getPassengersList()).Returns(GetPassengers());

            // Act
            var response = _passengerController.Get();

            // Asert
            Assert.Equals(3, response.Count);

        }

        [Fact]
        public void Test_DeletePassenger()
        {
            var passenger = new TestingAssignment.Models.Passenger();
            passenger.Id = new Guid();
            // Arrange
            var resultObj = mockDataRepository.Setup(x => x.Delete(passenger.Id)).Returns(true);

            // Act
            var response = _passengerController.Delete(passenger.Id);

            //Assert
            Assert.IsTrue(response);

        }

        [Fact]
        public void Test_GetPassengerById()
        {
            // Arrange
            var passenger = new TestingAssignment.Models.Passenger();
            passenger.Id = new Guid();
            passenger.FirstName = "Arjun";
            passenger.LastName = "Chandarana";
            passenger.PhoneNumber = "8735972921";

            // Act
            var responseObj = mockDataRepository.Setup(x => x.GetById(passenger.Id)).Returns(passenger);
            var result = _passengerController.Get(passenger.Id);
            var isNull = Assert.IsType<OkNegotiatedContentResult<TestingAssignment.Models.Passenger>>(result);
            // Assert
            Assert.IsNotNull(isNull);
        }

        [Fact]
        public void Test_AddPassenger()
        {
            // Arrange
            var passenger = new TestingAssignment.Models.Passenger();
            passenger.Id = new Guid();
            passenger.FirstName = "Arjun";
            passenger.LastName = "Chandarana";
            passenger.PhoneNumber = "8735972921";
            // Act
            var response = mockDataRepository.Setup(x => x.AddPassenger(passenger)).Returns(AddPassenger());
            var result = _passengerController.Post(passenger);

            // Assert
            Assert.IsNotNull(result);
        }

        [Fact]
        public void Test_UpdatePassenger()
        {
            // Arrange
            var model = JsonConvert.DeserializeObject<TestingAssignment.Models.Passenger>(File.ReadAllText("Data/UpdateUser.json"));

            // Act
            var resultObj = mockDataRepository.Setup(x => x.Update(model)).Returns(model);
            var response = _passengerController.Put(model);
            // Assert
            Assert.AreEqual(model, response);
        }

        private static IList<TestingAssignment.Models.Passenger> GetPassengers()
        {
            Guid id1 = new Guid();
            Guid id2 = new Guid();
            Guid id3 = new Guid();
            IList<TestingAssignment.Models.Passenger> passengers = new List<TestingAssignment.Models.Passenger>()
            {
                new TestingAssignment.Models.Passenger() {Id = id1, FirstName = "Arjun", LastName = "Chandarana" ,PhoneNumber = "8735972921"},
                new TestingAssignment.Models.Passenger() { Id = id2, FirstName = "Ram", LastName = "Patel", PhoneNumber = "8735972922" },
                new TestingAssignment.Models.Passenger() { Id = id3, FirstName = "Shyam", LastName = "Rana", PhoneNumber = "8735972923" },

            };
            return passengers;
        }

        private static TestingAssignment.Models.Passenger AddPassenger()
        {
            var passenger = new TestingAssignment.Models.Passenger();
            passenger.Id = new Guid();
            passenger.FirstName = "Arjun";
            passenger.LastName = "Chandarana";
            passenger.PhoneNumber = "8735972921";
            return passenger;
        }
    }
}
