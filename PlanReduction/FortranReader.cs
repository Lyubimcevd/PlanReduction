using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace PlanReduction
{
    class FortranReader
    {
        static FortranReader fortran_reader;

        FortranReader() { }

        public static FortranReader GetFortranReader
        {
            get
            {
                if (fortran_reader == null) fortran_reader = new FortranReader();
                return fortran_reader;
            }
        }
       
        public List<Zakaz> ReadPlan()
        {
            List<Zakaz> result = new List<Zakaz>();      
            BinaryReader reader = new BinaryReader(File.Open("D:/u.dat", FileMode.Open));
            reader.ReadInt32();
            int nw = reader.ReadInt32(), nu = reader.ReadInt32();
            reader = new BinaryReader(File.Open("D:/plan.dat", FileMode.Open));
            reader.ReadInt32();
            int lp = reader.ReadInt32(),
                nn = reader.ReadInt32(),
                nk = reader.ReadInt32();
            reader.ReadInt32();
            reader.ReadInt32();
            for (int i = 0; i < lp * 2; i++) reader.ReadInt16();
            reader.ReadInt32();
            int k = 0;
            DataRow tmp;
            while (true)
            {        
                reader.ReadInt32();
                string nxz = "";
                for (int i = 0; i < 40; i++)
                {
                    nxz += Encoding.UTF8.GetString(reader.ReadBytes(2));
                    if (nxz == "\0\0") break;
                }
                if (nxz == "\0\0") break;
                Zakaz zak = new Zakaz(nxz);
                for (int i = 0; i < nu; i++)
                {
                    tmp = zak.NormaChas.NewRow();
                    tmp[0] = reader.ReadInt32();
                    zak.NormaChas.Rows.Add(tmp);
                }
                zak.KolVZayavke = reader.ReadInt32();
                zak.Prior = reader.ReadInt32();
                zak.PredpDateVipuska = reader.ReadInt32();
                reader.ReadInt32();
                zak.RashetEdin = reader.ReadInt32();
                zak.RealDateVipuska = reader.ReadInt32();
                zak.DateInZayavke = reader.ReadInt32();
                reader.ReadInt32();
                int na = reader.ReadInt32(),
                    ns = reader.ReadInt32(),
                    nt = reader.ReadInt32();
                reader.ReadInt32();
                if (reader.BaseStream.Position == reader.BaseStream.Length) break;
                reader.ReadInt32();
                for (int i = 0; i < na; i++)
                    for (int j = 0; j < 26; j++)
                    {
                        tmp = zak.Material.NewRow();
                        tmp[j] = reader.ReadInt16();
                        zak.Material.Rows.Add(tmp);
                    }
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < ns; i++)
                    for (int j = 0; j < 2; j++)
                    {
                        tmp = zak.Sostav.NewRow();
                        tmp[j] = reader.ReadInt16();
                        zak.Sostav.Rows.Add(tmp);
                    }
                for (int i = 0; i < ns; i++)
                    for (int j = 0; j < 2; j++)
                    {
                        tmp = zak.Primen.NewRow();
                        tmp[j] = reader.ReadInt16();
                        zak.Primen.Rows.Add(tmp);
                    }
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < nt; i++)
                    for (int j = 0; j < 6; j++)
                    {
                        tmp = zak.Tehnol.NewRow();
                        tmp[j] = reader.ReadInt16();
                        zak.Tehnol.Rows.Add(tmp);
                    }
                for (int i = 0; i < nt; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        tmp = zak.TrudRasc.NewRow();
                        tmp[j] = reader.ReadInt32();
                        zak.TrudRasc.Rows.Add(tmp);
                    }
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < nt; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        tmp = zak.SmenOtch.NewRow();
                        tmp[j] = reader.ReadInt16();
                        zak.SmenOtch.Rows.Add(tmp);
                    }
                reader.ReadInt32();
                result.Add(zak);
            }
            return result;           
        }
    }
}
