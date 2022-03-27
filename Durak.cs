using System;
using System.Collections.Generic;
using System.Text;

namespace Proje3
{
    class Durak
    {
        public String durakAdı;
        public int BP;
        public int TB;
        public int NB;


        public Durak(String durakAdı, int BP, int TB, int NB)
        {
            this.durakAdı = durakAdı;
            this.BP = BP;
            this.TB = TB;
            this.NB = NB;
        }

        public String getDurakAdı()
        {
            return durakAdı;
        }


        public int getBP()
        {
            return BP;
        }
        public void setBP(int BP)
        {
            this.BP = BP;
        }


        public int getTB()
        {
            return TB;
        }
        public void setTB(int TB)
        {
            this.TB = TB;
        }


        public int getNB()
        {
            return NB;
        }
        public void setNB(int NB)
        {
            this.NB = NB;
        }
    }
}
