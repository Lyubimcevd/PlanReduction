using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanReduction
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            List<Zakaz> zakazs = FortranReader.GetFortranReader.ReadPlan();
            Application.Run(new Form1());
        }
    }
}
