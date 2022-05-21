using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_BarbutOyunu.Models
{
    class Mafya
    {
        Random rnd;
        public bool ParayaElKoy()
        {
            rnd = new Random();
            if(rnd.Next(1,70) <= 10)
            {
                MessageBox.Show("Beyler Paraları Biz (Dünya'nın en büyük mafyası) Alalım");
                return true;
            }
            return false;
        }
    }
}
