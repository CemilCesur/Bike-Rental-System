using System;
using System.Collections.Generic;
using System.Text;

namespace Proje3
{
    class TreeNode
    {
        public Durak data;
        public TreeNode leftChild;
        public TreeNode rightChild;
        public List<Müşteri> müşteriler;

        public void displayNode()
        {
            Console.WriteLine("------------------------------  " +
                              "\nDurak Adı: "+data.getDurakAdı() +
                              "\nBP: " + data.getBP() +
                              "\nTB: " + data.getTB() +
                              "\nNB: " + data.getNB() );
            Console.ReadLine();
            int sayac = 1;
            if (müşteriler != null)
            {
                foreach (Müşteri m in müşteriler)
                {
                    Console.WriteLine(sayac + ".Müşteri;\n" +
                    "ID: " + m.getID() +
                    "\nSaat: " + m.getSaat() + ":" + m.getDakika()); Console.ReadLine(); sayac++;
                }
            }

            else { Console.WriteLine("Bu durakta kayıtlı müşteri bulunmamaktadır!"); Console.ReadLine(); }
            
        }

        public void displayNode2(int ID)
        {
            if (müşteriler != null)
            {
                foreach (Müşteri m in müşteriler)
                {
                    if(m.getID() == ID) { Console.WriteLine("Durak: " + data.getDurakAdı() + "\nSaat: " + m.getSaat() + ":" + m.getDakika()); } 
                }
            }
        }

        public void editNode(int ID, String durakAdı)
        {
            if (data.durakAdı == durakAdı)
            {
                Random rastgele = new Random();

                int saat = rastgele.Next(0, 24);
                int dakika = rastgele.Next(10, 60);

                Müşteri yeniMüşteri = new Müşteri(ID, saat, dakika);

                müşteriler.Add(yeniMüşteri);

                int BP = data.getBP();
                int NB = data.getNB();
                data.setBP(BP + 1);
                data.setNB(NB - 1);
            }


        }


    }
}
