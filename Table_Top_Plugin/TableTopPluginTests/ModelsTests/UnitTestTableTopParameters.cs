using TableTopPlugin.Models;

namespace Table_Top_Plugin.Tests.Models
{
    //TODO: XML +
    /// <summary>
    /// Содержит модульные тесты для класса <see cref="TableTopParameters"/>
    /// </summary>
    public class TableTopParametersTests
    {
        //TODO: XML +
        /// <summary>
        /// Экземпляр тестируемого класса
        /// </summary>
        private TableTopParameters _tableTopParams;

        //TODO: remove +
        

        //TODO: description
        [Test]
        [Description("Проверяет, что конструктор инициализирует все параметры столешницы с корректными диапазонами значений")]
        public void Constructor_ShouldInitializeAllParametersWithCorrectRanges()
        {
            _tableTopParams = new TableTopParameters();
            Assert.AreEqual(1000, _tableTopParams.Length.Min);
            Assert.AreEqual(2500, _tableTopParams.Length.Max);

            Assert.AreEqual(1000, _tableTopParams.Width.Min);
            Assert.AreEqual(2500, _tableTopParams.Width.Max);

            Assert.AreEqual(15, _tableTopParams.Height.Min);
            Assert.AreEqual(50, _tableTopParams.Height.Max);

            Assert.AreEqual(0, _tableTopParams.CornerRadius.Min);
            Assert.AreEqual(0, _tableTopParams.CornerRadius.Max);

            Assert.AreEqual(0, _tableTopParams.ChamferRadius.Min);
            Assert.AreEqual(0, _tableTopParams.ChamferRadius.Max);
        }

        //TODO: description +
        [Test]
        [Description("Проверяет, что при изменении длины (когда длина меньше ширины) корректно обновляется максимальное значение радиуса скругления углов")]
        public void LengthOrWidthChanged_WhenLengthLessThanWidth_ShouldUpdateCornerRadiusMax()
        {
            _tableTopParams = new TableTopParameters();
            _tableTopParams.Width.Value = 2000;

            _tableTopParams.Length.Value = 1800;

            Assert.AreEqual(900, _tableTopParams.CornerRadius.Max);
        }

        //TODO: description +
        [Test]
        [Description("Проверяет, что при изменении ширины (когда ширина меньше длины) корректно обновляется максимальное значение радиуса скругления углов")]
        public void LengthOrWidthChanged_WhenWidthLessThanLength_ShouldUpdateCornerRadiusMax()
        {
            _tableTopParams = new TableTopParameters();
            _tableTopParams.Length.Value = 2000;

            _tableTopParams.Width.Value = 1600;

            Assert.AreEqual(800, _tableTopParams.CornerRadius.Max);
        }

        //TODO: description +
        [Test]
        [Description("Проверяет, что при изменении высоты корректно обновляется максимальное значение радиуса фаски")]
        public void HeightChanged_ShouldUpdateChamferRadiusMax()
        {
            _tableTopParams = new TableTopParameters();

            _tableTopParams.Height.Value = 40;

            Assert.AreEqual(20, _tableTopParams.ChamferRadius.Max);
        }

        //TODO: description +
        [Test]
        [Description("Проверяет, что свойство Length возвращает корректный объект параметра длины")]
        public void GetLength_ShouldReturnLengthParameter()
        {
            _tableTopParams = new TableTopParameters();
            Assert.IsNotNull(_tableTopParams.Length);
            Assert.AreEqual(1000, _tableTopParams.Length.Min);
        }

        //TODO: description +
        [Test]
        [Description("Проверяет, что свойство Width возвращает корректный объект параметра ширины")]
        public void GetWidth_ShouldReturnWidthParameter()
        {
            _tableTopParams = new TableTopParameters();
            Assert.IsNotNull(_tableTopParams.Width);
            Assert.AreEqual(1000, _tableTopParams.Width.Min);
        }

        //TODO: description +
        [Test]
        [Description("Проверяет, что свойство Height возвращает корректный объект параметра высоты")]
        public void GetHeight_ShouldReturnHeightParameter()
        {
            _tableTopParams = new TableTopParameters();
            Assert.IsNotNull(_tableTopParams.Height);
            Assert.AreEqual(15, _tableTopParams.Height.Min);
        }

        //TODO: description +
        [Test]
        [Description("Проверяет, что свойство CornerRadius возвращает корректный объект параметра радиуса скругления углов")]
        public void GetCornerRadius_ShouldReturnCornerRadiusParameter()
        {
            _tableTopParams = new TableTopParameters();
            Assert.IsNotNull(_tableTopParams.CornerRadius);
            Assert.AreEqual(0, _tableTopParams.CornerRadius.Min);
        }

        //TODO: description +
        [Test]
        [Description("Проверяет, что свойство ChamferRadius возвращает корректный объект параметра радиуса фаски")]
        public void GetChamferRadius_ShouldReturnChamferRadiusParameter()
        {
            _tableTopParams = new TableTopParameters();
            Assert.IsNotNull(_tableTopParams.ChamferRadius);
            Assert.AreEqual(0, _tableTopParams.ChamferRadius.Min);
        }

        //TODO: description +
        [Test]
        [Description("Проверяет, что множественные изменения параметров корректно обновляют зависимые параметры")]
        public void MultipleParameterChanges_ShouldProperlyUpdateDependentParameters()
        {
            _tableTopParams = new TableTopParameters();
            _tableTopParams.Length.Value = 1200;
            _tableTopParams.Width.Value = 1800;
            _tableTopParams.Height.Value = 20;

            _tableTopParams.CornerRadius.Value = 300;
            _tableTopParams.ChamferRadius.Value = 5;

            Assert.AreEqual(300, _tableTopParams.CornerRadius.Value);
            Assert.AreEqual(5, _tableTopParams.ChamferRadius.Value);
        }

        //TODO: description +
        [Test]
        [Description("Проверяет, что после конструктора все обработчики событий корректно подключены")]
        public void EventHandlers_ShouldBeConnectedAfterConstructor()
        {
            _tableTopParams = new TableTopParameters();
            bool lengthEventRaised = false;
            bool widthEventRaised = false;
            bool heightEventRaised = false;

            //TODO: RSDN
            _tableTopParams.Length.ParameterChanged += (s, e) =>
            lengthEventRaised = true;
            _tableTopParams.Width.ParameterChanged += (s, e) =>
            widthEventRaised = true;
            _tableTopParams.Height.ParameterChanged += (s, e) =>
            heightEventRaised = true;

            _tableTopParams.Length.Value = 1500;
            _tableTopParams.Width.Value = 1500;
            _tableTopParams.Height.Value = 25;

            Assert.IsTrue(lengthEventRaised);
            Assert.IsTrue(widthEventRaised);
            Assert.IsTrue(heightEventRaised);
        }
    }
}