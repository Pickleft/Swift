using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Swift.Calls;

namespace Swift.Mods
{
    internal class Core
    {
        #region Properties
        public static Random rnd = new Random();
        #endregion

        #region Left
        public static async Task leftclick(IntPtr window, bool leftlock, int timeout)
        {
            int delay = timeout / 2;
            int random = rnd.Next(delay / 2);
            switch (leftlock)
            {
                case true:
                    if (Control.MouseButtons == MouseButtons.Left)
                    {
                        SendMessage(window, 0x201, 0, 0);
                        await Task.Delay(delay - random); // random & split to humanize the clicks.
                        SendMessage(window, 0x202, 0, 0);
                        await Task.Delay(delay + random);
                    }
                    break;
                case false:
                    if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
                    {
                        SendMessage(window, 0x201, 0, 0);
                        await Task.Delay(delay - random); // random & split to humanize the clicks.
                        SendMessage(window, 0x202, 0, 0);
                        await Task.Delay(delay + random);
                    }
                    break;
            }
        }

        public static async Task breakblock(IntPtr window, bool leftlock, int timeout)
        {
            int delay = timeout / 2;
            int random = rnd.Next(delay / 2);
            switch (leftlock)
            {
                case true:
                    if (Control.MouseButtons == MouseButtons.Left)
                    {
                        await Task.Delay(delay - random);
                        SendMessage(window, 0x201, 0, 0);
                        await Task.Delay(delay + random);
                    }
                    break;
                case false:
                    if ((Control.MouseButtons & MouseButtons.Left) > 0)
                    {
                        await Task.Delay(delay - random);
                        SendMessage(window, 0x201, 0, 0);
                        await Task.Delay(delay + random);
                    }
                    break;
            }
        }

        public static async Task Mode18(IntPtr window, bool leftlock, int timeout)
        {
            switch (leftlock)
            {
                case true:
                    if (Control.MouseButtons == MouseButtons.Left)
                    {
                        await Task.Delay(timeout);
                        SendMessage(window, 0x201, 0, 0);
                        await Task.Delay(rnd.Next(1, 4)); // random to prevent static delay & sleep for key strokes
                        SendMessage(window, 0x202, 0, 0);
                    }
                    break;
                case false:
                    if ((Control.MouseButtons & MouseButtons.Left) > 0)
                    {
                        await Task.Delay(timeout);
                        SendMessage(window, 0x201, 0, 0);
                        await Task.Delay(rnd.Next(1, 4)); // random to prevent static delay & sleep for key strokes
                        SendMessage(window, 0x202, 0, 0);
                    }
                    break;
            }

        }
        #endregion

        #region Right
        public static async Task rightclick(IntPtr window, bool rightlock, int timeout)
        {
            int delay = timeout / 2;
            int random = rnd.Next(delay / 2);
            switch (rightlock)
            {
                case true:
                    if (Control.MouseButtons == MouseButtons.Right)
                    {
                        await Task.Delay(delay - random);
                        SendMessage(window, 0x204, 0, 0);
                        await Task.Delay(delay + random);  // random & split to humanize the clicks.
                        SendMessage(window, 0x205, 0, 0);
                    }
                    break;
                case false:
                    if ((Control.MouseButtons & MouseButtons.Right) > 0)
                    {
                        await Task.Delay(delay - random);
                        SendMessage(window, 0x204, 0, 0);
                        await Task.Delay(delay + random);  // random & split to humanize the clicks.
                        SendMessage(window, 0x205, 0, 0);
                    }
                    break;
            }
        }

        public static async Task rodorfoodlol(IntPtr window, bool rightlock, int timeout)
        {
            int delay = timeout / 2;
            int random = rnd.Next(delay / 2);
            switch (rightlock)
            {
                case true:
                    if (Control.MouseButtons == MouseButtons.Right)
                    {
                        await Task.Delay(delay - random);
                        SendMessage(window, 0x204, 0, 0);
                        await Task.Delay(delay + random);  // random & split to humanize the clicks.
                    }
                    break;
                case false:
                    if ((Control.MouseButtons & MouseButtons.Right) > 0)
                    {
                        await Task.Delay(delay - random);
                        SendMessage(window, 0x204, 0, 0);
                        await Task.Delay(delay + random);  // random & split to humanize the clicks.
                    }
                    break;
            }

        }
        #endregion
    }
}
