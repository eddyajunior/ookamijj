using FluentAssertions;
using OokamiJJ.Domain.Entities;

namespace OokamiJJ.Tests.Entities
{
    public class StudentTests
    {
        [Fact]
        public void Validate_ShouldReturnTrue_WhenAllFieldsAreValid()
        {
            // Arrange
            var student = new Student("John Doe", new DateTime(2000, 1, 1), "Parent", "john.doe@example.com", "1234567890", Guid.NewGuid());

            // Act
            var result = student.Validate();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ValidateName_ShouldReturnTrue_WhenNameIsValid()
        {
            // Arrange
            var student = new Student("James Stwart", new DateTime(2000, 1, 1), "Parent", "john.doe@example.com", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateName();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ValidateName_ShouldReturnFalse_WhenNameIsNullOrEmpty()
        {
            // Arrange
            var student = new Student("", new DateTime(2000, 1, 1), "Parent", "john.doe@example.com", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateName();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateName_ShouldReturnFalse_WhenNameIsTooShort()
        {
            // Arrange
            var student = new Student("John", new DateTime(2000, 1, 1), "Parent", "john.doe@example.com", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateName();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateName_ShouldReturnFalse_WhenNameIsTooLong()
        {
            // Arrange
            var student = new Student(new string('a', 51), new DateTime(2000, 1, 1), "Parent", "john.doe@example.com", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateName();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateBornDate_ShouldReturnTrue_WhenBornDateIsValid()
        {
            // Arrange
            var student = new Student("John Doe", DateTime.UtcNow, "Parent", "john.doe@example.com", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateBornDate();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ValidateBornDate_ShouldReturnFalse_WhenBornDateIsDefault()
        {
            // Arrange
            var student = new Student("John Doe", default, "Parent", "john.doe@example.com", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateBornDate();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateBornDate_ShouldReturnFalse_WhenBornDateIsInTheFuture()
        {
            // Arrange
            var student = new Student("John Doe", DateTime.Now.AddDays(1), "Parent", "john.doe@example.com", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateBornDate();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateResponsibleFor_ShouldReturnTrue_WhenResponsibleForIsValid()
        {
            // Arrange
            var student = new Student("John Doe", new DateTime(2000, 1, 1), "Mike Rogers", "john.doe@example.com", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateResponsibleFor();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ValidateResponsibleFor_ShouldReturnFalse_WhenResponsibleForIsNullOrEmpty()
        {
            // Arrange
            var student = new Student("John Doe", new DateTime(2000, 1, 1), "", "john.doe@example.com", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateResponsibleFor();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateResponsibleFor_ShouldReturnFalse_WhenResponsibleForIsTooShort()
        {
            // Arrange
            var student = new Student("John Doe", new DateTime(2000, 1, 1), "Par", "john.doe@example.com", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateResponsibleFor();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateResponsibleFor_ShouldReturnFalse_WhenResponsibleForIsTooLong()
        {
            // Arrange
            var student = new Student("John Doe", new DateTime(2000, 1, 1), new string('a', 51), "john.doe@example.com", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateResponsibleFor();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateEmail_ShouldReturnTrue_WhenEmailIsValid()
        {
            // Arrange
            var student = new Student("John Doe", new DateTime(2000, 1, 1), "Parent", "teste@teste.com", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateEmail();

            // Assert
            result.Should().BeTrue();
        }


        [Fact]
        public void ValidateEmail_ShouldReturnFalse_WhenEmailIsNullOrEmpty()
        {
            // Arrange
            var student = new Student("John Doe", new DateTime(2000, 1, 1), "Parent", "", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateEmail();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateEmail_ShouldReturnFalse_WhenEmailIsInvalid()
        {
            // Arrange
            var student = new Student("John Doe", new DateTime(2000, 1, 1), "Parent", "invalid-email", "1234567890", Guid.NewGuid());

            // Act
            var result = student.ValidateEmail();

            // Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("11999999999")]
        [InlineData("1199999999")]
        public void ValidatePhone_ShouldReturnTrue_WhenPhoneIsValid(string phoneNumber)
        {
            // Arrange
            var student = new Student("John Doe", new DateTime(2000, 1, 1), "Parent", "john.doe@example.com", phoneNumber, Guid.NewGuid());

            // Act
            var result = student.ValidatePhone();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ValidatePhone_ShouldReturnFalse_WhenPhoneIsNullOrEmpty()
        {
            // Arrange
            var student = new Student("John Doe", new DateTime(2000, 1, 1), "Parent", "john.doe@example.com", "", Guid.NewGuid());

            // Act
            var result = student.ValidatePhone();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidatePhone_ShouldReturnFalse_WhenPhoneIsTooShort()
        {
            // Arrange
            var student = new Student("John Doe", new DateTime(2000, 1, 1), "Parent", "john.doe@example.com", "123456789", Guid.NewGuid());

            // Act
            var result = student.ValidatePhone();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidatePhone_ShouldReturnFalse_WhenPhoneIsTooLong()
        {
            // Arrange
            var student = new Student("John Doe", new DateTime(2000, 1, 1), "Parent", "john.doe@example.com", "123456789012", Guid.NewGuid());

            // Act
            var result = student.ValidatePhone();

            // Assert
            result.Should().BeFalse();
        }
    }
}
