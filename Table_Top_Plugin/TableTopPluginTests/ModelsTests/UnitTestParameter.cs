using Table_Top_Plugin.Models;

namespace Table_Top_PluginTests.ModelsTests
{
    //TODO: XML
    public class ParameterTests
    {
        //TODO: description
        [Test]
        public void Constructor_ShouldInitializeWithCorrectBoundaries()
        {
            var parameter = new Parameter(10.0, 20.0);

            Assert.AreEqual(10.0, parameter.GetMin);
            Assert.AreEqual(20.0, parameter.GetMax);
            Assert.AreEqual(0.0, parameter.GetValue);
        }

        //TODO: description
        [Test]
        public void Constructor_WhenMinGreaterThanMax_ShouldSwapValues()
        {
            var parameter = new Parameter(30.0, 10.0);

            Assert.AreEqual(10.0, parameter.GetMin);
            Assert.AreEqual(30.0, parameter.GetMax);
        }

        //TODO: description
        [Test]
        public void SetValue_WithinRange_ShouldUpdateValue()
        {
            var parameter = new Parameter(0.0, 100.0);
            bool eventRaised = false;
            parameter.ParameterChanged += (sender, e) => eventRaised = true;

            parameter.SetValue = 50.0;

            Assert.AreEqual(50.0, parameter.GetValue);
            Assert.IsTrue(eventRaised);
        }

        //TODO: description
        [Test]
        public void SetValue_BelowMin_ShouldNotUpdateValue()
        {
            var parameter = new Parameter(10.0, 100.0);
            parameter.SetValue = 50.0;
            bool eventRaised = false;
            parameter.ParameterChanged += (sender, e) => eventRaised = true;

            parameter.SetValue = 5.0;

            Assert.AreEqual(50.0, parameter.GetValue);
            Assert.IsFalse(eventRaised);
        }

        //TODO: description
        [Test]
        public void SetValue_AboveMax_ShouldNotUpdateValue()
        {
            var parameter = new Parameter(0.0, 100.0);
            parameter.SetValue = 50.0;
            bool eventRaised = false;
            parameter.ParameterChanged += (sender, e) => eventRaised = true;

            parameter.SetValue = 150.0;

            Assert.AreEqual(50.0, parameter.GetValue);
            Assert.IsFalse(eventRaised);
        }

        //TODO: description
        [Test]
        public void SetBoundaries_ShouldUpdateMinMax()
        {
            var parameter = new Parameter(0.0, 10.0);
            bool eventRaised = false;
            parameter.ParameterChanged += (sender, e) => eventRaised = true;

            parameter.SetBoundaries(20.0, 30.0);

            Assert.AreEqual(20.0, parameter.GetMin);
            Assert.AreEqual(30.0, parameter.GetMax);
            Assert.IsTrue(eventRaised);
        }

        //TODO: description
        [Test]
        public void SetBoundaries_WhenMinGreaterThanMax_ShouldSwapValues()
        {
            var parameter = new Parameter(0.0, 10.0);

            parameter.SetBoundaries(40.0, 20.0);

            Assert.AreEqual(20.0, parameter.GetMin);
            Assert.AreEqual(40.0, parameter.GetMax);
        }

        //TODO: description
        [Test]
        public void GetMin_ShouldReturnMinimumValue()
        {
            var parameter = new Parameter(5.0, 15.0);

            Assert.AreEqual(5.0, parameter.GetMin);
        }

        //TODO: description
        [Test]
        public void GetMax_ShouldReturnMaximumValue()
        {
            var parameter = new Parameter(5.0, 15.0);

            Assert.AreEqual(15.0, parameter.GetMax);
        }
    }
}