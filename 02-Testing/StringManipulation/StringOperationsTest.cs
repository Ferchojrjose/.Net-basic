using Humanizer;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;


namespace StringManipulation
{

    public class StringOperationsTest()
    {

        [Fact]
        public void ConcatenateStringsTest()
        {
            // Arrange
            var stringOperations = new StringOperations();
    
            // Act
            var result = stringOperations.ConcatenateStrings("Hello", "World");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello World", result);
        }


        [Fact]
        public void IsPalindromeTest_True()
        {
            // Arrange
            var stringOperations = new StringOperations();
    
            // Act
            var result = stringOperations.IsPalindrome("racecar");

            // Assert
            Assert.True(result);
        }


        [Fact]
        public void IsPalindromeTest_False()
        {
            // Arrange
            var stringOperations = new StringOperations();
    
            // Act
            var result = stringOperations.IsPalindrome("hello");

            // Assert
            Assert.False(result);
        }


        [Fact]
        public void RemoveWhitespaceTest()
        {
            // Arrange
            var stringOperations = new StringOperations();
    
            // Act
            var result = stringOperations.RemoveWhitespace("Hello World");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("HelloWorld", result);
        }


        [Fact]
        public void QuantintyInWordsTest()
        {
            //Arrange
            var stringOperations = new StringOperations();

            //Act
            var result = stringOperations.QuantintyInWords("perro", 100);

            //Assert
            Assert.StartsWith("cien", result);
            Assert.Contains("perro", result);

        }


        [Fact]
        public void GetStringLengthTest()
        {
            // Arrange
            var stringOperations = new StringOperations();
    
            // Act
            var result = stringOperations.GetStringLength("Hello World");

            // Assert
            Assert.Equal(11, result);

        }


        [Fact]
        public void GetStringLengthTest_Exeption()
        {
            // Arrange
            var stringOperations = new StringOperations();
    
            // Assert
            Assert.ThrowsAny<ArgumentNullException>(() => stringOperations.GetStringLength(null));

        }


        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("XX", 20)]
        public void FromRomanToNumberTest(string romanNumber, int expected)
        {
            // Arrange
            var stringOperations = new StringOperations();
    
            // Act
            var result = stringOperations.FromRomanToNumber(romanNumber);

            // Assert
            Assert.Equal(expected, result);

        }


        [Fact]
        public void CountOccurrencesTest()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var stringOperations = new StringOperations(mockLogger.Object);
    
            // Act
            var result = stringOperations.CountOccurrences("Hello World", 'l');

            // Assert
            Assert.Equal(3, result);
        }


        [Fact]
        public void ReadFileTest()
        {
            // Arrange
            var stringOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();

            mockFileReader.Setup(fr => fr.ReadString(It.IsAny<string>())).Returns("Hello World");
    
            // Act
            var result = stringOperations.ReadFile(mockFileReader.Object, "test.txt");

            // Assert
            Assert.Equal("Hello World", result);
        }

        

    }

}