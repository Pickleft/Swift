using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Swift.Calls;

namespace Swift.Mods
{
    class Core
    {
        public static Random rnd = new Random();
        public static async void leftclick(IntPtr window, bool leftlock)
        {
            if (leftlock)
            {
                if (Control.MouseButtons == MouseButtons.Left)
                {
                    await Task.Delay(70);
                    if (Control.MouseButtons == MouseButtons.Left)
                    {
                        PostMessage(window, 0x201, 0, 0);
                        await Task.Delay(rnd.Next(1, 45));
                        PostMessage(window, 0x202, 0, 0);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                if (Control.MouseButtons.ToString().Contains("Left"))
                {
                    await Task.Delay(70);
                    if (Control.MouseButtons.ToString().Contains("Left"))
                    {
                        PostMessage(window, 0x201, 0, 0);
                        await Task.Delay(rnd.Next(1, 45));
                        PostMessage(window, 0x202, 0, 0);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public async static void breakblock(IntPtr window, bool leftlock)
        {
            if (leftlock)
            {
                if (Control.MouseButtons == MouseButtons.Left)
                {
                    await Task.Delay(70);
                    if (Control.MouseButtons == MouseButtons.Left)
                    {
                        PostMessage(window, 0x201, 0, 0);
                    }
                    else
                    {
                        return;
                    }
                }

            }
            else
            {
                if (Control.MouseButtons.ToString().Contains("Left"))
                {
                    await Task.Delay(70);
                    if (Control.MouseButtons.ToString().Contains("Left"))
                    {
                        PostMessage(window, 0x201, 0, 0);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public static async void Mode18(IntPtr window, bool leftlock)
        {
            if (leftlock)
            {
                if (Control.MouseButtons == MouseButtons.Left)
                {
                    await Task.Delay(70);
                    if (Control.MouseButtons == MouseButtons.Left)
                    {
                        PostMessage(window, 0x201, 0, 0);
                        await Task.Delay(rnd.Next(1, 3));
                        PostMessage(window, 0x202, 0, 0);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                if (Control.MouseButtons.ToString().Contains("Left"))
                {
                    await Task.Delay(70);
                    if (Control.MouseButtons.ToString().Contains("Left"))
                    {
                        PostMessage(window, 0x201, 0, 0);
                        await Task.Delay(rnd.Next(1, 3));
                        PostMessage(window, 0x202, 0, 0);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        public static async void rightclick(IntPtr window, bool leftlock)
        {
            if (leftlock)
            {
                if (Control.MouseButtons == MouseButtons.Right)
                {
                    await Task.Delay(70);
                    if (Control.MouseButtons == MouseButtons.Right)
                    {
                        PostMessage(window, 0x204, 0, 0);
                        await Task.Delay(rnd.Next(1, 45));
                        PostMessage(window, 0x205, 0, 0);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                if (Control.MouseButtons.ToString().Contains("Right"))
                {
                    await Task.Delay(70);
                    if (Control.MouseButtons.ToString().Contains("Right"))
                    {
                        PostMessage(window, 0x204, 0, 0);
                        await Task.Delay(rnd.Next(1, 45));
                        PostMessage(window, 0x205, 0, 0);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public async static void rodorfoodlol(IntPtr window, bool leftlock)
        {
            if (leftlock)
            {
                if (Control.MouseButtons == MouseButtons.Right)
                {
                    await Task.Delay(70);
                    if (Control.MouseButtons == MouseButtons.Right)
                    {
                        PostMessage(window, 0x204, 0, 0);
                    }
                    else
                    {
                        return;
                    }
                }

            }
            else
            {
                if (Control.MouseButtons.ToString().Contains("Right"))
                {
                    await Task.Delay(70);
                    if (Control.MouseButtons.ToString().Contains("Right"))
                    {
                        PostMessage(window, 0x204, 0, 0);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}
