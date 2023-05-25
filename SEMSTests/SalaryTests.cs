
using SEMS.Domain;

namespace SEMSTests
{
    [TestClass]
    public class SalaryTests
    {
        

        [TestMethod]
        public void CalculateNetSalary_ValidInput_ReturnsCorrectResult()
        {
            // Arrange
            var salary = new Salary(1000m, 200m, 50m, "USD");

            // Act
            decimal result = salary.CalculateNetSalary();

            // Assert
            Assert.AreEqual(1150m, result);
        }

        [TestMethod]
        public void CalculateAnnualSalary_ValidInput_ReturnsCorrectResult()
        {
            // Arrange
            var salary = new Salary(1000m, 200m, 50m, "USD");

            // Act
            decimal result = salary.CalculateAnnualSalary(14);

            // Assert
            Assert.AreEqual(14000m, result);
        }

        [TestMethod]
        public void CalculateAnnualNetSalary_ValidInput_ReturnsCorrectResult()
        {
            // Arrange
            var salary = new Salary(1000m, 200m, 50m, "USD");

            // Act
            decimal result = salary.CalculateAnnualNetSalary(12);

            // Assert
            Assert.AreEqual(13800m, result);
        }

        [TestMethod]
        public void CalculateHourlySalary_ValidInput_ReturnsCorrectResult()
        {
            // Arrange
            var salary = new Salary(1000m, 200m, 50m, "USD");

            // Act
            decimal result = salary.CalculateHourlySalary(20, 8);

            // Assert
            Assert.AreEqual(6.25m, result);
        }

        [TestMethod]
        public void CalculateHourlyNetSalary_ValidInput_ReturnsCorrectResult()
        {
            // Arrange
            var salary = new Salary(1000m, 200m, 50m, "USD");

            // Act
            decimal result = salary.CalculateHourlyNetSalary(20, 8);

            // Assert
            Assert.AreEqual(7.1875m, result);
        }
    }

}