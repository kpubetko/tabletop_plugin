using TableTopPlugin.Models;

namespace Table_Top_Plugin.Tests.Models
{
    /// <summary>
    /// Содержит модульные тесты для класса <see cref="TableTopParameters"/>
    /// </summary>
    public class TableTopParametersTests
    {
        //TODO: refactor +

        [Test]
        //TODO: RSDN +
        [Description("Проверяет, что конструктор инициализирует" +
            " все параметры столешницы с корректными диапазонами значений")]
        public void Constructor_ShouldInitializeAllParametersWithCorrectRanges()
        {
            var tableTopParams = new TableTopParameters();
            Assert.AreEqual(1000, tableTopParams.Length.Min);
            Assert.AreEqual(2500, tableTopParams.Length.Max);

            Assert.AreEqual(1000, tableTopParams.Width.Min);
            Assert.AreEqual(2500, tableTopParams.Width.Max);

            Assert.AreEqual(15, tableTopParams.Height.Min);
            Assert.AreEqual(50, tableTopParams.Height.Max);

            Assert.AreEqual(0, tableTopParams.CornerRadius.Min);
            Assert.AreEqual(0, tableTopParams.CornerRadius.Max);

            Assert.AreEqual(0, tableTopParams.ChamferRadius.Min);
            Assert.AreEqual(0, tableTopParams.ChamferRadius.Max);

            Assert.AreEqual(0, tableTopParams.WaveAmplitude.Min);
            Assert.AreEqual(0, tableTopParams.WaveAmplitude.Max);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что при изменении длины " +
            "(когда длина меньше ширины) корректно обновляется" +
            " максимальное значение радиуса скругления углов")]
        public void LengthOrWidthChanged_WhenLengthLessThanWidth_ShouldUpdateCornerRadiusMax()
        {
            var tableTopParams = new TableTopParameters();
            tableTopParams.Width.Value = 2000;

            tableTopParams.Length.Value = 1800;

            Assert.AreEqual(900, tableTopParams.CornerRadius.Max);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что при изменении ширины " +
            "(когда ширина меньше длины) корректно обновляется" +
            " максимальное значение радиуса скругления углов")]
        public void LengthOrWidthChanged_WhenWidthLessThanLength_ShouldUpdateCornerRadiusMax()
        {
            var tableTopParams = new TableTopParameters();
            tableTopParams.Length.Value = 2000;

            tableTopParams.Width.Value = 1600;

            Assert.AreEqual(800, tableTopParams.CornerRadius.Max);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что при изменении высоты корректно" +
            " обновляется максимальное значение радиуса фаски")]
        public void HeightChanged_ShouldUpdateChamferRadiusMax()
        {
            var tableTopParams = new TableTopParameters();
            tableTopParams.Height.Value = 40;

            Assert.AreEqual(20, tableTopParams.ChamferRadius.Max);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что при изменении размеров корректно" +
            " обновляется максимальное значение амплитуды волны")]
        public void LengthOrWidthChanged_ShouldUpdateWaveAmplitudeMax()
        {
            var tableTopParams = new TableTopParameters();
            tableTopParams.Length.Value = 1500;

            tableTopParams.Width.Value = 1200;

            Assert.AreEqual(400, tableTopParams.WaveAmplitude.Max);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что при включении волны максимум радиуса" +
            " скругления уменьшается до 1/4 от размера")]
        public void WaveAmplitudeChanged_WhenWaveEnabled_ShouldReduceCornerRadiusMax()
        {
            var tableTopParams = new TableTopParameters();
            tableTopParams.Length.Value = 1600;
            tableTopParams.Width.Value = 1600;

            tableTopParams.WaveAmplitude.Value = 100;

            Assert.AreEqual(400, tableTopParams.CornerRadius.Max);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что при отключении волны максимум радиуса" +
            " скругления увеличивается до 1/2 от размера")]
        public void WaveAmplitudeChanged_WhenWaveDisabled_ShouldIncreaseCornerRadiusMax()
        {
            var tableTopParams = new TableTopParameters();
            tableTopParams.Length.Value = 1600;
            tableTopParams.Width.Value = 1600;
            tableTopParams.WaveAmplitude.Value = 100;

            tableTopParams.WaveAmplitude.Value = 0;

            Assert.AreEqual(800, tableTopParams.CornerRadius.Max);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что при изменении размеров с включенной " +
            "волной радиус скругления ограничивается 1/4")]
        public void LengthOrWidthChanged_WithWaveEnabled_ShouldLimitCornerRadiusToQuarter()
        {
            var tableTopParams = new TableTopParameters();
            tableTopParams.Length.Value = 2000;
            tableTopParams.Width.Value = 2000;
            tableTopParams.WaveAmplitude.Value = 200;

            tableTopParams.Width.Value = 1200;

            Assert.AreEqual(300, tableTopParams.CornerRadius.Max);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что свойство Length возвращает корректный " +
            "объект параметра длины")]
        public void GetLength_ShouldReturnLengthParameter()
        {
            var tableTopParams = new TableTopParameters();
            Assert.IsNotNull(tableTopParams.Length);
            Assert.AreEqual(1000, tableTopParams.Length.Min);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что свойство Width возвращает корректный " +
            "объект параметра ширины")]
        public void GetWidth_ShouldReturnWidthParameter()
        {
            var tableTopParams = new TableTopParameters();
            Assert.IsNotNull(tableTopParams.Width);
            Assert.AreEqual(1000, tableTopParams.Width.Min);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что свойство Height возвращает корректный " +
            "объект параметра высоты")]
        public void GetHeight_ShouldReturnHeightParameter()
        {
            var tableTopParams = new TableTopParameters();
            Assert.IsNotNull(tableTopParams.Height);
            Assert.AreEqual(15, tableTopParams.Height.Min);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что свойство CornerRadius возвращает " +
            "корректный объект параметра радиуса скругления углов")]
        public void GetCornerRadius_ShouldReturnCornerRadiusParameter()
        {
            var tableTopParams = new TableTopParameters();
            Assert.IsNotNull(tableTopParams.CornerRadius);
            Assert.AreEqual(0, tableTopParams.CornerRadius.Min);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что свойство ChamferRadius возвращает " +
            "корректный объект параметра радиуса фаски")]
        public void GetChamferRadius_ShouldReturnChamferRadiusParameter()
        {
            var tableTopParams = new TableTopParameters();
            Assert.IsNotNull(tableTopParams.ChamferRadius);
            Assert.AreEqual(0, tableTopParams.ChamferRadius.Min);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что свойство WaveAmplitude возвращает" +
            " корректный объект параметра амплитуды волны")]
        public void GetWaveAmplitude_ShouldReturnWaveAmplitudeParameter()
        {
            var tableTopParams = new TableTopParameters();
            Assert.IsNotNull(tableTopParams.WaveAmplitude);
            Assert.AreEqual(0, tableTopParams.WaveAmplitude.Min);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что множественные изменения параметров" +
            " корректно обновляют зависимые параметры")]
        public void MultipleParameterChanges_ShouldProperlyUpdateDependentParameters()
        {
            var tableTopParams = new TableTopParameters();
            tableTopParams.Length.Value = 1200;
            tableTopParams.Width.Value = 1800;
            tableTopParams.Height.Value = 20;

            tableTopParams.CornerRadius.Value = 300;
            tableTopParams.ChamferRadius.Value = 5;

            Assert.AreEqual(300, tableTopParams.CornerRadius.Value);
            Assert.AreEqual(5, tableTopParams.ChamferRadius.Value);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что после конструктора все " +
            "обработчики событий корректно подключены")]
        public void EventHandlers_ShouldBeConnectedAfterConstructor()
        {
            var tableTopParams = new TableTopParameters();
            bool lengthEventRaised = false;
            bool widthEventRaised = false;
            bool heightEventRaised = false;

            tableTopParams.Length.ParameterChanged += (s, e) =>
            lengthEventRaised = true;
            tableTopParams.Width.ParameterChanged += (s, e) =>
            widthEventRaised = true;
            tableTopParams.Height.ParameterChanged += (s, e) =>
            heightEventRaised = true;

            tableTopParams.Length.Value = 1500;
            tableTopParams.Width.Value = 1500;
            tableTopParams.Height.Value = 25;

            Assert.IsTrue(lengthEventRaised);
            Assert.IsTrue(widthEventRaised);
            Assert.IsTrue(heightEventRaised);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что амплитуда волны принимает" +
            " допустимые значения в заданном диапазоне")]
        public void WaveAmplitude_ShouldAcceptValidValue()
        {
            var tableTopParams = new TableTopParameters();
            tableTopParams.Length.Value = 1500;
            tableTopParams.Width.Value = 1500;

            tableTopParams.WaveAmplitude.Value = 200;

            Assert.AreEqual(200, tableTopParams.WaveAmplitude.Value);
        }

        [Test]
        //TODO: RSDN+
        [Description("Проверяет, что амплитуда волны отклоняет " +
            "значения выше максимума")]
        public void WaveAmplitude_ShouldRejectValueAboveMax()
        {
            var tableTopParams = new TableTopParameters();
            tableTopParams.Length.Value = 1200;
            tableTopParams.Width.Value = 1200;
            tableTopParams.WaveAmplitude.Value = 200;

            tableTopParams.WaveAmplitude.Value = 600;

            Assert.AreEqual(200, tableTopParams.WaveAmplitude.Value);
        }
    }
}