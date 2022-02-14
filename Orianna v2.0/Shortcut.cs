using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWshRuntimeLibrary;

namespace Orianna_v2._0
{
    class Shortcut
    {

        public void CreateShortcut(string local, string destiny)
        {
            WshShell wshShell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)wshShell.CreateShortcut(destiny);
            shortcut.TargetPath = local;
            shortcut.Description = "Atalho Orianna";
            shortcut.Save();
            
        }
    }
}
