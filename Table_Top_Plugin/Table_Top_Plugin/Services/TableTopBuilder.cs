using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using TableTopPlugin.Models;

namespace TableTopPlugin.Services
{
    /// <summary>
    /// Построитель столешницы в КОМПАС-3D
    /// </summary>
    public class TableTopBuilder
    {
        //TODO: XML +
        /// <summary>
        /// Коннектор для подключения к КОМПАС-3D
        /// </summary>
        private KompasConnector _kompas = new KompasConnector();

        private ksDocument3D _document3D;
        private ksPart _part;
        private ksEntity _sketch;

        /// <summary>
        /// Построение столешницы
        /// </summary>
        /// <param name="tableTopParameters">Параметры столешницы</param>
        public void Build(TableTopParameters tableTopParameters)
        {
            //TODO: refactor +
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

            CreateDocumentAndPart();
            CreateSketch();
            DrawSketchGeometry(length, width, cornerRadius);
            ExtrudeSketch(height);

            if (chamferRadius > 0)
            {
                CreateFillet(chamferRadius);
            }

            RebuildModel();
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
        /// Рисует геометрию эскиза (прямоугольник или скругленный прямоугольник)
        /// </summary>
        /// <param name="length">Длина столешницы</param>
        /// <param name="width">Ширина столешницы</param>
        /// <param name="cornerRadius">Радиус скругления углов</param>
        private void DrawSketchGeometry(double length, double width,
            double cornerRadius)
        {
            ksSketchDefinition sketchDefinition =
                (ksSketchDefinition)_sketch.GetDefinition();
            ksDocument2D document2D =
                (ksDocument2D)sketchDefinition.BeginEdit();

            if (cornerRadius <= 0)
            {
                DrawRectangle(document2D, length, width);
            }
            else
            {
                DrawRoundedRectangle(document2D, length, width,
                    cornerRadius);
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

            // Рисуем прямые участки
            document2D.ksLineSeg(-lengthX, width / 2, lengthX, width / 2, 1);
            document2D.ksLineSeg(length / 2, lengthY, length / 2,
                -lengthY, 1);
            document2D.ksLineSeg(lengthX, -width / 2, -lengthX,
                -width / 2, 1);
            document2D.ksLineSeg(-length / 2, -lengthY, -length / 2,
                lengthY, 1);

            // Рисуем скругления в углах
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