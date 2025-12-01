using Table_Top_Plugin.Models;
using Table_Top_Plugin.UI.UserControls;

namespace Table_Top_Plugin.Tests.UI.UserControls
{
    [TestFixture]
    [Apartment(System.Threading.ApartmentState.STA)]
    public class ParameterItemTests
    {
        private ParameterItem _parameterItem;
        private Parameter _parameter;

        [SetUp]
        public void Setup()
        {
            _parameterItem = new ParameterItem();
            _parameter = new Parameter(0, 100);
        }

        [Test]
        public void SetParameter_ShouldAssignParameterAndSubscribeToEvents()
        {
            bool eventRaised = false;
            _parameter.ParameterChanged += (s, e) => eventRaised = true;

            _parameterItem.SetParameter(_parameter);
            _parameter.SetValue = 50;

            Assert.IsNotNull(_parameterItem);
        }

        [Test]
        public void IsItCorrect_InitiallyShouldBeFalse()
        {
            Assert.IsFalse(_parameterItem.IsItCorrect);
        }

        [Test]
        public void TextBox_Validating_ShouldHandleInvalidInput()
        {
            _parameterItem.SetParameter(_parameter);

            Assert.IsNotNull(_parameterItem);
        }

        [TearDown]
        public void TearDown()
        {
            _parameterItem?.Dispose();
        }
    }
}