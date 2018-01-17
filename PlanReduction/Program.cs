using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlanReduction
{
    class Program
    {
        static void Main(string[] args)
        {
            short[,] a = new short[200, 26],
                 s = new short[200, 2],
                 p = new short[200, 2],
                 tq = new short[500, 6],
                 tqc = new short[500, 4];
            short[] kdp = new short[300];
            int[,] qz = new int[500, 4];
            int[] iw = new int[100];
            
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
            for (int i = 0; i < lp * 2; i++) kdp[i] = reader.ReadInt16();
            reader.ReadInt32();
            reader.ReadInt32();
            char[] nxz = new char[80];
            nxz = reader.ReadChars(80);
            Zakaz zak = new Zakaz(nxz);
            for (int i = 0; i < nu; i++) iw[i] = reader.ReadInt32();
            int iq = reader.ReadInt32(),
                ip = reader.ReadInt32(),
                id = reader.ReadInt32(),
                ld = reader.ReadInt32(),
                lz = reader.ReadInt32(),
                lf = reader.ReadInt32(),
                mp = reader.ReadInt32(),
                ms = reader.ReadInt32(),
                na = reader.ReadInt32(),
                ns = reader.ReadInt32(),
                nt = reader.ReadInt32();
            reader.ReadInt32();
            reader.ReadInt32();
            for (int i = 0; i < na; i++)
                for (int j = 0; j < 26; j++) a[i, j] = reader.ReadInt16();
            reader.ReadInt32();
            reader.ReadInt32();
            for (int i = 0; i < ns; i++)
                for (int j = 0; j < 2; j++) s[i, j] = reader.ReadInt16();  
            for (int i = 0; i < ns; i++)
                for (int j = 0; j < 2; j++) p[i, j] = reader.ReadInt16();
            reader.ReadInt32();
            reader.ReadInt32();
            for (int i = 0; i < nt; i++)
                for (int j = 0; j < 6; j++) tq[i, j] = reader.ReadInt16();
            for (int i = 0; i < nt; i++)
                for (int j = 0; j < 4; j++) qz[i, j] = reader.ReadInt32();
            reader.ReadInt32();
            reader.ReadInt32();
            for (int i = 0; i < nt; i++)
                for (int j = 0; j < 4; j++) tqc[i, j] = reader.ReadInt16();
            
        }
    }
}
