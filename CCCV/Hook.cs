using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MacrosAPI_v2;

namespace CCCV
{
    internal class Hook : Macros
    {
        internal MacrosManager manager = new MacrosManager(new MacrosUpdater());
        internal int select = 0;
        internal List<string> lines = new List<string>();
        public override bool OnKeyDown(Key key, bool repeat)
        {
            if (key != Key.RAlt) return false;
            if (lines.Count - 1 < select)
            {
                lines = new List<string>();
                select = 0;
                return false;
            }
            Console.WriteLine(lines[select]);
            SendKeys.SendWait(lines[select]);
            select++;
            return true;
        }
    }
}
