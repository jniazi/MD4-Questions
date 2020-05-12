using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MD4Problems
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            byte a , b , c ;
            a = Convert.ToByte(txtX.Text);
            b = Convert.ToByte(txtY.Text);
            c = Convert.ToByte(txtZ.Text);
            byte F = Convert.ToByte((a & b) | (~a & c));
            byte ai = Convert.ToByte((~a & b) | (a & c));
            byte aii = Convert.ToByte((a & ~b) | (~a & c));
            byte aiii = Convert.ToByte((a & b) | (byte)(~a & ~c));
            //lblinputs.Text = "(x= " + Convert.ToString(x) + ", y= " + Convert.ToString(y) + ", z= " + Convert.ToString(z) + ")";
            //lblinputs.Text = "(x= " + Convert.ToString(x, 2) + ", y= " + Convert.ToString(y, 2) + ", z= " + Convert.ToString(z, 2) + ")";
            lblF.Text = F.ToString();
            lblai.Text = ai.ToString();
            lblaii.Text = aii.ToString();
            lblaiii.Text = aiii.ToString();

            byte G = Convert.ToByte((a & b) | (a & c) | (b & c));
            byte bi = Convert.ToByte((~a & b) | (~a & c) | (b & c));
            byte bii = Convert.ToByte((a & ~b) | (a & c) | (~b & c));
            byte biii = Convert.ToByte((a & b) | (a & ~c) | (b & ~c));
            lblG.Text = G.ToString();
            lblBi.Text = bi.ToString();
            lblBii.Text = bii.ToString();
            lblBiii.Text = biii.ToString();

            byte Hi1 = Convert.ToByte(a ^ b ^ c);
            byte Hi2 = Convert.ToByte(~(~a ^ b ^ c));
            byte Hi3 = Convert.ToByte(~(a ^ ~b ^ c));
            byte Hi4 = Convert.ToByte(~(a ^ b ^ ~c));
            byte Hii2 = Convert.ToByte(~a ^ ~b ^ c);
            byte Hii3 = Convert.ToByte(~a ^ b ^ ~c);
            byte Hii4 = Convert.ToByte(a ^ ~b ^ ~c);
            lblci1.Text = Hi1.ToString();
            lblci2.Text = Hi2.ToString();
            lblci3.Text = Hi3.ToString();
            lblci4.Text = Hi4.ToString();
            lblcii1.Text = Hi1.ToString();
            lblcii2.Text = Hii2.ToString();
            lblcii3.Text = Hii3.ToString();
            lblcii4.Text = Hii4.ToString();

        }
    }
}
