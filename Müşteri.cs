using System;
using System.Collections.Generic;
using System.Text;

namespace Proje3
{
    class Müşteri
    {
        int ID;
        int saat;
        int dakika;

        public Müşteri (int ID, int saat, int dakika)
        {
            this.ID = ID;
            this.saat = saat;
            this.dakika = dakika;
        }

        public int getID ()
        {
            return ID;
        }

        public int getSaat()
        {
            return saat;
        }

        public int getDakika()
        {
            return dakika;
        }
    }
}
