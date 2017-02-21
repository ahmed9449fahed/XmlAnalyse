using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlAnalyser.UserInterface;

namespace XmlAnalyser
{
    class EntryPoint
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new MainView());

        }
    }
}
