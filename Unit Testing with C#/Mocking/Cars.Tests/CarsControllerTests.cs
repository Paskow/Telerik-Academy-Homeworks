namespace Cars.Tests
{
    using NUnit.Framework;
    using Moq;
    using Cars.Contracts;
    using Cars.Models;
    using Cars.Controllers;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    class CarsControllerTests
    {

        [Test]
        public void Index_ShouldCallMethodAllOneThime()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            var carsController = new CarsController(mockedCarsRepository.Object);
            mockedCarsRepository.Setup(r => r.All());

            carsController.Index();

            mockedCarsRepository.Verify(r => r.All(), Times.Once);
        }

        [Test]
        public void Add_ShouldCallMethodAllAddThime()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            var carsController = new CarsController(mockedCarsRepository.Object);
            var car = new Car() { Make = "BMW", Model = "X5" };
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(car);

            carsController.Add(car);

            mockedCarsRepository.Verify(r => r.Add(It.IsAny<Car>()), Times.Once);
        }

        [Test]
        public void Add_WhenNullCarIsPassed_ShouldThrowArgumentNullException()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            var carsController = new CarsController(mockedCarsRepository.Object);
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();

            Assert.Throws<ArgumentNullException>(() => carsController.Add(null));
        }

        [TestCase("")]
        [TestCase(null)]
        public void Add_WhenPassCarWuthNullOrEmptyMake_ShouldThrowArgumentNullException(string make)
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            var carsController = new CarsController(mockedCarsRepository.Object);
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            var car = new Car { Model = "X5", Make = make };

            Assert.Throws<ArgumentNullException>(() => carsController.Add(car));
        }

        [TestCase("")]
        [TestCase(null)]
        public void Add_WhenPassCarWithNullOrEmptyModel_ShouldThrowArgumentNullException(string model)
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            var carsController = new CarsController(mockedCarsRepository.Object);
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            var car = new Car { Make = "BMW", Model = model };

            Assert.Throws<ArgumentNullException>(() => carsController.Add(car));
        }

        [Test]
        public void Add_WhenValidCarIsPassed_ShouldReturnDetails()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            var carsController = new CarsController(mockedCarsRepository.Object);
            var car = new Car { Id = 1, Make = "BMW", Model = "X5", Year = 2010 };
            mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(car);

            var details = (Car)carsController.Add(car).Model;

            Assert.AreEqual(1, details.Id);
            Assert.AreEqual(2010, details.Year);
            Assert.AreEqual("BMW", details.Make);
            Assert.AreEqual("X5", details.Model);
        }

        [Test]
        public void Search_ShouldCallSearchOnce()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            var carsController = new CarsController(mockedCarsRepository.Object);
            mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>())).Returns(new List<Car>());

            carsController.Search("condition");

            mockedCarsRepository.Verify(r => r.Search(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Details_ShouldCallGetByIdOnce()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            var carsController = new CarsController(mockedCarsRepository.Object);
            var car = new Car { Id = 1, Make = "BMW", Model = "X5", Year = 2010 };
            mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(car);

            carsController.Details(5);

            mockedCarsRepository.Verify(r => r.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void Details_WhenNoexistingIDIsPassed_ShouldThrowArgumentNullException()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            var carsController = new CarsController(mockedCarsRepository.Object);
            var car = new Car { Id = 1, Make = "BMW", Model = "X5", Year = 2010 };
            mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>()));

            Assert.Throws<ArgumentNullException>(() => carsController.Details(4));
        }

        [TestCase("make")]
        [TestCase("Make")]
        public void Sort_WhenMakeConditionIsPassed_ShouldCallSortedByMakeOnce(string parameter)
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            var carsController = new CarsController(mockedCarsRepository.Object);
            mockedCarsRepository.Setup(r => r.SortedByMake()).Returns(new List<Car>());

            carsController.Sort(parameter);

            mockedCarsRepository.Verify(r => r.SortedByMake(), Times.Once);
        }

        [TestCase("year")]
        [TestCase("Year")]
        public void Sort_WhenYearConditionIsPassed_ShouldCallSortedByMakeOnce(string parameter)
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            var carsController = new CarsController(mockedCarsRepository.Object);
            mockedCarsRepository.Setup(r => r.SortedByYear()).Returns(new List<Car>());

            carsController.Sort(parameter);

            mockedCarsRepository.Verify(r => r.SortedByYear(), Times.Once);
        }

        [Test]
        public void Sort_WhenInvalidConditionIsPassed_ShouldThrowArgumentException()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            var carsController = new CarsController(mockedCarsRepository.Object);
            mockedCarsRepository.Setup(r => r.SortedByYear()).Returns(new List<Car>());

            Assert.Throws<ArgumentException>(() => carsController.Sort("Pesho"));
        }
    }
}
