﻿using System;
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
        int nn, 
            nk,
            nu,
            nw,
            lp;
        List<short> KDP = new List<short>();

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
            BinaryReader reader = new BinaryReader(File.Open(@"F:\ASUIPW\tek_INF\u.dat", FileMode.Open));
            reader.ReadInt32();
            nw = reader.ReadInt32();
            nu = reader.ReadInt32();
            reader.Close();
            reader = new BinaryReader(File.Open(@"F:\ASUIPW\tek_INF\plan.dat", FileMode.Open));
            reader.ReadInt32();
            lp = reader.ReadInt32();
            nn = reader.ReadInt32();
            nk = reader.ReadInt32();
            reader.ReadInt32();
            reader.ReadInt32();
            for (int i = 0; i < lp * 2; i++) KDP.Add(reader.ReadInt16());
            reader.ReadInt32();
            DataRow tmp;
            while (true)
            {        
                reader.ReadInt32();
                string nxz = "";
                for (int i = 0; i < 40; i++)
                {
                    nxz += Encoding.GetEncoding(866).GetString(reader.ReadBytes(2));
                    if (!Char.IsNumber(nxz[0])) break;
                }
                if (!Char.IsNumber(nxz[0])) break;
                Zakaz zak = new Zakaz(nxz);
                for (int i = 0; i < nu; i++)
                {
                    tmp = zak.NormaChas.NewRow();
                    tmp[0] = reader.ReadInt32();
                    zak.NormaChas.Rows.Add(tmp);
                }
                zak.KolVZayavke = reader.ReadInt32();
                zak.Prior = reader.ReadInt32();
                zak.NormTrud = reader.ReadInt32();
                zak.LD = reader.ReadInt32();
                zak.RashetEdin = reader.ReadInt32();
                zak.OtnosSrokVipusk = reader.ReadInt32();
                zak.DateInZayavke = reader.ReadInt32();
                zak.MS = reader.ReadInt32();
                int na = reader.ReadInt32(),
                    ns = reader.ReadInt32(),
                    nt = reader.ReadInt32();
                reader.ReadInt32();
                if (reader.BaseStream.Position == reader.BaseStream.Length) break;
                int a = 0;
                a = reader.ReadInt32();
                int k;
                for (int i = 0; i < na; i++)
                {
                    tmp = zak.Material.NewRow();
                    k = 0;
                    for (int j = 0; j < 16; j++)
                    {
                        switch (j)
                        {
                            case 2:
                                tmp[2] = reader.ReadInt16().ToString().PadLeft(2, '0');
                                break;
                            case 3:
                                tmp[2] += reader.ReadInt16().ToString().PadLeft(3, '0');
                                break;
                            case 4:
                                tmp[2] += reader.ReadInt16().ToString().PadLeft(3, '0');
                                k++;
                                break;
                            default:
                                tmp[k] = reader.ReadInt16();
                                k++;
                                break;
                        }
                    }
                    tmp[14] = "";
                    for (int j = 0; j < 10; j++) tmp[14] += Encoding.GetEncoding(866).GetString(reader.ReadBytes(2));
                    zak.Material.Rows.Add(tmp);
                }
                a = reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < ns; i++)
                {
                    tmp = zak.Sostav.NewRow();
                    for (int j = 0; j < 2; j++) tmp[j] = reader.ReadInt16();
                    zak.Sostav.Rows.Add(tmp);
                }
                for (int i = 0; i < ns; i++)
                {
                    tmp = zak.Primen.NewRow();
                    for (int j = 0; j < 2; j++) tmp[j] = reader.ReadInt16();
                    zak.Primen.Rows.Add(tmp);
                }
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < nt; i++)
                {
                    tmp = zak.Tehnol.NewRow();
                    for (int j = 0; j < 6; j++) tmp[j] = reader.ReadInt16();
                    zak.Tehnol.Rows.Add(tmp);
                }
                for (int i = 0; i < nt; i++)
                {
                    tmp = zak.TrudRasc.NewRow();
                    for (int j = 0; j < 4; j++) tmp[j] = reader.ReadInt32();
                    zak.TrudRasc.Rows.Add(tmp);
                }
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < nt; i++)
                {
                    tmp = zak.SmenOtch.NewRow();
                    for (int j = 0; j < 4; j++) tmp[j] = reader.ReadInt16();
                    zak.SmenOtch.Rows.Add(tmp);
                }
                reader.ReadInt32();
                result.Add(zak);
            }
            reader.Close();
            return result;           
        }

        public List<Zakaz> ReadPortfel()
        {
            List<Zakaz> result = new List<Zakaz>();
            BinaryReader reader = new BinaryReader(File.Open(@"F:\ASUIPW\tek_INF\u.dat", FileMode.Open));
            reader.ReadInt32();
            int nw = reader.ReadInt32(), nu = reader.ReadInt32();
            reader.Close();
            reader = new BinaryReader(File.Open(@"F:\ASUIPW\tek_INF\portfel.dat", FileMode.Open));
            DataRow tmp;
            while (true)
            {
                reader.ReadInt32();
                string nxz = "";
                for (int i = 0; i < 40; i++)
                {
                    nxz += Encoding.GetEncoding(866).GetString(reader.ReadBytes(2));
                    if (!Char.IsNumber(nxz[0])) break;
                }
                if (!Char.IsNumber(nxz[0])) break;
                Zakaz zak = new Zakaz(nxz);
                for (int i = 0; i < nu; i++)
                {
                    tmp = zak.NormaChas.NewRow();
                    tmp[0] = reader.ReadInt32();
                    zak.NormaChas.Rows.Add(tmp);
                }
                zak.KolVZayavke = reader.ReadInt32();
                zak.Prior = reader.ReadInt32();
                zak.OtnosSrokVipusk = reader.ReadInt32();
                zak.RashetEdin = reader.ReadInt32();
                zak.DateInZayavke = reader.ReadInt32();
                int na = reader.ReadInt32(),
                    ns = reader.ReadInt32(),
                    nt = reader.ReadInt32();
                reader.ReadInt32();
                if (reader.BaseStream.Position == reader.BaseStream.Length) break;
                reader.ReadInt32();
                for (int i = 0; i < na; i++)
                {
                    tmp = zak.Material.NewRow();
                    for (int j = 0; j < 16; j++) tmp[j] = reader.ReadInt16();
                    tmp[16] = "";
                    for (int j = 16; j < 26; j++) tmp[16] += Encoding.GetEncoding(866).GetString(reader.ReadBytes(2));
                    zak.Material.Rows.Add(tmp);
                }
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < ns; i++)
                {
                    tmp = zak.Sostav.NewRow();
                    for (int j = 0; j < 2; j++) tmp[j] = reader.ReadInt16();
                    zak.Sostav.Rows.Add(tmp);
                }
                for (int i = 0; i < ns; i++)
                {
                    tmp = zak.Primen.NewRow();
                    for (int j = 0; j < 2; j++) tmp[j] = reader.ReadInt16();
                    zak.Primen.Rows.Add(tmp);
                }
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < nt; i++)
                {
                    tmp = zak.Tehnol.NewRow();
                    for (int j = 0; j < 6; j++) tmp[j] = reader.ReadInt16();
                    zak.Tehnol.Rows.Add(tmp);
                }
                for (int i = 0; i < nt; i++)
                {
                    tmp = zak.TrudRasc.NewRow();
                    for (int j = 0; j < 4; j++) tmp[j] = reader.ReadInt32();
                    zak.TrudRasc.Rows.Add(tmp);
                }
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < nt; i++)
                {
                    tmp = zak.SmenOtch.NewRow();
                    for (int j = 0; j < 4; j++) tmp[j] = reader.ReadInt16();
                    zak.SmenOtch.Rows.Add(tmp);
                }
                reader.ReadInt32();
                result.Add(zak);
            }
            reader.Close();
            return result;
        }

        public string NN
        {
            get
            {
                string tmp = nn.ToString().PadLeft(8,'0');
                return tmp.Substring(0,2)+'.'+tmp.Substring(2,2)+'.'+tmp.Substring(4,4);
            }
        }
        public string NK
        {
            get
            {
                string tmp = nk.ToString().PadLeft(8, '0');
                return tmp.Substring(0, 2) + '.' + tmp.Substring(2, 2) + '.' + tmp.Substring(4, 4);
            }
        }

        public void SavePlan(List<Zakaz> result)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(@"D:\plan.dat", FileMode.OpenOrCreate,FileAccess.Write));
            writer.Write(12);
            writer.Write(lp);
            writer.Write(nn);
            writer.Write(nk);
            writer.Write(12);
            writer.Write(lp*4);
            foreach (short tmp in KDP) writer.Write(tmp);
            writer.Write(lp*4);
            foreach (Zakaz zak in result)
            {
                writer.Write(80 + (nu + 11) * 4);
                writer.Write(zak.NXZ);
                foreach (DataRow dr in zak.NormaChas.Rows) writer.Write(Convert.ToInt32(dr[0]));
                writer.Write(80 + (nu + 11) * 4);


            }
            writer.Close();
        }
    }
}
