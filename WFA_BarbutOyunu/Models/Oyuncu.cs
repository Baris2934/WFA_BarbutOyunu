using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_BarbutOyunu.Models
{
    class Oyuncu
    {
        Random rnd;

        public int Bakiye { get; set; }
        public int Moral { get; set; }
        
        public int BahisYap(out bool basarili)
        {
            if(Bakiye >= 100)
            {
                Bakiye -= 100;
                basarili = true;
                return 100;
            }
            else
            {
                MessageBox.Show("Bakiye Yetersiz");
                basarili = false;
                return 0;
            }
        }

        public int BakiyeGoster()
        {
            return Bakiye;
        }

        public int ZarAt()
        {
            rnd = new Random();
            if (Moral == 0) return rnd.Next(1, 5);
            return rnd.Next(1, 7);
        }

        public void MoralBoz()
        {
            Moral--;
        }

        public void MoralDuzelt()
        {
            Moral = 3;
        }
    }
}
