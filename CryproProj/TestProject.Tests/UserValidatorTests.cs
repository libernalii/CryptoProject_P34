using CryptoProj.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Tests
{
    public class UserValidatorTests
    {
        private readonly UserValidator _validator = new UserValidator();

        [Theory]
        [InlineData("Alina", true)]
        [InlineData("Alina_123", true)]
        [InlineData("Alina-123", false)]
        [InlineData("Alina@", false)]
        [InlineData("", false)]
        public void ValidateName_TestCases(string name, bool expected)
        {
            var result = _validator.ValidateName(name);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Abcdef!♈I", true)]
        [InlineData("abcdef!♈I", false)]
        [InlineData("ABCDEF!♈I", false)]
        [InlineData("AbcdefgI", false)]
        [InlineData("Abcdef!I", false)]
        [InlineData("Abcdef!♈", false)]
        [InlineData("Ab!♈I", false)]
        public void ValidatePassword_TestCases(string password, bool expected)
        {
            var result = _validator.ValidatePassword(password);
            Assert.Equal(expected, result);
        }
    }
}
