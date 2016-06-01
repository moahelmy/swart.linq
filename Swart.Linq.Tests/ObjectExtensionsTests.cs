using System;
using System.Linq;
using NUnit.Framework;
using Swart.Linq.Tests.Classes;

namespace Swart.Linq.Tests
{
    public class ObjectExtensionsTests
    {
        [TestFixture]
        public class GetAllPropertiesOfType
        {
            [Test]
            public void MultiplePropsOfSameType_ReturnsAll()
            {
                // Arrange
                // Name class already created with two string properties

                // Act
                var props = typeof (Name).GetAllPropertiesOfType(typeof (String));

                // Assert
                Assert.AreEqual(2, props.Count());
            }

            [Test]
            public void MultiplePropsTypes_ReturnsOnlyTestedType()
            {
                // Arrange
                // Person class already created with one Person property and one Date prop

                // Act
                var props = typeof (Person).GetAllPropertiesOfType(typeof (Name));

                // Assert
                Assert.AreEqual(1, props.Count());
            }

            [Test]
            public void OneDrivedProperty_ReturnsIt()
            {
                // Arrange
                // Person class already created with one Person property and one Date prop

                // Act
                var props = typeof(School).GetAllPropertiesOfType(typeof(Person));

                // Assert
                Assert.AreEqual(1, props.Count());
            }    
        }
    }
}
