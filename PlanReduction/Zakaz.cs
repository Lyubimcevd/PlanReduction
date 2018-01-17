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
        string n_zak,
            n_cherch_instr,
            n_cherch_det,
            naim_instr,
            naim_izd;
        DataTable norma_chas = new DataTable(),
            material = new DataTable(),
            sostav = new DataTable(),
            primen = new DataTable(),
            tehnol = new DataTable(),
            trud_rasc = new DataTable(),
            smen_otch = new DataTable();
        int kol_v_zay,
            prior,
            predp_date_vip,
            rasch_edin,
            date_in_zay,
            real_date_vip;

        public Zakaz(string nxz)
        {
            string[] mas = nxz.Split(' ');
            List<string> list1 = new List<string>();
            foreach (string tmp in mas)
                if (tmp.Length != 0) list1.Add(tmp);
            n_zak = list1[0];
            n_cherch_instr = list1[2];
            n_cherch_det = list1[3];
            naim_instr = list1[4];
            if (list1.Count > 5) naim_izd = list1[5];

            norma_chas.Columns.Add();
            for (int i = 0; i < 26; i++) material.Columns.Add();
            for (int i = 0; i < 2; i++) sostav.Columns.Add();
            for (int i = 0; i < 2; i++) primen.Columns.Add();
            for (int i = 0; i < 6; i++) tehnol.Columns.Add();
            for (int i = 0; i < 4; i++) trud_rasc.Columns.Add();
            for (int i = 0; i < 4; i++) smen_otch.Columns.Add();
        }

        public string NumberOfZakaz
        {
            get
            {
                return n_zak;
            }
        }
        public string NumberOfCherchInstr
        {
            get
            {
                return n_cherch_instr;
            }
        }
        public string NumberOfCherchDet
        {
            get
            {
                return n_cherch_det;
            }
        }
        public string NaimInstr
        {
            get
            {
                return naim_instr;
            }
        }
        public string NaimIzd
        {
            get
            {
                return naim_izd;
            }
        }
        public int KolVZayavke
        {
            get
            {
                return kol_v_zay;
            }
            set
            {
                kol_v_zay = value;
            }
        }
        public int Prior
        {
            get
            {
                return prior;
            }
            set
            {
                prior = value;
            }
        }
        public int PredpDateVipuska
        {
            get
            {
                return predp_date_vip;
            }
            set
            {
                predp_date_vip = value;
            }
        }
        public int RashetEdin
        {
            get
            {
                return rasch_edin;
            }
            set
            {
                rasch_edin = value;
            }
        }
        public int DateInZayavke
        {
            get
            {
                return date_in_zay;
            }
            set
            {
                date_in_zay = value;
            }
        }
        public int RealDateVipuska
        {
            get
            {
                return real_date_vip;
            }
            set
            {
                real_date_vip = value;
            }
        }
        public DataTable NormaChas
        {
            get
            {
                return norma_chas;
            }
        }
        public DataTable Material
        {
            get
            {
                return material;
            }
        }
        public DataTable Sostav
        {
            get
            {
                return sostav;
            }
        }
        public DataTable Primen
        {
            get
            {
                return primen;
            }
        }
        public DataTable Tehnol
        {
            get
            {
                return tehnol;
            }
        }
        public DataTable TrudRasc
        {
            get
            {
                return trud_rasc;
            }
        }
        public DataTable SmenOtch
        {
            get
            {
                return smen_otch;
            }
        }
    }
}
