using Table_Top_Plugin.Services;
using Moq;

namespace Table_Top_Plugin.Tests
{
    [TestFixture]
    [Apartment(System.Threading.ApartmentState.STA)]
    public class MainFormTests
    {
        private MainForm _mainForm;
        private Mock<TableTopBuilder> _mockBuilder;

        [SetUp]
        public void Setup()
        {
            _mockBuilder = new Mock<TableTopBuilder>();
            _mainForm = new MainForm();

            var field = typeof(MainForm).GetField("_builder",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field?.SetValue(_mainForm, _mockBuilder.Object);
        }

        [Test]
        public void Constructor_ShouldInitializeParameters()
        {
            Assert.IsNotNull(_mainForm);
            Assert.IsTrue(_mainForm.Controls.Count > 0);
        }

        [TearDown]
        public void TearDown()
        {
            _mainForm?.Dispose();
        }
    }
}