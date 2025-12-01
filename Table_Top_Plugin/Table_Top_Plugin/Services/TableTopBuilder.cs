using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using Table_Top_Plugin.Models;

namespace Table_Top_Plugin.Services
{
    /// <summary>
    /// Построитель столешницы в КОМПАС-3D
    /// </summary>
    public class TableTopBuilder
    {
        private KompasConnector _kompas = new KompasConnector();
        /// <summary>
        /// Построение столешницы
        /// </summary>
        /// <param name="length">Длина</param>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        /// <param name="cornerRadius">Радиус скругления углов</param>
        /// <param name="chamferRadius">Радиус фаски</param>
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
            double length = tableTopParameters.GetLength.GetValue;
            double width = tableTopParameters.GetWidth.GetValue;
            double height = tableTopParameters.GetHeight.GetValue;
            double cornerRadius = tableTopParameters.GetCornerRadius.GetValue;
            double chamferRadius = tableTopParameters.GetChamferRadius.GetValue;

            ksDocument3D document3D = (ksDocument3D)_kompas.Kompas.Document3D();
            document3D.Create(false, true);
            document3D = (ksDocument3D)_kompas.Kompas.ActiveDocument3D();

            ksPart part = (ksPart)document3D.GetPart((int)Part_Type.pTop_Part);

            ksEntity sketch = (ksEntity)part.NewEntity((int)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = (ksSketchDefinition)sketch.GetDefinition();
            sketchDefinition.SetPlane(part.GetDefaultEntity((int)Obj3dType.o3d_planeXOY));
            sketch.Create();

            ksDocument2D document2D = (ksDocument2D)sketchDefinition.BeginEdit();

            if (cornerRadius <= 0)
            {
                ksRectangleParam rectangleParam = (ksRectangleParam)_kompas.Kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
                rectangleParam.Init();
                rectangleParam.x = 0;
                rectangleParam.y = 0;
                rectangleParam.height = width;
                rectangleParam.width = length;
                rectangleParam.style = 1;
                document2D.ksRectangle(rectangleParam, 1);
            }
            else
            {
                double lengthX = length / 2 - cornerRadius;
                double lengthY = width / 2 - cornerRadius;

                document2D.ksLineSeg(-lengthX, width / 2, lengthX, width / 2, 1);
                document2D.ksLineSeg(length / 2, lengthY, length / 2, -lengthY, 1);
                document2D.ksLineSeg(lengthX, -width / 2, -lengthX, -width / 2, 1);
                document2D.ksLineSeg(-length / 2, -lengthY, -length / 2, lengthY, 1);

                document2D.ksArcByAngle(lengthX, lengthY, cornerRadius, 0, 90, 1, 1);
                document2D.ksArcByAngle(lengthX, -lengthY, cornerRadius, -90, 0, 1, 1);
                document2D.ksArcByAngle(-lengthX, -lengthY, cornerRadius, -180, -90, 1, 1);
                document2D.ksArcByAngle(-lengthX, lengthY, cornerRadius, 90, 180, 1, 1);
            }
            sketchDefinition.EndEdit();
            ksEntity extrusion = (ksEntity)part.NewEntity((int)Obj3dType.o3d_baseExtrusion);
            ksBaseExtrusionDefinition extrusionDefinition = (ksBaseExtrusionDefinition)extrusion.GetDefinition();
            extrusionDefinition.SetSketch(sketch);
            extrusionDefinition.directionType = (short)Direction_Type.dtNormal;
            extrusionDefinition.SetSideParam(true, 0, height);
            extrusion.Create();
            if (chamferRadius > 0)
            {
                ksEntity fillet = (ksEntity)part.NewEntity((int)Obj3dType.o3d_fillet);
                ksFilletDefinition filletDefinition = (ksFilletDefinition)fillet.GetDefinition();
                filletDefinition.radius = chamferRadius;
                ksEntityCollection edges = (ksEntityCollection)part.EntityCollection((short)Obj3dType.o3d_edge);
                for (int i = 0; i < edges.GetCount(); i++)
                {
                    ksEntity edge = (ksEntity)edges.GetByIndex(i);
                    filletDefinition.array().Add(edge);
                }

                fillet.Create();
            }
            part.RebuildModel();
        }
    }
}