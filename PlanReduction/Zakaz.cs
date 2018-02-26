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
            n_form,
            cherch_instr,
            cherch_det,
            naim,
            nom_izd,
            ceh_zak,
            ceh_izgot;
        DataTable norma_chas = new DataTable(),
            material = new DataTable(),
            sostav = new DataTable(),
            primen = new DataTable(),
            tehnol = new DataTable(),
            trud_rasc = new DataTable(),
            smen_otch = new DataTable();
        int kol_v_zay,
            prior,
            norm_trud,
            rasch_edin,
            date_in_zay,
            otnos_srok_vipusk,
            ld,
            ms;

        public Zakaz(string nxz)
        {
            n_zak = nxz.Substring(0, 18).Trim();
            n_form = nxz.Substring(18, 2).Trim();
            cherch_instr = nxz.Substring(20, 20).Trim();
            cherch_det = nxz.Substring(40, 20).Trim();
            naim = nxz.Substring(60, 10).Trim();
            nom_izd = nxz.Substring(70, 4).Trim();
            ceh_zak = nxz.Substring(74, 4).Trim();
            ceh_izgot = nxz.Substring(78, 2).Trim();

            norma_chas.Columns.Add();
            MaterialInit();
            SostavInit();
            PrimenInit();
            TehnolInit();
            TrudRascInit();
            SmenOtchInit();
        }

        public string NumberOfZakaz
        {
            get
            {
                return n_zak;
            }
        }
        public string NomForm
        {
            get
            {
                return n_form;
            }
            set
            {
                n_form = value;
            }
        }
        public string CherchInstr
        {
            get
            {
                return cherch_instr;
            }
            set
            {
                cherch_instr = value;
            }
        }
        public string CherchDet
        {
            get
            {
                return cherch_det;
            }
            set
            {
                cherch_det = value;
            }
        }
        public string Naim
        {
            get
            {
                return naim;
            }
            set
            {
                naim = value;
            }
        }
        public string NomIzd
        {
            get
            {
                return nom_izd;
            }
            set
            {
                nom_izd = value;
            }
        }
        public string CehZak
        {
            get
            {
                return ceh_zak;
            }
            set
            {
                ceh_zak = value;
            }
        }
        public string CehIzgot
        {
            get
            {
                return ceh_izgot;
            }
            set
            {
                ceh_izgot = value;
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
        public int NormTrud
        {
            get
            {
                return norm_trud;
            }
            set
            {
                norm_trud = value;
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
        public int OtnosSrokVipusk
        {
            get
            {
                return otnos_srok_vipusk;
            }
            set
            {
                otnos_srok_vipusk = value;
            }
        }
        public int LD
        {
            get
            {
                return ld;
            }
            set
            {
                ld = value;
            }
        }
        public int MS
        {
            get
            {
                return ms;
            }
            set
            {
                ms = value;
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

        public string NXZ
        {
            get
            {
                return NumberOfZakaz.PadRight(18, ' ') + NomForm.PadRight(2, ' ') + CherchInstr.PadRight(20, ' ') + CherchDet.PadRight(20, ' ') + Naim.PadRight(10, ' ')
                    + NomIzd.PadRight(4, ' ') + CehZak.PadRight(4, ' ') + CehIzgot.PadRight(2, ' ');
            }
        }

        void MaterialInit()
        {
            material.Columns.Add("Ссылка на строку");  //1
            material.Columns.Add("№ детали");  //2
            material.Columns.Add("Материал(Ном.номер)");  //345
            material.Columns.Add("Длина");  //6
            material.Columns.Add("Ширина");  //7
            material.Columns.Add("Толщина");   //8
            material.Columns.Add("№ МТК");   //9
            material.Columns.Add("Матрица состава");  //10
            material.Columns.Add("Кол-во строк матрицы состава");   //11
            material.Columns.Add("Матрица технологий");   //12
            material.Columns.Add("Кол-во строк матрицы технологий");  //13
            material.Columns.Add("Матрица применяемости");   //14
            material.Columns.Add("Кол-во строк матрицы применяемости");   //15
            material.Columns.Add("Рабочий элемент");   //16
            material.Columns.Add("Обозначение детали");   //17
        }
        void SostavInit()
        {
            sostav.Columns.Add("Ссылка на материал");
            sostav.Columns.Add("Кол-во строк матрицы материалов");
        }
        void PrimenInit()
        {
            primen.Columns.Add("Ссылка на материал");
            primen.Columns.Add("Кол-во строк матрицы материалов");
        }
        void TehnolInit()
        {
            tehnol.Columns.Add("Ссылка на участок");
            tehnol.Columns.Add("Шифр оборудования");
            tehnol.Columns.Add("№ строки матрицы материалов");
            tehnol.Columns.Add("Относ. день начала операции");
            tehnol.Columns.Add("День конца операции");
            tehnol.Columns.Add("День передачи следующему исполнителю");
        }
        void TrudRascInit()
        {
            trud_rasc.Columns.Add("Трудоёмкость");
            trud_rasc.Columns.Add("Расценка");
            trud_rasc.Columns.Add("Рабочий элемент 1");
            trud_rasc.Columns.Add("Рабочий элемент 2");
        }
        void SmenOtchInit()
        {
            smen_otch.Columns.Add("Месяц");
            smen_otch.Columns.Add("Количество");
            smen_otch.Columns.Add("Табельный номер исполнителя");
            smen_otch.Columns.Add("Рабочий элемент");
        }
    }
}
