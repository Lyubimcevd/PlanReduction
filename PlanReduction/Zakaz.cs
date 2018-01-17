using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PlanReduction
{
    class Zakaz
    {
        string n_zak,n_cherch_instr,n_cherch_det,naim_instr,naim_izd;
        DataTable IW = new DataTable(),


        public Zakaz(char[] nxz)
        {
            string str = new string(nxz);
            string[] mas = str.Split(' ');
            List<string> list1 = new List<string>();
            foreach (string tmp in mas)
                if (tmp.Length != 0) list1.Add(tmp);
            n_zak = list1[0];
            n_cherch_instr = list1[2];
            n_cherch_det = list1[3];
            naim_instr = list1[4];
            naim_izd = list1[5];
        }

    }
}
