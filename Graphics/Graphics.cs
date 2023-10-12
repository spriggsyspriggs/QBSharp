using System;
using Silk.NET.Input;
using System.Reflection;
using lizzie;
using Silk.NET.Windowing;

namespace QBSharp
{
    public class Graphics
    {
        [Bind(Name = "NewImage")]
        object NewImage(Binder<Graphics> binder, Arguments arguments)
        {
            Silk.NET.Windowing.WindowOptions options = Silk.NET.Windowing.WindowOptions.Default;
            if(arguments.Count > 2)
            {
                throw new Exception("Too many arguments for NewImage");
            }
            options.Size = new Silk.NET.Maths.Vector2D<int>(Convert.ToInt32(arguments.Get(0)), Convert.ToInt32(arguments.Get(1)));
            options.Title = "untitled";
            window = Silk.NET.Windowing.Window.Create(options);

            window.Load += Window_Load;
            window.Update += Window_Update;
            window.Render += Window_Render;
            //window.Run();
            return window;
        }
        public System.IntPtr windowhandle;
        public Silk.NET.Windowing.IWindow window;

        //public Silk.NET.Windowing.IWindow NewImage(int height, int width, int mode = 0)
        //{
        //    Silk.NET.Windowing.WindowOptions options = Silk.NET.Windowing.WindowOptions.Default;
        //    options.Size = new Silk.NET.Maths.Vector2D<int>(800, 600);
        //    options.Title = "untitled";
        //    window = Silk.NET.Windowing.Window.Create(options);

        //    window.Load += Window_Load;
        //    window.Update += Window_Update;
        //    window.Render += Window_Render;

        //    return window;
        //}

        private void Window_Load()
        {
            Silk.NET.Input.IInputContext input = window.CreateInput();
            for (int i = 0; i < input.Keyboards.Count; i++)
            {
                input.Keyboards[i].KeyDown += KeyDown;
            }
        }

        private void Window_Render(double obj)
        {

        }

        private void Window_Update(double obj)
        {

        }

        private void KeyDown(IKeyboard arg1, Key arg2, int arg3)
        {
            if(arg2 == Key.Escape)
            {
                window.Close();
            }
        }
    }
}
