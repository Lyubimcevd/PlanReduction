using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Data;
using System.Windows.Forms;

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
        DataTable ZG = new DataTable(),
            F = new DataTable();
        string plan_path,
            u_path,
            portfel_path;
        

        FortranReader()
        {
            StreamReader SR = new StreamReader("path.cfg");
            u_path = SR.ReadLine();
            plan_path = SR.ReadLine();
            portfel_path = SR.ReadLine();
        }

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
            BinaryReader reader = new BinaryReader(File.Open(u_path, FileMode.Open));
            reader.ReadInt32();
            nw = reader.ReadInt32();
            nu = reader.ReadInt32();
            reader.Close();
            reader = new BinaryReader(File.Open(plan_path, FileMode.Open));
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
                for (int i = 0; i < 40; i++) nxz += Encoding.GetEncoding(866).GetString(reader.ReadBytes(2));
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
                zak.NA = reader.ReadInt32();
                zak.NS = reader.ReadInt32();
                zak.NT = reader.ReadInt32();
                reader.ReadInt32();
                reader.ReadInt32();
                if (zak.NA < 0)
                {
                    for (int i = 0; i < nu-1; i++) ZG.Columns.Add();
                    for (int i = 0; i < lp; i++)
                    {
                        tmp = ZG.NewRow();
                        for (int j = 0; j < nu-1; j++) tmp[j] = reader.ReadInt16();
                        ZG.Rows.Add(tmp);
                    }
                    for (int i = 0; i < nu-1; i++) F.Columns.Add();
                    for (int i = 0; i < 3; i++)
                    {
                        tmp = F.NewRow();
                        for (int j = 0; j < nu-1; j++) tmp[j] = reader.ReadInt32();
                        F.Rows.Add(tmp);
                    }
                    result.Add(zak);
                    break;
                }                
                int k;
                for (int i = 0; i < zak.NA; i++)
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
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < zak.NS; i++)
                {
                    tmp = zak.Sostav.NewRow();
                    for (int j = 0; j < 2; j++) tmp[j] = reader.ReadInt16();
                    zak.Sostav.Rows.Add(tmp);
                }
                for (int i = 0; i < zak.NS; i++)
                {
                    tmp = zak.Primen.NewRow();
                    for (int j = 0; j < 2; j++) tmp[j] = reader.ReadInt16();
                    zak.Primen.Rows.Add(tmp);
                }
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < zak.NT; i++)
                {
                    tmp = zak.Tehnol.NewRow();
                    for (int j = 0; j < 6; j++) tmp[j] = reader.ReadInt16();
                    zak.Tehnol.Rows.Add(tmp);
                }
                for (int i = 0; i < zak.NT; i++)
                {
                    tmp = zak.TrudRasc.NewRow();
                    for (int j = 0; j < 4; j++) tmp[j] = reader.ReadInt32();
                    zak.TrudRasc.Rows.Add(tmp);
                }
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < zak.NT; i++)
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
            BinaryReader reader = new BinaryReader(File.Open(u_path, FileMode.Open));
            reader.ReadInt32();
            int nw = reader.ReadInt32(), nu = reader.ReadInt32();
            reader.Close();
            reader = new BinaryReader(File.Open(portfel_path, FileMode.Open));
            DataRow tmp;
            while (true)
            {
                reader.ReadInt32();
                string nxz = "";
                for (int i = 0; i < 40; i++) nxz += Encoding.GetEncoding(866).GetString(reader.ReadBytes(2));
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
                zak.RashetEdin = reader.ReadInt32();
                zak.DateInZayavke = reader.ReadInt32();
                zak.NA = reader.ReadInt32();
                zak.NS = reader.ReadInt32();
                zak.NT = reader.ReadInt32();
                reader.ReadInt32();
                if (zak.NA < 0)
                {
                    result.Add(zak);
                    break;
                }
                reader.ReadInt32();
                int k;
                for (int i = 0; i < zak.NA; i++)
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
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < zak.NS; i++)
                {
                    tmp = zak.Sostav.NewRow();
                    for (int j = 0; j < 2; j++) tmp[j] = reader.ReadInt16();
                    zak.Sostav.Rows.Add(tmp);
                }
                for (int i = 0; i < zak.NS; i++)
                {
                    tmp = zak.Primen.NewRow();
                    for (int j = 0; j < 2; j++) tmp[j] = reader.ReadInt16();
                    zak.Primen.Rows.Add(tmp);
                }
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < zak.NT; i++)
                {
                    tmp = zak.Tehnol.NewRow();
                    for (int j = 0; j < 6; j++) tmp[j] = reader.ReadInt16();
                    zak.Tehnol.Rows.Add(tmp);
                }
                for (int i = 0; i < zak.NT; i++)
                {
                    tmp = zak.TrudRasc.NewRow();
                    for (int j = 0; j < 4; j++) tmp[j] = reader.ReadInt32();
                    zak.TrudRasc.Rows.Add(tmp);
                }
                reader.ReadInt32();
                reader.ReadInt32();
                for (int i = 0; i < zak.NT; i++)
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
            Zakaz zak;
            for (int j = 0; j < result.Count-1; j++)
            {
                zak = result[j];
                writer.Write(80 + (nu + 11) * 4);
                writer.Write(Encoding.GetEncoding(866).GetBytes(zak.NXZ));
                foreach (DataRow dr in zak.NormaChas.Rows) writer.Write(Convert.ToInt32(dr[0]));
                writer.Write(Convert.ToInt32(zak.KolVZayavke));
                writer.Write(Convert.ToInt32(zak.Prior));
                writer.Write(Convert.ToInt32(zak.NormTrud));
                writer.Write(Convert.ToInt32(zak.LD));
                writer.Write(Convert.ToInt32(zak.RashetEdin));
                writer.Write(Convert.ToInt32(zak.OtnosSrokVipusk));
                writer.Write(Convert.ToInt32(zak.DateInZayavke));
                writer.Write(Convert.ToInt32(zak.MS));
                writer.Write(Convert.ToInt32(zak.NA));
                writer.Write(Convert.ToInt32(zak.NS));
                writer.Write(Convert.ToInt32(zak.NT));
                writer.Write(80 + (nu + 11) * 4);
                writer.Write(zak.NA * 52);
                foreach (DataRow dr in zak.Material.Rows)
                {
                    writer.Write(Convert.ToInt16(dr[0]));
                    writer.Write(Convert.ToInt16(dr[1]));
                    writer.Write(Convert.ToInt16(dr[2].ToString().Substring(0, 2)));
                    writer.Write(Convert.ToInt16(dr[2].ToString().Substring(2, 3)));
                    writer.Write(Convert.ToInt16(dr[2].ToString().Substring(5, 3)));
                    writer.Write(Convert.ToInt16(dr[3]));
                    writer.Write(Convert.ToInt16(dr[4]));
                    writer.Write(Convert.ToInt16(dr[5]));
                    writer.Write(Convert.ToInt16(dr[6]));
                    writer.Write(Convert.ToInt16(dr[7]));
                    writer.Write(Convert.ToInt16(dr[8]));
                    writer.Write(Convert.ToInt16(dr[9]));
                    writer.Write(Convert.ToInt16(dr[10]));
                    writer.Write(Convert.ToInt16(dr[11]));
                    writer.Write(Convert.ToInt16(dr[12]));
                    writer.Write(Convert.ToInt16(dr[13]));
                    writer.Write(Encoding.GetEncoding(866).GetBytes(dr[14].ToString()));
                }
                writer.Write(zak.NA * 52);
                writer.Write(zak.NS * 8);
                foreach (DataRow dr in zak.Sostav.Rows)
                {
                    writer.Write(Convert.ToInt16(dr[0]));
                    writer.Write(Convert.ToInt16(dr[1]));
                }
                foreach (DataRow dr in zak.Primen.Rows)
                {
                    writer.Write(Convert.ToInt16(dr[0]));
                    writer.Write(Convert.ToInt16(dr[1]));
                }
                writer.Write(zak.NS * 8);
                writer.Write(zak.NT * 28);
                foreach (DataRow dr in zak.Tehnol.Rows)
                {
                    for (int i = 0; i < zak.Tehnol.Columns.Count; i++) writer.Write(Convert.ToInt16(dr[i]));
                }
                foreach (DataRow dr in zak.TrudRasc.Rows)
                {
                    for (int i = 0; i < zak.TrudRasc.Columns.Count; i++) writer.Write(Convert.ToInt32(dr[i]));
                }
                writer.Write(zak.NT * 28);
                writer.Write(zak.NT * 8);
                foreach (DataRow dr in zak.SmenOtch.Rows)
                {
                    for (int i = 0; i < zak.SmenOtch.Columns.Count; i++) writer.Write(Convert.ToInt16(dr[i]));
                }
                writer.Write(zak.NT * 8);
            }
            zak = result.Last();
            writer.Write(80 + (nu + 11) * 4);
            writer.Write(Encoding.GetEncoding(866).GetBytes(zak.NXZ));
            foreach (DataRow dr in zak.NormaChas.Rows) writer.Write(Convert.ToInt32(dr[0]));
            writer.Write(Convert.ToInt32(zak.KolVZayavke));
            writer.Write(Convert.ToInt32(zak.Prior));
            writer.Write(Convert.ToInt32(zak.NormTrud));
            writer.Write(Convert.ToInt32(zak.LD));
            writer.Write(Convert.ToInt32(zak.RashetEdin));
            writer.Write(Convert.ToInt32(zak.OtnosSrokVipusk));
            writer.Write(Convert.ToInt32(zak.DateInZayavke));
            writer.Write(Convert.ToInt32(zak.MS));
            writer.Write(Convert.ToInt32(zak.NA));
            writer.Write(Convert.ToInt32(zak.NS));
            writer.Write(Convert.ToInt32(zak.NT));
            writer.Write(80 + (nu + 11) * 4);
            writer.Write((nu - 1) * (lp * 2 + 12));
            foreach (DataRow dr in ZG.Rows)
            {
                for (int i = 0; i < ZG.Columns.Count; i++) writer.Write(Convert.ToInt16(dr[i]));
            }
            foreach (DataRow dr in F.Rows)
            {
                for (int i = 0; i < F.Columns.Count; i++) writer.Write(Convert.ToInt32(dr[i]));
            }
            writer.Write((nu - 1) * (lp * 2 + 12));
            writer.Close();
            MessageBox.Show("Сохранено");
        }

        public void SavePortfel(List<Zakaz> result)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(@"D:\portfel.dat", FileMode.OpenOrCreate, FileAccess.Write));  
            foreach (Zakaz zak in result)
            {
                writer.Write(80 + (nu + 8) * 4);
                writer.Write(Encoding.GetEncoding(866).GetBytes(zak.NXZ));
                foreach (DataRow dr in zak.NormaChas.Rows) writer.Write(Convert.ToInt32(dr[0]));
                writer.Write(Convert.ToInt32(zak.KolVZayavke));
                writer.Write(Convert.ToInt32(zak.Prior));
                writer.Write(Convert.ToInt32(zak.NormTrud));
                writer.Write(Convert.ToInt32(zak.RashetEdin));
                writer.Write(Convert.ToInt32(zak.DateInZayavke));
                writer.Write(Convert.ToInt32(zak.NA));
                writer.Write(Convert.ToInt32(zak.NS));
                writer.Write(Convert.ToInt32(zak.NT));
                writer.Write(80 + (nu + 8) * 4);
                writer.Write(zak.NA * 52);
                foreach (DataRow dr in zak.Material.Rows)
                {
                    writer.Write(Convert.ToInt16(dr[0]));
                    writer.Write(Convert.ToInt16(dr[1]));
                    writer.Write(Convert.ToInt16(dr[2].ToString().Substring(0, 2)));
                    writer.Write(Convert.ToInt16(dr[2].ToString().Substring(2, 3)));
                    writer.Write(Convert.ToInt16(dr[2].ToString().Substring(5, 3)));
                    writer.Write(Convert.ToInt16(dr[3]));
                    writer.Write(Convert.ToInt16(dr[4]));
                    writer.Write(Convert.ToInt16(dr[5]));
                    writer.Write(Convert.ToInt16(dr[6]));
                    writer.Write(Convert.ToInt16(dr[7]));
                    writer.Write(Convert.ToInt16(dr[8]));
                    writer.Write(Convert.ToInt16(dr[9]));
                    writer.Write(Convert.ToInt16(dr[10]));
                    writer.Write(Convert.ToInt16(dr[11]));
                    writer.Write(Convert.ToInt16(dr[12]));
                    writer.Write(Convert.ToInt16(dr[13]));
                    writer.Write(Encoding.GetEncoding(866).GetBytes(dr[14].ToString()));
                }
                writer.Write(zak.NA * 52);
                writer.Write(zak.NS * 8);
                foreach (DataRow dr in zak.Sostav.Rows)
                {
                    writer.Write(Convert.ToInt16(dr[0]));
                    writer.Write(Convert.ToInt16(dr[1]));
                }
                foreach (DataRow dr in zak.Primen.Rows)
                {
                    writer.Write(Convert.ToInt16(dr[0]));
                    writer.Write(Convert.ToInt16(dr[1]));
                }
                writer.Write(zak.NS * 8);
                writer.Write(zak.NT * 28);
                foreach (DataRow dr in zak.Tehnol.Rows)
                {
                    for (int i = 0; i < zak.Tehnol.Columns.Count; i++) writer.Write(Convert.ToInt16(dr[i]));
                }
                foreach (DataRow dr in zak.TrudRasc.Rows)
                {
                    for (int i = 0; i < zak.TrudRasc.Columns.Count; i++) writer.Write(Convert.ToInt32(dr[i]));
                }
                writer.Write(zak.NT * 28);
                writer.Write(zak.NT * 8);
                foreach (DataRow dr in zak.SmenOtch.Rows)
                {
                    for (int i = 0; i < zak.SmenOtch.Columns.Count; i++) writer.Write(Convert.ToInt16(dr[i]));
                }
                writer.Write(zak.NT * 8);
            }
            writer.Write(80 + (nu + 8) * 4);
            writer.Write(Encoding.GetEncoding(866).GetBytes(result.Last().NXZ));
            foreach (DataRow dr in result.Last().NormaChas.Rows) writer.Write(Convert.ToInt32(dr[0]));
            writer.Write(Convert.ToInt32(result.Last().KolVZayavke));
            writer.Write(Convert.ToInt32(result.Last().Prior));
            writer.Write(Convert.ToInt32(result.Last().NormTrud));
            writer.Write(Convert.ToInt32(result.Last().RashetEdin));
            writer.Write(Convert.ToInt32(result.Last().DateInZayavke));
            writer.Write(Convert.ToInt32(result.Last().NA));
            writer.Write(Convert.ToInt32(result.Last().NS));
            writer.Write(Convert.ToInt32(result.Last().NT));
            writer.Write(80 + (nu + 8) * 4);
            writer.Close();
            MessageBox.Show("Сохранено");
        }
    }
}
