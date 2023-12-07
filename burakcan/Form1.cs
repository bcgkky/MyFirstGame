using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace burakcan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string s = "";

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Right)
            {
                timer1.Start();
                s = "right";
            }
            if (e.KeyCode == Keys.Left)
            {
                timer1.Start();
                s = "left";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (s == "right")
            {
                pictureBox8.Left += 5;

                if (pictureBox8.Left >= panel1.Width - 40)
                {
                    pictureBox8.Left = pictureBox8.Width + 40;
                }
            }
            if (s == "left")
            {
                pictureBox8.Left -= 5;

                if (pictureBox8.Left - 40 <= -pictureBox8.Width)
                {
                    pictureBox8.Left = pictureBox8.Width - 38;
                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            timer1.Stop();
        }
        int hiz = 1;
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer3.Start();
            timer4.Start();
           

            pictureBox9.Top += hiz;
            pictureBox10.Top += hiz;
            pictureBox11.Top += hiz;

            Random r = new Random();
            PictureBox[] pbDizi = { pictureBox9, pictureBox10, pictureBox11 };
            for (int i = 0; i < pbDizi.Length; i++)
            {
                if (pbDizi[i].Top >= panel1.Height)
                {
                    puan++;
                    pbDizi[i].Top = -pbDizi[i].Height;
                    pbDizi[i].Left = r.Next(4, 71);
                    if (pbDizi[i].Left >= 4 && pbDizi[i].Left < 34)
                    {
                        pbDizi[i].Left = 4;
                    }
                    if (pbDizi[i].Left >= 34 && pbDizi[i].Left <= 71)
                    {
                        pbDizi[i].Left = 71;
                    }
                }
            }
            for (int i = 0; i < pbDizi.Length; i++)
            {
                if (pictureBox8.Top <= pbDizi[i].Bottom && pictureBox8.Left <= pbDizi[i].Right &&
                pictureBox8.Right >= pbDizi[i].Left)
                {
                    timer2.Stop();
                    timer1.Stop();
                    timer3.Stop();
                    timer4.Stop();
                    button2.Enabled = true;
                    button2.Visible = true;
                    oyunsonu();
                }
            }
        }
        void yenioyun()
        {
            hiz = 1;
            puan = 0;
            pictureBox8.Left = 70;
            pictureBox11.Left = 4; pictureBox11.Top = 431;
            pictureBox10.Left = 71; pictureBox10.Top = 215;
            pictureBox9.Left = 4; pictureBox9.Top = 5;
            button1.Enabled = true;
            lbSkor.Text = "0";
            saniye = 0;
        }

        int puan = 0, saniye = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            saniye++;
            if (saniye == 11)
            {
                hiz += 1;
                saniye = 0;
            }
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            lbSkor.Text = puan.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yenioyun();
            button2.Enabled = false;
            button2.Visible = false;
        }
        void oyunsonu()
        {
            MessageBox.Show("Kaybettiniz.\nYaptığınız Skor : " + puan, "Oyun Sonu");
        } 

        
    }
}
