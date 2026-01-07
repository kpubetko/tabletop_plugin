using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using TableTopPluginModels.Models;

namespace TableTopPlugin.Services
{
    /// <summary>
    /// Построитель столешницы в КОМПАС-3D
    /// </summary>
    public class TableTopBuilder
    {
        /// <summary>
        /// Коннектор для подключения к КОМПАС-3D
        /// </summary>
        private KompasConnector _kompas;

        /// <summary>
        /// 3D-документ КОМПАС
        /// </summary>
        private ksDocument3D _document3D;

        /// <summary>
        /// Деталь в 3D-документе
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Эскиз для построения
        /// </summary>
        private ksEntity _sketch;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="TableTopBuilder"/>
        /// </summary>
        public TableTopBuilder()
        {
            _kompas = new KompasConnector();
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="TableTopBuilder"/> с указанным коннектором
        /// </summary>
        /// <param name="connector">Коннектор для подключения к КОМПАС-3D</param>
        public TableTopBuilder(KompasConnector connector)
        {
            _kompas = connector;
        }

        /// <summary>
        /// Построение столешницы
        /// </summary>
        /// <param name="tableTopParameters">Параметры столешницы</param>
        public void Build(TableTopParameters tableTopParameters)
        {
            if (!_kompas.IsConnected)
            {
                _kompas.Connect();
                if (!_kompas.IsConnected)
                {
                    return;
                }
            }

            double length = tableTopParameters.Length.Value;
            double width = tableTopParameters.Width.Value;
            double height = tableTopParameters.Height.Value;
            double cornerRadius = tableTopParameters.CornerRadius.Value;
            double chamferRadius = tableTopParameters.ChamferRadius.Value;
            double waveAmplitude = tableTopParameters.WaveAmplitude.Value;

            CreateDocumentAndPart();
            CreateSketch();
            DrawSketchGeometry(length, width, cornerRadius, waveAmplitude);
            ExtrudeSketch(height);

            if (chamferRadius > 0)
            {
                CreateFillet(chamferRadius);
            }

            RebuildModel();
        }

        /// <summary>
        /// Закрывает текущий открытый документ КОМПАС без сохранения
        /// </summary>
        public void CloseDocument()
        {
            if (_document3D != null)
            {
                _document3D.close();
                _document3D = null;
                _part = null;
                _sketch = null;
            }
        }

        /// <summary>
        /// Создает новый 3D-документ и получает деталь
        /// </summary>
        private void CreateDocumentAndPart()
        {
            _document3D = (ksDocument3D)_kompas.Kompas.Document3D();
            _document3D.Create(false, true);
            _document3D = (ksDocument3D)_kompas.Kompas.ActiveDocument3D();
            _part = (ksPart)_document3D.GetPart((int)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Создает эскиз на плоскости XOY
        /// </summary>
        private void CreateSketch()
        {
            _sketch = (ksEntity)_part.NewEntity((int)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition =
                (ksSketchDefinition)_sketch.GetDefinition();
            sketchDefinition.SetPlane(_part.GetDefaultEntity(
                (int)Obj3dType.o3d_planeXOY));
            _sketch.Create();
        }

        /// <summary>
        /// Рисует геометрию эскиза (прямоугольник, скругленный прямоугольник или прямоугольник с волнами)
        /// </summary>
        /// <param name="length">Длина столешницы</param>
        /// <param name="width">Ширина столешницы</param>
        /// <param name="cornerRadius">Радиус скругления углов</param>
        /// <param name="waveAmplitude">Амплитуда волны по периметру</param>
        /// <remarks>
        /// При наличии амплитуды волны (больше 0) строится волнообразный периметр с учетом скругления углов.
        /// При отсутствии волны строится обычный прямоугольник или скругленный прямоугольник
        /// </remarks>
        private void DrawSketchGeometry(double length, double width,
            double cornerRadius, double waveAmplitude)
        {
            ksSketchDefinition sketchDefinition =
                (ksSketchDefinition)_sketch.GetDefinition();
            ksDocument2D document2D =
                (ksDocument2D)sketchDefinition.BeginEdit();

            if (waveAmplitude > 0)
            {
                DrawWavyRectangle(document2D, length, width,
                    waveAmplitude, cornerRadius);
            }
            else if (cornerRadius > 0)
            {
                DrawRoundedRectangle(document2D, length, width,
                    cornerRadius);
            }
            else
            {
                DrawRectangle(document2D, length, width);
            }

            sketchDefinition.EndEdit();
        }

        /// <summary>
        /// Рисует прямоугольник в эскизе
        /// </summary>
        /// <param name="document2D">2D-документ эскиза</param>
        /// <param name="length">Длина прямоугольника</param>
        /// <param name="width">Ширина прямоугольника</param>
        private void DrawRectangle(ksDocument2D document2D, double length,
            double width)
        {
            ksRectangleParam rectangleParam = (ksRectangleParam)_kompas.
                Kompas.GetParamStruct((short)StructType2DEnum.
                ko_RectangleParam);
            rectangleParam.Init();
            rectangleParam.x = 0;
            rectangleParam.y = 0;
            rectangleParam.height = width;
            rectangleParam.width = length;
            rectangleParam.style = 1;
            document2D.ksRectangle(rectangleParam, 1);
        }

        /// <summary>
        /// Рисует скругленный прямоугольник в эскизе
        /// </summary>
        /// <param name="document2D">2D-документ эскиза</param>
        /// <param name="length">Длина прямоугольника</param>
        /// <param name="width">Ширина прямоугольника</param>
        /// <param name="cornerRadius">Радиус скругления углов</param>
        private void DrawRoundedRectangle(ksDocument2D document2D,
            double length, double width, double cornerRadius)
        {
            double lengthX = length / 2 - cornerRadius;
            double lengthY = width / 2 - cornerRadius;

            document2D.ksLineSeg(-lengthX, width / 2, lengthX, width / 2, 1);
            document2D.ksLineSeg(length / 2, lengthY, length / 2,
                -lengthY, 1);
            document2D.ksLineSeg(lengthX, -width / 2, -lengthX,
                -width / 2, 1);
            document2D.ksLineSeg(-length / 2, -lengthY, -length / 2,
                lengthY, 1);

            document2D.ksArcByAngle(lengthX, lengthY, cornerRadius, 0,
                90, 1, 1);
            document2D.ksArcByAngle(lengthX, -lengthY, cornerRadius, -90,
                0, 1, 1);
            document2D.ksArcByAngle(-lengthX, -lengthY, cornerRadius, -180,
                -90, 1, 1);
            document2D.ksArcByAngle(-lengthX, lengthY, cornerRadius, 90,
                180, 1, 1);
        }

        /// <summary>
        /// Рисует прямоугольник с волнообразным периметром в эскизе
        /// </summary>
        /// <param name="document2D">2D-документ эскиза</param>
        /// <param name="length">Длина прямоугольника</param>
        /// <param name="width">Ширина прямоугольника</param>
        /// <param name="waveAmplitude">Амплитуда волны</param>
        /// <param name="cornerRadius">Радиус скругления углов</param>
        /// <remarks>
        /// Создает волнообразный периметр с учетом скругления углов если cornerRadius больше 0
        /// </remarks>
        private void DrawWavyRectangle(ksDocument2D document2D,
            double length, double width, double waveAmplitude,
            double cornerRadius)
        {
            int segmentsPerSide = 20;

            if (cornerRadius > 0)
            {
                double lengthX = length / 2 - cornerRadius;
                double lengthY = width / 2 - cornerRadius;

                DrawWavySide(document2D, -lengthX, width / 2,
                    lengthX, width / 2, waveAmplitude,
                    segmentsPerSide, false);

                document2D.ksArcByAngle(lengthX, lengthY, cornerRadius, 0,
                    90, 1, 1);

                DrawWavySide(document2D, length / 2, lengthY,
                    length / 2, -lengthY, waveAmplitude,
                    segmentsPerSide, true);

                document2D.ksArcByAngle(lengthX, -lengthY, cornerRadius, -90,
                    0, 1, 1);

                DrawWavySide(document2D, lengthX, -width / 2,
                    -lengthX, -width / 2, waveAmplitude,
                    segmentsPerSide, false);

                document2D.ksArcByAngle(-lengthX, -lengthY, cornerRadius,
                    -180, -90, 1, 1);

                DrawWavySide(document2D, -length / 2, -lengthY,
                    -length / 2, lengthY, waveAmplitude,
                    segmentsPerSide, true);

                document2D.ksArcByAngle(-lengthX, lengthY, cornerRadius, 90,
                    180, 1, 1);
            }
            else
            {
                DrawWavySide(document2D, -length / 2, width / 2,
                    length / 2, width / 2, waveAmplitude,
                    segmentsPerSide, false);

                DrawWavySide(document2D, length / 2, width / 2,
                    length / 2, -width / 2, waveAmplitude,
                    segmentsPerSide, true);

                DrawWavySide(document2D, length / 2, -width / 2,
                    -length / 2, -width / 2, waveAmplitude,
                    segmentsPerSide, false);

                DrawWavySide(document2D, -length / 2, -width / 2,
                    -length / 2, width / 2, waveAmplitude,
                    segmentsPerSide, true);
            }
        }

        /// <summary>
        /// Рисует одну сторону с волнообразным профилем
        /// </summary>
        /// <param name="document2D">2D-документ эскиза</param>
        /// <param name="x1">Координата X начальной точки</param>
        /// <param name="y1">Координата Y начальной точки</param>
        /// <param name="x2">Координата X конечной точки</param>
        /// <param name="y2">Координата Y конечной точки</param>
        /// <param name="amplitude">Амплитуда волны</param>
        /// <param name="segments">Количество сегментов</param>
        /// <param name="isVertical">Флаг вертикальной стороны</param>
        private void DrawWavySide(ksDocument2D document2D,
            double x1, double y1, double x2, double y2,
            double amplitude, int segments, bool isVertical)
        {
            double length = Math.Sqrt((x2 - x1) * (x2 - x1)
                + (y2 - y1) * (y2 - y1));
            double dx = (x2 - x1) / segments;
            double dy = (y2 - y1) / segments;

            double normalX, normalY;
            if (isVertical)
            {
                normalX = dy / length * length;
                normalY = -dx / length * length;
            }
            else
            {
                normalX = -dy / length * length;
                normalY = dx / length * length;
            }

            double prevX = x1;
            double prevY = y1;

            for (int i = 1; i <= segments; i++)
            {
                double t = (double)i / segments;
                double baseX = x1 + dx * i;
                double baseY = y1 + dy * i;

                double wave = amplitude * Math.Sin(t * Math.PI * 4);
                double currentX = baseX + normalX * wave / length;
                double currentY = baseY + normalY * wave / length;

                document2D.ksLineSeg(prevX, prevY, currentX, currentY, 1);

                prevX = currentX;
                prevY = currentY;
            }
        }

        /// <summary>
        /// Выполняет операцию выдавливания эскиза
        /// </summary>
        /// <param name="height">Высота выдавливания</param>
        private void ExtrudeSketch(double height)
        {
            ksEntity extrusion =
                (ksEntity)_part.NewEntity((int)Obj3dType.o3d_baseExtrusion);
            ksBaseExtrusionDefinition extrusionDefinition =
                (ksBaseExtrusionDefinition)extrusion.GetDefinition();
            extrusionDefinition.SetSketch(_sketch);
            extrusionDefinition.directionType =
                (short)Direction_Type.dtNormal;
            extrusionDefinition.SetSideParam(true, 0, height);
            extrusion.Create();
        }

        /// <summary>
        /// Создает фаску на всех ребрах детали
        /// </summary>
        /// <param name="chamferRadius">Радиус фаски</param>
        private void CreateFillet(double chamferRadius)
        {
            ksEntity fillet = (ksEntity)_part.NewEntity(
                (int)Obj3dType.o3d_fillet);
            ksFilletDefinition filletDefinition =
                (ksFilletDefinition)fillet.GetDefinition();
            filletDefinition.radius = chamferRadius;

            ksEntityCollection edges = (ksEntityCollection)_part.
                EntityCollection((short)Obj3dType.o3d_edge);
            for (int i = 0; i < edges.GetCount(); i++)
            {
                ksEntity edge = (ksEntity)edges.GetByIndex(i);
                filletDefinition.array().Add(edge);
            }

            fillet.Create();
        }

        /// <summary>
        /// Перестраивает модель после всех изменений
        /// </summary>
        private void RebuildModel()
        {
            _part.RebuildModel();
        }
    }
}