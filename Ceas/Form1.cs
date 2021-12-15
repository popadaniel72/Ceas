using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ceas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int xc, yc, raza, razaCifre, lmin, lsec, lora, dx=15, h, m, s;
        Pen rosu = new Pen(Color.Red, 1);
        Pen verde = new Pen(Color.Green, 1);
        Pen albastru = new Pen(Color.Blue, 1);
        Pen galben = new Pen(Color.Yellow, 1);
        SolidBrush culoareCifre ;
        private void Form1_Resize(object sender, EventArgs e)
        {
            xc = this.Width / 2;
            yc = this.Height / 2;
            razaCifre = (int)(Math.Min(this.Width, this.Height) * rap / 2);
            raza = razaCifre - dx;
            lsec = raza - dx;
            lmin = lsec - dx;
            lora = lmin - dx;
            dt = DateTime.Now;
            h = dt.Hour;
            m = dt.Minute;
            s = dt.Second;
            this.Invalidate();

        }

        Pen p = new Pen(Color.Red, 1);
        // x,y= punct de aplicare, u-unghi, l-lungime vector, cul-culoare, e- suport desen
        void dVector(int x, int y, int u, int l, Pen cul, PaintEventArgs e)
        {
            int a = 10, vv = 10; //a = unghiul varfului, vv= lungimea varf
            double dx, dy;
            int xv, yv;
            // desen linie principala
            dx = l * Math.Cos(u * Math.PI / 180);
            dy = l * Math.Sin(u * Math.PI / 180);
            xv = x + (int)dx; // xv, yv - coordonatele varfului
            yv = y - (int)dy;
            e.Graphics.DrawLine(cul, x, y, xv, yv);
            // desen varf
            dx = vv * Math.Cos((u + 180 - a) * Math.PI / 180);
            dy = vv * Math.Sin((u + 180 - a) * Math.PI / 180);
            e.Graphics.DrawLine(cul, xv, yv, xv + (int)dx, yv - (int)dy);
            dx = vv * Math.Cos((u + 180 + a) * Math.PI / 180);
            dy = vv * Math.Sin((u + 180 + a) * Math.PI / 180);
            e.Graphics.DrawLine(cul, xv, yv, xv + (int)dx, yv - (int)dy);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // desenez cerc
            e.Graphics.DrawEllipse(p, xc - raza, yc - raza, 2*raza, 2*raza);
            // pun cifrele;
            for(int i = 1; i<=12; i++)
            {
                e.Graphics.DrawString(i.ToString(), fontCifre, culoareCifre, (float)(xc -dx + razaCifre * Math.Cos(( 90 - 30 * i) * Math.PI / 180)), (float)(yc -dx- razaCifre * Math.Sin(( 90 - 30 * i) * Math.PI / 180)), formatCifre);
            }
        }

        double rap = 0.7;
        double umin, uora, usec;
        DateTime dt;
        Font fontCifre;
        StringFormat formatCifre;
        private void Form1_Load(object sender, EventArgs e)
        {   //calcul pozitie cerc
            xc = this.Width / 2;
            yc = this.Height / 2;
            razaCifre = (int)(Math.Min(this.Width, this.Height) * rap / 2);
            raza = razaCifre - dx;
            lsec = raza - dx;
            lmin = lsec - dx;
            lora = lmin - dx;
            dt = DateTime.Now;
            h = dt.Hour;
            m = dt.Minute;
            s = dt.Second;
            // tip cifre
            fontCifre = new Font("Arial", 16);
            formatCifre = new StringFormat();
            culoareCifre = new SolidBrush(Color.Black);


        }
    }
}
