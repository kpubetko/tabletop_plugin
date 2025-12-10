using TableTopPlugin.Models;

namespace Table_Top_PluginTests.ModelsTests
{
    /// <summary>
    /// Содержит модульные тесты для класса <see cref="Parameter"/>
    /// </summary>
    public class ParameterTests
    {
        [Test]
        //TODO: RSDN
        [Description("Проверяет, что конструктор правильно инициализирует параметр с заданными границами")]
        public void Constructor_ShouldInitializeWithCorrectBoundaries()
        {
            var parameter = new Parameter(10.0, 20.0);

            Assert.AreEqual(10.0, parameter.Min);
            Assert.AreEqual(20.0, parameter.Max);
            Assert.AreEqual(0.0, parameter.Value);
        }

        [Test]
        //TODO: RSDN
        [Description("Проверяет, что конструктор автоматически меняет местами минимальное и максимальное значения, когда минимальное значение больше максимального")]
        public void Constructor_WhenMinGreaterThanMax_ShouldSwapValues()
        {
            var parameter = new Parameter(30.0, 10.0);

            Assert.AreEqual(10.0, parameter.Min);
            Assert.AreEqual(30.0, parameter.Max);
        }

        [Test]
        //TODO: RSDN
        [Description("Проверяет, что установка значения в допустимом диапазоне корректно обновляет значение и вызывает событие изменения параметра")]
        public void SetValue_WithinRange_ShouldUpdateValue()
        {
            var parameter = new Parameter(0.0, 100.0);
            bool eventRaised = false;
            parameter.ParameterChanged += (sender, e) => eventRaised = true;

            parameter.Value = 50.0;

            Assert.AreEqual(50.0, parameter.Value);
            Assert.IsTrue(eventRaised);
        }

        [Test]
        [Description("Проверяет, что установка значения ниже минимального не изменяет текущее значение и не вызывает событие изменения параметра")]
        public void SetValue_BelowMin_ShouldNotUpdateValue()
        {
            var parameter = new Parameter(10.0, 100.0);
            parameter.Value = 50.0;
            bool eventRaised = false;
            parameter.ParameterChanged += (sender, e) => eventRaised = true;

            parameter.Value = 5.0;

            Assert.AreEqual(50.0, parameter.Value);
            Assert.IsFalse(eventRaised);
        }

        [Test]
        //TODO: RSDN
        [Description("Проверяет, что установка значения выше максимального не изменяет текущее значение и не вызывает событие изменения параметра")]
        public void SetValue_AboveMax_ShouldNotUpdateValue()
        {
            var parameter = new Parameter(0.0, 100.0);
            parameter.Value = 50.0;
            bool eventRaised = false;
            parameter.ParameterChanged += (sender, e) => eventRaised = true;

            parameter.Value = 150.0;

            Assert.AreEqual(50.0, parameter.Value);
            Assert.IsFalse(eventRaised);
        }

        [Test]
        //TODO: RSDN
        [Description("Проверяет, что метод SetBoundaries корректно обновляет границы значений и вызывает событие изменения параметра")]
        public void SetBoundaries_ShouldUpdateMinMax()
        {
            var parameter = new Parameter(0.0, 10.0);
            bool eventRaised = false;
            parameter.ParameterChanged += (sender, e) => eventRaised = true;

            parameter.SetBoundaries(20.0, 30.0);

            Assert.AreEqual(20.0, parameter.Min);
            Assert.AreEqual(30.0, parameter.Max);
            Assert.IsTrue(eventRaised);
        }

        [Test]
        //TODO: RSDN
        [Description("Проверяет, что метод SetBoundaries автоматически меняет местами значения, когда минимальное значение больше максимального")]
        public void SetBoundaries_WhenMinGreaterThanMax_ShouldSwapValues()
        {
            var parameter = new Parameter(0.0, 10.0);

            parameter.SetBoundaries(40.0, 20.0);

            Assert.AreEqual(20.0, parameter.Min);
            Assert.AreEqual(40.0, parameter.Max);
        }

        [Test]
        [Description("Проверяет, что свойство Min возвращает корректное минимальное значение")]
        public void GetMin_ShouldReturnMinimumValue()
        {
            var parameter = new Parameter(5.0, 15.0);

            Assert.AreEqual(5.0, parameter.Min);
        }

        [Test]
        [Description("Проверяет, что свойство Max возвращает корректное максимальное значение")]
        public void GetMax_ShouldReturnMaximumValue()
        {
            var parameter = new Parameter(5.0, 15.0);

            Assert.AreEqual(15.0, parameter.Max);
        }
    }
}