using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Perm
{
public     static class MathPerm
    {

        private const int MEXRI_TOSA_APOT = Int32.MaxValue ;

        internal static ulong paragontiko(byte n)
        {
            ulong r = 1;
            checked
            {
                for (int i = 2; i < (int)(n + 1); i++)
                {
                    r *= (ulong)i;
                }
            }
            return r;
        }

        private static ulong megalo_dywnymo_posa(int m, int n)
        {
            int a = System.Math.Max(m, n - m);
            ulong p1 = paragontiko((byte)System.Math.Min(m, n - m));
            ulong p2 = 1;
            checked
            {
                for (int i = a + 1; i < n + 1; i++)
                {
                    p2 *= (ulong)i;
                }
            }

            return (ulong)(p2 / p1);
        }
        public static ulong  dywnymo_posa(int m, int n)
        {
            ulong result = 0;
            try
            {
                ulong pm = paragontiko((byte)m);
                ulong pn = paragontiko((byte)n);
                ulong pnm = paragontiko((byte)(n - m));
                result = (ulong)(pn / (ulong)(pm * pnm));
            }
            catch (OverflowException)
            {
                try
                {
                    result = megalo_dywnymo_posa(m, n);
                }
                catch (OverflowException)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            // aplopoiountai ta pollaplasia
            return result;
        }

        public static int[][] dywnymo(int m, int n)
        {
            if (!(m > 0 & n > 0)) throw new ArgumentException();

            m = Math.Min(m, n);
            n = Math.Max(m, n);
			
			// 1000!/999! = 1000, αλλά το 1000 και το 999 είναι δύσκολο να υπολογιστουν ξεχωριστά
			// πρέπει η dywnymo_posa να να κάνει απλοποιήσεις για να υπολογίζει μεγάλα αποτελέσματα
            // int posa =(int) dywnymo_posa(m, n);
            List<int[]> postab = new List<int[]>(/* posa */);
			// αν έχει υπολογιστεί το posa γίνεται και με 2διάστατο array
			// και χωρίς να έχει υπολογιστεί γίνεται αλλά θα πρέπει το array να αυξάνεται δυναμικά
			// αυτό κάνει το List

			// αριθμός επιλογών (φορές)
            int times = 0;
			
            int j = m;
            int k = 0;

            // 0 to m - 1
			// ο πίνακας που κρατάει μια επιλογή
            int[] pos = new int[m];
            for (int i = 0; i < m; i++)
            {
				// αρχικά έχει την επιλογή 1, 2, ... , m
                pos[i] = i + 1;
            }
			// συνθήκη για το τέλος του main loop
            bool @bool = true;
            while (@bool)
            {
                // πρόσθεση νέας επιλογής στη λίστα
				times++;
                postab.Add(pos.ToArray());
				
				// ...
                pos[m-1]++;
                j = m -1;
                while (j > 0)
                {
                    if (pos[j] > n - (m - 1 - j))
                    {
                        pos[j - 1]++;
                        k = 0;
                        while (j + k < m)
                        {
                            pos[j + k] = pos[j + k - 1] + 1;
                            k++;
                        }
                    }
                    j--;
                }
                @bool = (pos[m-1] < n + 1);
            }
            return postab.ToArray();
        }

        public static bool isValidMN_giaDywnymo(int m, int n)
        {
            if (m < 1 || n < 1 || m > n) return false;
            ulong posa;
            try
            {
                posa = MathPerm.dywnymo_posa(m, n);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            // return (m <= n) && (posa <= MEXRI_TOSA_APOT);
        }



    }
}
