using asd;

namespace VectorStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Initialize("VectorStudy", 640, 640, new asd.EngineOption() { IsFullScreen = false });

            var scene = new Scene();
            var layer = new Layer2D();
            var font = Engine.Graphics.CreateDynamicFont("", 18, new Color(255, 255, 255), 0, new Color(0, 0, 0));
            SetUpBackground(layer);
            scene.AddLayer(layer);
            Engine.ChangeScene(scene);

            CalcNumbersInDistance(layer, font);

            while (Engine.DoEvents())
            {
                Engine.Update();

                if (Engine.Keyboard.GetKeyState(Keys.P) == ButtonState.Push)
                {
                    Engine.TakeScreenshot("screenshot.png");
                }
            }

            Engine.Terminate();
        }
        
        private static void SetUpBackground(Layer2D layer)
        {
            var back = new GeometryObject2D()
            {
                Position = new Vector2DF(0, 0),
                Shape = new RectangleShape()
                {
                    DrawingArea = new RectF(0, 0, 640, 640),
                },
                Color = Helper.BackGroundColor,
                DrawingPriority = -1
            };
            layer.AddObject(back);
        }

        private static void CalcNumbersInDistance(Layer2D layer, Font font)
        {
            var drawer = new NumbersInDistanceDrawer(layer, font);
            drawer.Draw(6);
        }
    }
}
