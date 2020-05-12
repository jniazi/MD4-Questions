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
    public partial class Q19 : Form
    {
        public Q19()
        {
            InitializeComponent();
        }
        uint _X12 = 0x2c363731 + 1 //0x2c36373
            , X0 = 0x9074449b, X1 = 0x1089fc26, X2 = 0x8bf37fa2, X3 = 0x1d630daf,
                X4 = 0x63247e24, X5 = 0x4e4f430a, X6 = 0x43415254, X7 = 0x410a0a54,
                X8 = 0x68742074, X9 = 0x72702065, X10 = 0x20656369, X11 = 0x2420666f,
                X12 = 0x2c363731, X13 = 0x20353934, X14 = 0x20666c41, X15 = 0x776f6c42;
        uint a = 0x67452301, b = 0xefcdab89, c = 0x98badcfe, d = 0x10325476, aa, bb, cc, dd;
        bool MPrime = false;
        private void Q19_Load(object sender, EventArgs e)
        {
            //Compute hash of M
            MPrime = false;
            MD4();
            lblA.Text = "A = " + aa.ToString();
            lblB.Text = "B = " + bb.ToString();
            lblC.Text = "C = " + cc.ToString();
            lblD.Text = "D = " + dd.ToString();
            byte[] outBytesM = new[] { aa, bb, cc, dd }.SelectMany(BitConverter.GetBytes).ToArray();
            lblHashM.Text = "Hash value = " + BitConverter.ToString(outBytesM).Replace("-", "").ToLower();
            
            
            //Compute hash of M'
            MPrime = true;
            MD4();
            lblAPrime.Text = "A = " + aa.ToString();
            lblBPrime.Text = "B = " + bb.ToString();
            lblCPrime.Text = "C = " + cc.ToString();
            lblDPrime.Text = "D = " + dd.ToString();
            byte[] outBytesMP = new[] { aa, bb, cc, dd }.SelectMany(BitConverter.GetBytes).ToArray();
            lblHashMPrime.Text = "Hash value = " + BitConverter.ToString(outBytesMP).Replace("-", "").ToLower();

            //Interpreting M
            string MText ="";
            byte[] MBytes = new[] { X0, X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12, X13, X14, X15 }.SelectMany(BitConverter.GetBytes).ToArray();
            foreach (var item in MBytes)
            {
                MText += Convert.ToChar(item);
            }
            lblInterpretM.Text = MText;
            
            //Interpreting M
            MText = "";
            MBytes = new[] { X0, X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, _X12, X13, X14, X15 }.SelectMany(BitConverter.GetBytes).ToArray();
            foreach (var item in MBytes)
            {
                MText += Convert.ToChar(item);
            }
            lblInterpretMPrime.Text = MText;
        }
        void MD4()
        {
            var permutedValues = new List<uint>();
            uint[] Q = new uint[48];
            for (int i = 0; i < 47; i++)
                permutedValues.Add(Permutation(i));
            Q[0] = Shift(0, (a + F(b, c, d) + Permutation(0)));
            Q[1] = Shift(1, (d + F(Q[0], b, c) + Permutation(1)));
            Q[2] = Shift(2, (c + F(Q[1], Q[0], b) + Permutation(2)));
            Q[3] = Shift(3, (b + F(Q[2], Q[1], Q[0]) + Permutation(3)));
            //round0
            for (int i = 4; i <= 15; i++)
            {
                Q[i] = Shift(i, (Q[i - 4] + F(Q[i - 1], Q[i - 2], Q[i - 3]) + Permutation(i)));
            }
            //round1
            for (int i = 16; i <= 31; i++)
            {
                Q[i] = Shift(i, (Q[i - 4] + G(Q[i - 1], Q[i - 2], Q[i - 3]) + Permutation(i) + 0x5a827999));
            }
            //round2
            for (int i = 32; i <= 47; i++)
            {
                Q[i] = Shift(i, (Q[i - 4] + H(Q[i - 1], Q[i - 2], Q[i - 3]) + Permutation(i) + 0x6ed9eba1));
            }
            aa = a + Q[44];
            bb = b + Q[47];
            cc = c + Q[46];
            dd = d + Q[45];
        }
        uint F(uint x, uint y, uint z)
        {
            return (x & y) | (~x & z);
        }
        uint G(uint x, uint y, uint z)
        {
            return (x & y) | (x & z) | (y & z);
        }
        uint H(uint x, uint y, uint z)
        {
            return x ^ y ^ z;
        }
        uint Permutation(int step)
        {
            uint retval = 0;
            if (new[] { 0, 16, 32 }.Contains(step))
                retval = X0;
            else if (new[] {1,20,40 }.Contains(step))
                retval = X1;
            else if(new[] {2,24,36 }.Contains(step))
                retval = X2;
            else if (new[] {3,28,44 }.Contains(step))
                retval = X3;
            else if (new[] {4,17,34 }.Contains(step))
                retval = X4;
            else if (new[] {5,21,42 }.Contains(step))
                retval = X5;
            else if (new[] {6,25,38 }.Contains(step))
                retval = X6;
            else if (new[] {7,29,46 }.Contains(step))
                retval = X7;
            else if (new[] {8,18,33 }.Contains(step))
                retval = X8;
            else if (new[] {9,22,41 }.Contains(step))
                retval = X9;
            else if (new[] {10,26,37 }.Contains(step))
                retval = X10;
            else if (new[] {11,30,45 }.Contains(step))
                retval = X11;
            else if (new[] { 12, 19, 35 }.Contains(step) && MPrime ==false)
                retval = _X12;
            else if (new[] { 12, 19, 35 }.Contains(step) && MPrime==true)
                retval = _X12;
            else if (new[] {13,23,43 }.Contains(step))
                retval = X13;
            else if (new[] {14,27,39 }.Contains(step))
                retval = X14;
            else if (new[] {15,31,47 }.Contains(step))
                retval = X15;
            return retval;
        }
        uint Shift(int step, uint q)
        {
            if (new[] { 0, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 44 }.Contains(step))
                q = q << 3;
            else if (new[] { 1, 5, 9, 13 }.Contains(step))
                q = q << 7;
            else if (new[] { 2, 6, 10, 14, 34, 38, 42, 46 }.Contains(step))
                q = q << 11;
            else if (new[] { 3, 7, 11, 15 }.Contains(step))
                q = q << 19;
            else if (new[] { 17, 21, 25, 29 }.Contains(step))
                q = q << 5;
            else if (new[] { 18, 22, 26, 30 , 33,37, 41,45 }.Contains(step))
                q = q << 9;
            else if (new[] { 19, 23, 27, 31 }.Contains(step))
                q = q << 13;
            else if (new[] { 35, 39, 47 }.Contains(step))
                q = q << 15;
            return q;
        }
    }
}
