using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Perm
{
    public partial class Form1 : Form
    {

        private const int POLLA_GIA_TO_LISTBOX = 1000;

        private static System.Diagnostics.Stopwatch sw;

        private int _m, _n;

        private int m
        {
            get
            {
                return this._m;
            }
            set
            {
                if (value == this._m) return;
                this._m = value;
                this.clearApot();
                this.checkValidMN(this.m, this.n);
            }
        }
        private int n
        {
            get
            {
                return this._n;
            }
            set
            {
                if (value == this._n) return;
                this._n = value;
                this.clearApot();
                this.checkValidMN(this.m, this.n);
            }
        }


        public Form1()
        {
            InitializeComponent();
        }


        public void checkValidMN(int m, int n)
        {
            this.btnGo.Enabled = MathPerm.isValidMN_giaDywnymo(m, n);

        }


        private void Run()
        {
            if (MathPerm.isValidMN_giaDywnymo(this.m, this.n))
            {
                sw = System.Diagnostics.Stopwatch.StartNew();
                System.Func<int, int, int[][]> f = new Func<int, int, int[][]>(MathPerm.dywnymo);
                f.BeginInvoke(this.m, this.n, new AsyncCallback(this.telosYpologismos), f);
            }
            else
            {
                MessageBox.Show("invalid input");
            }
        }

        private void telosYpologismos(IAsyncResult iar)
        {
            sw.Stop();
            int[][] ar = ((System.Func<int, int, int[][]>)iar.AsyncState).EndInvoke(iar);
            this.Invoke(new System.Action<int[][]>(displayApot), new object[] { ar });
        }

        private void displayApot(int[][] apot)
        {
            this.label3.Text = String.Format("{0} ms", sw.ElapsedMilliseconds);
            if (apot.Length > POLLA_GIA_TO_LISTBOX)
            {
                MessageBox.Show(apot.Length.ToString() + " einai polla gia to listbox");
                return;
            }
            this.listBox1.Items.Clear();
            this.listBox1.BeginUpdate();
            foreach (int[] perm in apot)
            {
                string str = string.Join(" ", perm.Select(i => i.ToString()).ToArray());
                this.listBox1.Items.Add(str);
            }
            this.listBox1.EndUpdate();
            MessageBox.Show(apot.Length.ToString());
        }

        private void clearTxts()
        {
            this.txtM.Clear();
            this.txtN.Clear();
        }

        private void clearApot()
        {
            this.listBox1.Items.Clear();
        }


        private void textBox1_Validated(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (string.IsNullOrEmpty(t.Text))
            {
                return;
            }
            int i;
            if (int.TryParse(t.Text, out  i))
            {
                if (t == this.txtM)
                {
                    this.m = i;
                }
                else if (t == this.txtN)
                {
                    this.n = i;
                }
            }
            else
            {
                t.Clear();
                return;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Run();
        }

        private void btnClearApot_Click(object sender, EventArgs e)
        {
            clearApot();
        }

        private void btnClearOla_Click(object sender, EventArgs e)
        {
            clearApot();
            clearTxts();
        }
    }
}
