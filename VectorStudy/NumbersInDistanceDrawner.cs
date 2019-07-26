using System;
using asd;

namespace VectorStudy
{
    public class NumbersInDistanceDrawer
    {
        private static readonly float DistanceUnit = 100;
        private readonly Layer2D layer;
        private readonly Font font;

        public NumbersInDistanceDrawer(Layer2D layer, Font font)
        {
            this.layer = layer;
            this.font = font;
        }

        public void Draw(int baseNumber)
        {
            var start = NumberVector.CreateForNumber(baseNumber);
            PlaceVectors(start);
            DrawCircle(start);
        }

        private void PlaceVectors(NumberVector start)
        {
            //float angleSpan = 137.507f;
            float angleSpan = 360 / 72.0f;
            for (int i = 2; i <= 72; i++)
            {
                var vector = NumberVector.CreateForNumber(i);
                var distance = (vector - start).GetLength();

                var position = new Vector2DF(1, 1);
                position.Degree = angleSpan * i;
                position.Length = distance * DistanceUnit;
                position += new Vector2DF(320, 320);

                var obj = new TextObject2D()
                {
                    Text = i.ToString(),
                    Font = font,
                    Position = position,
                    Color = vector.IsPrime() ? Helper.AccentColor1 : Helper.PlaneColor,
                    DrawingPriority = 2,
                };
                var size = font.CalcTextureSize(i.ToString(), WritingDirection.Horizontal);
                obj.CenterPosition = size.To2DF() / 2;

                layer.AddObject(obj);
            }
        }

        private void DrawCircle(NumberVector start)
        {
            // Draw circle.
            var primeRadius = Math.Sqrt(Math.Pow(start.GetLength(), 2) + 1);
            for (int i = 1; i < 12; i++)
            {
                var radius = (float)Math.Sqrt(i);
                var isPrime = Math.Abs(primeRadius - radius) < 0.1f;
                var diameter = radius * DistanceUnit * 2;
                var circle = new GeometryObject2D()
                {
                    Position = new Vector2DF(320, 320),
                    Shape = new CircleShape()
                    {
                        Position = new Vector2DF(0, 0),
                        InnerDiameter = diameter - 1.5f,
                        OuterDiameter = diameter
                    },
                    Color = isPrime ? Helper.AccentColor2 : Helper.PaleColor
                };
                layer.AddObject(circle);
            }
        }
    }
}