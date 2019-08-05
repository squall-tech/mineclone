using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineClone.utils
{
    class FormControl
    {
        public static void Maximize(GameWindow gameWindow)
        {
            Form form = (Form)Form.FromHandle(gameWindow.Handle);
            form.WindowState = FormWindowState.Maximized;
        }

        public static bool isFormActive (GameWindow gameWindow)
        {
            Form form = (Form)Form.FromHandle(gameWindow.Handle);
            return Form.ActiveForm == form;
        }
    }
}
