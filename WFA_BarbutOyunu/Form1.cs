using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA_BarbutOyunu.Models;

namespace WFA_BarbutOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Oyuncu birinciOyuncu, ikinciOyuncu;
        Mafya mafya;

        private void btnBahis1_Click(object sender, EventArgs e)
        {
            lblHavuz.Text = birinciOyuncu.BahisYap(out bool basarili).ToString();
            if (!basarili) return;
            ButonVeBahisKontrolEt(true);
        }

        private void ButonVeBahisKontrolEt(bool birinciMi)
        {
            if(birinciMi)
            {
                lblBakiye1.Text = birinciOyuncu.Bakiye.ToString();
                btnBahis1.Enabled = false;
                btnBahis2.Enabled = true;
            }
            else
            {
                lblBakiye2.Text = ikinciOyuncu.Bakiye.ToString();
                btnBahis2.Enabled = false;
            }
            
        }

        private void btnBahis2_Click(object sender, EventArgs e)
        {
            lblHavuz.Text = (Convert.ToInt32(lblHavuz.Text) + (ikinciOyuncu.BahisYap(out bool basarili))).ToString();
            if (!basarili) return;
            ButonVeBahisKontrolEt(false);
            btnZarAt1.Enabled = true;
        }

        private void btnZarAt1_Click(object sender, EventArgs e)
        {
            lblZar1Sonuc.Text = birinciOyuncu.ZarAt().ToString();
            btnZarAt1.Enabled = false;
            btnZarAt2.Enabled = true;
        }

        private void btnZarAt2_Click(object sender, EventArgs e)
        {
            lblZar2Sonuc.Text = ikinciOyuncu.ZarAt().ToString();
            btnZarAt2.Enabled = false;

            int lbl1 = Convert.ToInt32(lblZar1Sonuc.Text);
            int lbl2 = Convert.ToInt32(lblZar2Sonuc.Text);

            if (mafya.ParayaElKoy())
            {
                lblHavuz.Text = "";
                btnBahis1.Enabled = true;
                return;
            }

            OyuncuZaferKontrol(lbl1, lbl2);

        }

        private void OyuncuZaferKontrol(int lbl1, int lbl2)
        {
            

            if (lbl1 > lbl2)
            {
                MessageBox.Show("Birinci Oyuncu Kazandı");
                ikinciOyuncu.MoralBoz();
                birinciOyuncu.MoralDuzelt();
                lblMoral1.Text = birinciOyuncu.Moral.ToString();
                lblMoral2.Text = ikinciOyuncu.Moral.ToString();
                birinciOyuncu.Bakiye += Convert.ToInt32(lblHavuz.Text);
                lblBakiye1.Text = birinciOyuncu.Bakiye.ToString();
                lblHavuz.Text = "";
                btnBahis1.Enabled = true;
            }
            else if (lbl2 > lbl1)
            {
                MessageBox.Show("İkinci Oyuncu Kazandı");
                birinciOyuncu.MoralBoz();
                ikinciOyuncu.MoralDuzelt();
                lblMoral2.Text = ikinciOyuncu.Moral.ToString();
                lblMoral1.Text = birinciOyuncu.Moral.ToString();
                ikinciOyuncu.Bakiye += Convert.ToInt32(lblHavuz.Text);
                lblBakiye2.Text = ikinciOyuncu.Bakiye.ToString();
                lblHavuz.Text = "";
                btnBahis1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Berabere.. Tekrar Zar Atın..");
                btnZarAt1.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mafya = new Mafya();

            birinciOyuncu = new Oyuncu();
            birinciOyuncu.Moral = 3;
            birinciOyuncu.Bakiye = 500;

            ikinciOyuncu = new Oyuncu();
            ikinciOyuncu.Moral = 3;
            ikinciOyuncu.Bakiye = 500;

            lblBakiye1.Text = birinciOyuncu.Bakiye.ToString();
            lblBakiye2.Text = ikinciOyuncu.Bakiye.ToString();
        }
    }
}
