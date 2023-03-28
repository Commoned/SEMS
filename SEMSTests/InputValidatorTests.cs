
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
            var strategy = new ZipcodeValidator();
            var validator = new InputValidator(strategy);
            string input = "12345";

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_InvalidZipCode_ReturnsFalse()
        {
            // Arrange
            var strategy = new ZipcodeValidator();
            var validator = new InputValidator(strategy);
            string input = "ABCDE";

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NameValidator_ValidInput_ReturnsTrue()
        {
            // Arrange
            var validator = new InputValidator(new NameValidator());
            string input = "Daniel Ringler";

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NameValidator_InvalidInput_ReturnsFalse()
        {
            // Arrange
            var validator = new InputValidator(new NameValidator());
            string input = "Tim.F123";

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StreetNumberValidator_ValidInput_ReturnsTrue()
        {
            // Arrange
            var validator = new InputValidator(new StreetNumberValidator());
            string input = "123A";

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StreetNumberValidator_InvalidInput_ReturnsFalse()
        {
            // Arrange
            var validator = new InputValidator(new StreetNumberValidator());
            string input = "A123";

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ThreeUpperValidator_ValidInput_ReturnsTrue()
        {
            // Arrange
            var validator = new InputValidator(new ThreeUpperValidator());
            string input = "EUR";

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ThreeUpperValidator_InvalidInput_ReturnsFalse()
        {
            // Arrange
            var validator = new InputValidator(new ThreeUpperValidator());
            string input = "ABCD2";

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SalaryValidator_ValidInput_ReturnsTrue()
        {
            // Arrange
            var validator = new InputValidator(new SalaryValidator());
            string input = "10,10";

            // Act
            bool result = validator.Validate(input);

            // Assert
            Assert.IsTrue(result);
        }

    }
}
