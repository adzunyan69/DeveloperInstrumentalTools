using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class Tests
    {
        [Test]
        public void GetWorkingToday_RealLogic_Friday_ReturnsMonday()
        {
            // Arrange
            var today = new DateTime(2020, 10, 10);

            var service = new CalendarService(new DayShiftService(new DayOfWeekService()));
            
            // Act
            var result = service.GetWorkingTomorrow(today);
            
            // Assert
            result.Should().Be(new DateTime(2020, 10, 12));
        }
        
        [Test]
        public void GetWorkingToday_AllDatesWorking_ReturnsTomorrow()
        {
            // Arrange
            var today = new DateTime(2020, 10, 02);

            var dayOfWeekService = new Mock<IDayOfWeekService>();
            dayOfWeekService
                .Setup(x => x.IsWeekend(It.IsAny<DateTime>()))
                .Returns(false);

            var service = new CalendarService(new DayShiftService(dayOfWeekService.Object));
            
            // Act
            var result = service.GetWorkingTomorrow(today);

            // Assert
            result.Should().Be(new DateTime(2020, 10, 05));
            // result.Should().Be(new DateTime(2020, 10, 03));
        }

        [Test]
        public void GetWorkingYesterday_Friday_ReturnsThursday()
        {
            // Arrange
            var today = new DateTime(2020, 11, 13);

            var service = new CalendarService(new DayShiftService(new DayOfWeekService()));

            // Act
            var result = service.GetWorkingYesterday(today);

            // Assert
            result.Should().Be(new DateTime(2020, 11, 12));
        }

        [Test]
        public void GetWorkingYeterday_AllDatesIsWorking_ReturnsYesterday()
        {
            // Arrange, Monday
            var today = new DateTime(2020, 11, 9);

            var dayOfWeekService = new Mock<IDayOfWeekService>();
            dayOfWeekService
                .Setup(x => x.IsWeekend(It.IsAny<DateTime>()))
                .Returns(false);

            var service = new CalendarService(new DayShiftService(dayOfWeekService.Object));

            // Act
            var result = service.GetWorkingYesterday(today);

            // Assert 
            result.Should().Be(new DateTime(2020, 11, 8));
        }

        [Test]
        public void GetWorkingYesterday_Monday_ReturnsFriday()
        {
            // Arrange, Monday
            var today = new DateTime(2020, 11, 9);
            var service = new CalendarService(new DayShiftService(new DayOfWeekService()));

            // Act
            var result = service.GetWorkingYesterday(today);

            // Assert
            result.Should().Be(new DateTime(2020, 11, 6));
        }

        [Test]
        public void GetWorkingTomorrow_Friday_ReturnsMonday()
        {
            // Arrange, Friday
            var today = new DateTime(2020, 11, 13);

            var service = new CalendarService(new DayShiftService(new DayOfWeekService()));

            // Act
            var result = service.GetWorkingTomorrow(today);

            // Assert
            result.Should().Be(new DateTime(2020, 11, 16));
        }

        [Test]
        public void GetWorkingTomorrow_Monday_ReturnsTuesday()
        {
            // Arrange, Friday
            var today = new DateTime(2020, 11, 9);

            var service = new CalendarService(new DayShiftService(new DayOfWeekService()));

            // Act
            var result = service.GetWorkingTomorrow(today);

            // Assert
            result.Should().Be(new DateTime(2020, 11, 10));
        }
    }
}