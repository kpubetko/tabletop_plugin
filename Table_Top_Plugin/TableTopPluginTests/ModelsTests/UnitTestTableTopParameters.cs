using Table_Top_Plugin.Models;

namespace Table_Top_Plugin.Tests.Models
{
    //TODO: XML
    public class TableTopParametersTests
    {
        //TODO: XML
        private TableTopParameters _tableTopParams;

        //TODO: remove
        [SetUp]
        public void Setup()
        {
            _tableTopParams = new TableTopParameters();
        }

        //TODO: description
        [Test]
        public void Constructor_ShouldInitializeAllParametersWithCorrectRanges()
        {
            Assert.AreEqual(1000, _tableTopParams.GetLength.GetMin);
            Assert.AreEqual(2500, _tableTopParams.GetLength.GetMax);

            Assert.AreEqual(1000, _tableTopParams.GetWidth.GetMin);
            Assert.AreEqual(2500, _tableTopParams.GetWidth.GetMax);

            Assert.AreEqual(15, _tableTopParams.GetHeight.GetMin);
            Assert.AreEqual(50, _tableTopParams.GetHeight.GetMax);

            Assert.AreEqual(0, _tableTopParams.GetCornerRadius.GetMin);
            Assert.AreEqual(0, _tableTopParams.GetCornerRadius.GetMax);

            Assert.AreEqual(0, _tableTopParams.GetChamferRadius.GetMin);
            Assert.AreEqual(0, _tableTopParams.GetChamferRadius.GetMax);
        }

        //TODO: description
        [Test]
        public void LengthOrWidthChanged_WhenLengthLessThanWidth_ShouldUpdateCornerRadiusMax()
        {
            _tableTopParams.GetLength.SetValue = 1500;
            _tableTopParams.GetWidth.SetValue = 2000;

            _tableTopParams.GetLength.SetValue = 1800;

            Assert.AreEqual(900, _tableTopParams.GetCornerRadius.GetMax);
        }

        //TODO: description
        [Test]
        public void LengthOrWidthChanged_WhenWidthLessThanLength_ShouldUpdateCornerRadiusMax()
        {
            _tableTopParams.GetLength.SetValue = 2000;
            _tableTopParams.GetWidth.SetValue = 1500;

            _tableTopParams.GetWidth.SetValue = 1600;

            Assert.AreEqual(800, _tableTopParams.GetCornerRadius.GetMax);
        }

        //TODO: description
        [Test]
        public void HeightChanged_ShouldUpdateChamferRadiusMax()
        {
            _tableTopParams.GetHeight.SetValue = 30;

            _tableTopParams.GetHeight.SetValue = 40;

            Assert.AreEqual(20, _tableTopParams.GetChamferRadius.GetMax);
        }

        //TODO: description
        [Test]
        public void GetLength_ShouldReturnLengthParameter()
        {
            Assert.IsNotNull(_tableTopParams.GetLength);
            Assert.AreEqual(1000, _tableTopParams.GetLength.GetMin);
        }

        //TODO: description
        [Test]
        public void GetWidth_ShouldReturnWidthParameter()
        {
            Assert.IsNotNull(_tableTopParams.GetWidth);
            Assert.AreEqual(1000, _tableTopParams.GetWidth.GetMin);
        }

        //TODO: description
        [Test]
        public void GetHeight_ShouldReturnHeightParameter()
        {
            Assert.IsNotNull(_tableTopParams.GetHeight);
            Assert.AreEqual(15, _tableTopParams.GetHeight.GetMin);
        }

        //TODO: description
        [Test]
        public void GetCornerRadius_ShouldReturnCornerRadiusParameter()
        {
            Assert.IsNotNull(_tableTopParams.GetCornerRadius);
            Assert.AreEqual(0, _tableTopParams.GetCornerRadius.GetMin);
        }

        //TODO: description
        [Test]
        public void GetChamferRadius_ShouldReturnChamferRadiusParameter()
        {
            Assert.IsNotNull(_tableTopParams.GetChamferRadius);
            Assert.AreEqual(0, _tableTopParams.GetChamferRadius.GetMin);
        }

        //TODO: description
        [Test]
        public void MultipleParameterChanges_ShouldProperlyUpdateDependentParameters()
        {
            _tableTopParams.GetLength.SetValue = 1200;
            _tableTopParams.GetWidth.SetValue = 1800;
            _tableTopParams.GetHeight.SetValue = 20;

            _tableTopParams.GetCornerRadius.SetValue = 300;
            _tableTopParams.GetChamferRadius.SetValue = 5;

            Assert.AreEqual(300, _tableTopParams.GetCornerRadius.GetValue);
            Assert.AreEqual(5, _tableTopParams.GetChamferRadius.GetValue);
        }

        //TODO: description
        [Test]
        public void EventHandlers_ShouldBeConnectedAfterConstructor()
        {
            bool lengthEventRaised = false;
            bool widthEventRaised = false;
            bool heightEventRaised = false;

            //TODO: RSDN
            _tableTopParams.GetLength.ParameterChanged += (s, e) => lengthEventRaised = true;
            _tableTopParams.GetWidth.ParameterChanged += (s, e) => widthEventRaised = true;
            _tableTopParams.GetHeight.ParameterChanged += (s, e) => heightEventRaised = true;

            _tableTopParams.GetLength.SetValue = 1500;
            _tableTopParams.GetWidth.SetValue = 1500;
            _tableTopParams.GetHeight.SetValue = 25;

            Assert.IsTrue(lengthEventRaised);
            Assert.IsTrue(widthEventRaised);
            Assert.IsTrue(heightEventRaised);
        }
    }
}