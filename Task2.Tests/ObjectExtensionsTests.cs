using NUnit.Framework;
using Task2.Tests.Entities;

namespace Task2.Tests
{
    [TestFixture]
    public class ObjectExtensionsTests
    {
        [Test]
        public void SetReadOnlyProperty_Parent_SetPropertyTo5()
        {
            var obj = new Parent();
            const int newValue = 5;

            obj.SetReadOnlyProperty(nameof(obj.Property), newValue);

            Assert.That(obj.Property, Is.EqualTo(newValue));
        }

        [Test]
        public void SetReadOnlyProperty_Child_SetPropertiesTo5and6()
        {
            var obj = new Child();
            const int propertyNewValue = 5, childPropertyNewValue = 6;

            obj.SetReadOnlyProperty(nameof(obj.Property), propertyNewValue);
            obj.SetReadOnlyProperty(nameof(obj.ChildProperty), childPropertyNewValue);

            Assert.That(obj.Property, Is.EqualTo(propertyNewValue));
            Assert.That(obj.ChildProperty, Is.EqualTo(childPropertyNewValue));
        }

        [Test]
        public void SetReadOnlyField_Parent_SetFiledTo555()
        {
            var obj = new Parent();
            const string newValue = "555";

            obj.SetReadOnlyField(nameof(obj.Filed), newValue);

            Assert.That(obj.Filed, Is.EqualTo(newValue));
        }

        [Test]
        public void SetReadOnlyField_Child_SetPropertiesTo42and22()
        {
            var obj = new Child();
            const string fieldNewValue = "42", childFieldNewValue = "22";

            obj.SetReadOnlyField(nameof(obj.Filed), fieldNewValue);
            obj.SetReadOnlyField(nameof(obj.ChildField), childFieldNewValue);

            Assert.That(obj.Filed, Is.EqualTo(fieldNewValue));
            Assert.That(obj.ChildField, Is.EqualTo(childFieldNewValue));
        }
    }
}
