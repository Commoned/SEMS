
using System.ComponentModel.DataAnnotations;

namespace SEMSTests
{
    [TestClass]
    public class InputValidatorTests
    {
        [TestMethod]
        public void Validate_ValidZipCode_ReturnsTrue()
        {
            // Arrange
            string input = "12345";

            // Act
            bool result = ZipcodeValidator.IsValid(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_InvalidZipCode_ReturnsFalse()
        {
            // Arrange
            string input = "Not-A-Zipcode";

            // Act
            bool result = ZipcodeValidator.IsValid(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NameValidator_ValidInput_ReturnsTrue()
        {
            // Arrange
            string input = "Daniel Ringler";

            // Act
            bool result = NameValidator.IsValid(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NameValidator_InvalidInput_ReturnsFalse()
        {
            // Arrange
            string input = "Tim.F123";

            // Act
            bool result = NameValidator.IsValid(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StreetNumberValidator_ValidInput_ReturnsTrue()
        {
            // Arrange
            string input = "123A";

            // Act
            bool result = StreetNumberValidator.IsValid(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StreetNumberValidator_InvalidInput_ReturnsFalse()
        {
            // Arrange
            string input = "A123";

            // Act
            bool result = StreetNumberValidator.IsValid(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ThreeUpperValidator_ValidInput_ReturnsTrue()
        {
            // Arrange
            string input = "EUR";

            // Act
            bool result = ThreeUpperValidator.IsValid(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ThreeUpperValidator_InvalidInput_ReturnsFalse()
        {
            // Arrange
            string input = "ABCD2";

            // Act
            bool result = ThreeUpperValidator.IsValid(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SalaryValidator_ValidInput_ReturnsTrue()
        {
            // Arrange
            string input = "10,10";

            // Act
            bool result = SalaryValidator.IsValid(input);

            // Assert
            Assert.IsTrue(result);
        }

    }
}
