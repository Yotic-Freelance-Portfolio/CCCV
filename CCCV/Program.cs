using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCCV
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string lastline = "";
            Hook hook = new Hook();
            hook.manager.LoadMacros(hook);
            while (true)
            {
                try
                {
                    if (lastline != Clipboard.GetText())
                    {
                        lastline = Clipboard.GetText();
                        hook.lines = Clipboard.GetText().Split('\n').ToList();
                        hook.select = 0;
                        Console.WriteLine(lastline);
                    }
                }
                catch (Exception ex) { Console.WriteLine("Eroor: " + ex.Message); }
                Thread.Sleep(1000);
            }
        }
    }
}
