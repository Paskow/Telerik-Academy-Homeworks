namespace Cars.Tests
{
    using System;
    using NUnit.Framework;
    using Cars.Models;
    using Cars.Data;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class CarsRepositoryTests
    {
        [Test]
        public void AddCarsToRepository_WhenValidCarIsPassed_ShouldAddCarSuccessfully()
        {
            // Arrange
            var carsRepository = new CarsRepository();

            // Act
            carsRepository.Add(new Car());

            // Assert
            Assert.AreEqual(1, carsRepository.TotalCars);
        }

        [Test]
        public void AddCarsToRepository_WhenNullCarIsPassed_ShouldThrowArgumentException()
        {
            // Arrange
            var carsRepository = new CarsRepository();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => carsRepository.Add(null));
        }

        [Test]
        public void RemoveCarsFromRepository_WhenRemoveExistingCar_ShouldRemoveCarSuccessfully()
        {
            // Arrange
            var carsRepository = new CarsRepository();
            var car = new Car();

            // Actt
            carsRepository.Add(car);
            carsRepository.Remove(car);

            // Assert
            Assert.AreEqual(0, carsRepository.TotalCars);
        }

        [Test]
        public void RemoveCarsFromRepository_WhenRemoveNullCar_ShouldThrowArgumentException()
        {
            // Arrange
            var carsRepository = new CarsRepository();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => carsRepository.Remove(null));
        }

        [Test]
        public void RemoveCarsFromRepository_WhenRemoveNoexistingCar_ShouldThrowArgumentException()
        {
            // Arrange
            var carsRepository = new CarsRepository();

            // Act and Assert 
            Assert.Throws<ArgumentException>(() => carsRepository.Remove(new Car()));
        }

        [Test]
        public void GetById_WhenCarDoesNotExist_ShouldThrowArgumentException()
        {
            // Arrange
            var carsRepository = new CarsRepository();

            // Act and Assert 
            Assert.Throws<ArgumentException>(() => carsRepository.GetById(5));
        }

        [Test]
        public void GetById_WhenCarIsInData_ShouldReturnCarSuccessfully()
        {
            // Arrange
            var carsRepository = new CarsRepository();
            var car = new Car { Id = 2 };

            // Act
            carsRepository.Add(car);

            //Assert 
            Assert.AreEqual(car, carsRepository.GetById(2));
        }

        [Test]
        public void All_WhenDataIsEmpty_SouldReturnEmptyCollection()
        {
            // Arrange
            var carsRepository = new CarsRepository();

            //Act and Assert
            Assert.AreEqual(0, carsRepository.All().Count);
        }

        [Test]
        public void All_WhenDataIsNotEmpty_SouldReturnCollectionWithCars()
        {
            // Arrange
            var carsRepository = new CarsRepository();
            var bmw = new Car { Make = "BMW", Id = 5 };
            var audi = new Car { Make = "Audi", Id = 2 };
            var nissan = new Car { Make = "Nissan", Id = 4 };
            //Act 
            carsRepository.Add(bmw);
            carsRepository.Add(audi);
            carsRepository.Add(nissan);

            // Assert
            Assert.AreEqual(3, carsRepository.All().Count);
        }

        [Test]
        public void SortedByMake_WhenDataIsNotEmpty_SouldReturnCollectionWithSortedCarsByMake()
        {
            // Arrange
            var carsRepository = new CarsRepository();
            var bmw = new Car { Make = "BMW" };
            var audi = new Car { Make = "Audi" };
            var nissan = new Car { Make = "Nissan"};
            var cars = new List<Car>
            {
                bmw,
                nissan,
                audi
            };

            //Act 
            carsRepository.Add(bmw);
            carsRepository.Add(audi);
            carsRepository.Add(nissan);
            cars = cars.OrderBy(c => c.Make).ToList();

            // Assert
            Assert.AreEqual(cars as ICollection, carsRepository.SortedByMake());
        }

        [Test]
        public void SortedByYear_WhenDataIsNotEmpty_SouldReturnCollectionWithSortedCarsByYear()
        {
            // Arrange
            var carsRepository = new CarsRepository();
            var bmw = new Car { Year = 1999 };
            var audi = new Car { Year = 1980 };
            var nissan = new Car { Year = 1970 };
            var cars = new List<Car>
            {
                bmw,
                nissan,
                audi
            };

            //Act 
            carsRepository.Add(bmw);
            carsRepository.Add(audi);
            carsRepository.Add(nissan);
            cars = cars.OrderByDescending(c => c.Year).ToList();

            // Assert
            Assert.AreEqual(cars as ICollection, carsRepository.SortedByYear());
        }

        [TestCase("Audi")]
        [TestCase("X5")]
        public void Search_WhenValidConditionIsPassed_ShouldReturnCollctionWithCarsMatchingCondition(string condition)
        {
            // Arrange
            var carsRepository = new CarsRepository();
            var bmw = new Car { Model = "X5" };
            var audi = new Car { Make = "Audi" };
            var cars = new List<Car>
            {
                bmw,
                audi
            };

            //Act 
            carsRepository.Add(bmw);
            carsRepository.Add(audi);

            //Assert

            Assert.AreEqual(1, carsRepository.Search(condition).Count);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Search_WhenInValidConditionIsPassed_ShouldThrowException(string condition)
        {
            // Arrange
            var carsRepository = new CarsRepository();

            // Act and Assert 
            Assert.Throws<ArgumentException>(() => carsRepository.Search(condition));
        }
    }
}
