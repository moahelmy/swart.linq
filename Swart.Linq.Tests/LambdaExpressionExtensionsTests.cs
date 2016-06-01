using System;
using System.Linq.Expressions;
using NUnit.Framework;
using Swart.Linq.Tests.Classes;

namespace Swart.Linq.Tests
{
    public class LambdaExpressionExtensionsTests
    {
        [TestFixture]
        public class GetMemberName
        {
            [Test]
            public void ArrayLength_ReturnsLength()
            {
                // Arrange
                Expression<Func<string[], int>> lenExp = arr => arr.Length;

                // Act                
                var name = lenExp.GetMemberName();

                // Assert
                Assert.AreEqual("Length", name);
            }

            [Test]
            public void Property_ReturnsPropName()
            {
                // Arrange
                Expression<Func<Person,DateTime>> exp = p =>p.DateOfBirth;

                // Act                
                var name = exp.GetMemberName();

                // Assert
                Assert.AreEqual("DateOfBirth", name);
            }

            [Test]
            public void Method_ReturnsMethodName()
            {
                // Arrange
                Expression<Func<Person, int>> exp = p => p.GetAge();

                // Act                
                var name = exp.GetMemberName();

                // Assert
                Assert.AreEqual("GetAge", name);
            }

            [Test]
            public void ChainEndsWithProp_ReturnsPropName()
            {
                // Arrange
                Expression<Func<Person, string>> exp = p => p.PersonName.FirstName;

                // Act                
                var name = exp.GetMemberName();

                // Assert
                Assert.AreEqual("FirstName", name);
            }

            [Test]
            public void MethChainEndsWithProp_ReturnsPropName()
            {
                // Arrange
                Expression<Func<Person, string>> exp = p => p.GetName().FirstName;

                // Act                
                var name = exp.GetMemberName();

                // Assert
                Assert.AreEqual("FirstName", name);
            }
        }

        [TestFixture]
        public class GetMemberNameForPropertiesOrFieldsOnly
        {
            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void Method_ReturnsMethodName()
            {
                // Arrange
                Expression<Func<Person, int>> exp = p => p.GetAge();

                // Act                
                var name = exp.GetMemberNameForPropertiesOrFieldsOnly();
            }
        }
    }
}
