using Combis.Backend.Models;
using Combis.Backend.Utilities.Validations;
using Xunit;

namespace Combis.Backend.Tests
{
    public class ValidationTests
    {
        private PersonValidation _validator;
        public ValidationTests()
        {
            _validator = new PersonValidation();
        }

        [Fact]
        public void PersonInstanceIsValid()
        {
            Person person = new Person()
            {
                Name = "Antonio",
                Surname = "Halužan",
                PhoneNumber = "+385959180338",
                ZipCode = 10000,
                City = "Zagreb"
            };

            var result = _validator.Validate(person);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void NameIsNotValid()
        {
            Person person = new Person()
            {
                Name = "",
                Surname = "Halužan",
                PhoneNumber = "+385959180338",
                ZipCode = 10000,
                City = "Zagreb"
            };

            var result = _validator.Validate(person);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void SurnameIsNotValid()
        {
            Person person = new Person()
            {
                Name = "Antonio",
                Surname = "",
                PhoneNumber = "+385959180338",
                ZipCode = 10000,
                City = "Zagreb"
            };

            var result = _validator.Validate(person);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void PhoneNumberIsNotValid()
        {
            Person person = new Person()
            {
                Name = "Antonio",
                Surname = "Halužan",
                PhoneNumber = "385959180338",
                ZipCode = 10000,
                City = "Zagreb"
            };

            var result = _validator.Validate(person);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void ZipCodeIsNotValid()
        {
            Person person = new Person()
            {
                Name = "Antonio",
                Surname = "Halužan",
                PhoneNumber = "+385959180338",
                ZipCode = -1,
                City = "Zagreb"
            };

            var result = _validator.Validate(person);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void CityIsNotValid()
        {
            Person person = new Person()
            {
                Name = "Antonio",
                Surname = "Halužan",
                PhoneNumber = "+385959180338",
                ZipCode = 10000,
                City = ""
            };

            var result = _validator.Validate(person);

            Assert.False(result.IsValid);
        }
    }
}
