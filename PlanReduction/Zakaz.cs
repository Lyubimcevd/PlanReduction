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

        void MaterialInit()
        {
            material.Columns.Add("Ссылка на строку");
            material.Columns.Add("№ детали");
            material.Columns.Add("Материал(1ч)");
            material.Columns.Add("Материал(2ч)");
            material.Columns.Add("Материал(3ч)");
            material.Columns.Add("Длина");
            material.Columns.Add("Ширина");
            material.Columns.Add("Толщина");
            material.Columns.Add("№ марш. карты");
            material.Columns.Add("Матрица состава");
            material.Columns.Add("Кол-во строк матрицы состава");
            material.Columns.Add("Матрица технологий");
            material.Columns.Add("Кол-во строк матрицы технологий");
            material.Columns.Add("Матрица применяемости");
            material.Columns.Add("Кол-во строк матрицы применяемости");
            material.Columns.Add("Рабочий элемент");
            material.Columns.Add("№ чертежа(№ заказа)");
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
            tehnol.Columns.Add("№ ссылки на участок");
            tehnol.Columns.Add("Шифр оборудования");
            tehnol.Columns.Add("№ строки матрицы материалов");
            tehnol.Columns.Add("Относ. день начала операции");
            tehnol.Columns.Add("День конца операции");
            tehnol.Columns.Add("День передачи следующему исполнителю");
        }
        void TrudRascInit()
        {
            trud_rasc.Columns.Add("Трудоёмкость");
            trud_rasc.Columns.Add("Расценок");
            trud_rasc.Columns.Add("Рабочий элемент 1");
            trud_rasc.Columns.Add("Рабочий элемент 2");
        }
        void SmenOtchInit()
        {
            smen_otch.Columns.Add("День запуска операции");
            smen_otch.Columns.Add("Отметка выполнения(0-выполнено и фикс день)");
            smen_otch.Columns.Add("Табельный номер исполнителя");
            smen_otch.Columns.Add("Рабочий элемент");
        }
    }
}
