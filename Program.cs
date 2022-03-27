using System;
using System.Collections;
using System.Collections.Generic;

namespace Proje3
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] duraklar = { "İnciraltı,28,2,10" , "Sahilevleri,8,1,11" , "Doğal Yaşam Parkı,17,1,6" , "Bostanlı İskele,7,0,5" , 
                "Bayraklı İskele,8,7,12" , "Fuar Basmane,6,10,11" , "Bornova Metro,6,6,10" , "Pasaport İskele,11,7,13" , "Hasanaga Parkı,11,9,13 "};

            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Durak[] duraklarDizisi = DurakNesnesiOluştur(duraklar);

            Tree agac = agacOluştur(duraklarDizisi, duraklar);

            Console.WriteLine("\n  ***********\n  *PROJE III*\n  ***********\n");
            
            agacDerinligiveBilgiler(agac, duraklar);

            müşteriAra(agac);

            müşteriEkle(agac);

            hashTableOluştur(duraklar);

            hashTableGüncelle(duraklar , hashTableOluştur(duraklar));

            int[] intDizi = { 2, 5 ,8, 13 ,9, 7 };
            Heap heap = heapOluştur(intDizi);
            
            DurakHeap durakheap = durakHeapOluştur(duraklarDizisi);

            durakHeapÜçAdetÇek(durakheap);

            Console.WriteLine("\n\n --> BUBBLE SORT ve SHELL SORT <--\n____________________________________\n");
            Console.ReadLine();
            Console.WriteLine("Bubble Sort Oluşturma Metodu\n----------------------------");
            bubbleSortOluştur();
            Console.WriteLine("\nShell Sort Oluşturma Metodu\n---------------------------");
            shellSortOluştur();


        }



        public static Durak[] DurakNesnesiOluştur(String[] duraklar) // durak nesnelerini oluşturan ve diziye aktaran method
        {
            String[] veriler;
            Durak[] duraklarDizisi = new Durak[9];

            for (int i=0; i<duraklar.Length; i++)
            {
                veriler = duraklar[i].Split(',');

                String durakAdı = veriler[0];
                int BP = Int32.Parse(veriler[1]);
                int TB = Int32.Parse(veriler[2]);
                int NB = Int32.Parse(veriler[3]);

                Durak durak = new Durak(durakAdı, BP, TB, NB);

                duraklarDizisi[i] = durak;
            }

            return duraklarDizisi;


        } 


        public static Tree agacOluştur(Durak[] duraklarDizisi, String[] duraklar)
        {
            Random r = new Random();

            Tree agac = new Tree();



            int sayacID = 1; // Müşteri ID'lerini sırayla vermek için
            int sayac = 0; // Müşteri sayısını kontrol edebilmek için
            bool müşteriKaldımı = true; //Random dönen sayıyı karşılayacak kadar müşteri varsa true olarak kalıyor
            bool devam = true; //Random dönen sayıyı karşılayacak kadar müşteri yoksa son kez işlem yapılması amacıyla kontrolü sağlıyor
            for (int i = 0; i < duraklar.Length; i++) //Tree for'u
            {
                Durak durak = duraklarDizisi[i];

                int müşteriSayısı = r.Next(1, 11);
                if (müşteriSayısı + sayac < 21) { sayac += müşteriSayısı; } // Random dönen sayıyı karşılayacak kadar müşteri varsa buraya giriyor
                else { müşteriSayısı = (müşteriSayısı + sayac) - 20; müşteriKaldımı = false; } // Random dönen sayıdan daha az müşteri kaldıysa buraya giriyor

                if (müşteriKaldımı) // Eğer elimizde bol müşteri varsa buraya giriyor
                {
                    List<Müşteri> müşteriList = new List<Müşteri>(müşteriSayısı);
                    for (int j = sayac; j < müşteriSayısı + sayac; j++)
                    {
                        int ID = sayacID;
                        int saat = r.Next(0, 24);
                        int dakika = r.Next(10, 60);

                        Müşteri müşteri = new Müşteri(ID, saat, dakika);
                        müşteriList.Add(müşteri);

                        sayacID++;
                    }

                    if (müşteriSayısı > 4 && durak.TB > 1) { durak.TB = durak.TB - 2; müşteriSayısı = müşteriSayısı - 4; durak.BP = durak.BP + 2; } // TB ve yeterli müşteri varsa önce TB bitiyor
                    else if (müşteriSayısı > 2 && durak.TB > 0) { durak.TB = durak.TB - 1; müşteriSayısı = müşteriSayısı - 2; durak.BP = durak.BP + 1; }

                    durak.BP = durak.BP + müşteriSayısı;
                    durak.NB = durak.NB - müşteriSayısı;

                    agac.insert(durak, müşteriList);
                }

                else if (devam && müşteriSayısı > 0) // Artık son müşterilere geldiysek buraya giriyor
                {
                    List<Müşteri> müşteriList = new List<Müşteri>(müşteriSayısı);
                    for (int f = 0; f < müşteriSayısı; f++)
                    {
                        int ID = sayacID;
                        int saat = r.Next(0, 24);
                        int dakika = r.Next(10, 60);
                        Müşteri müşteri = new Müşteri(ID, saat, dakika);
                        müşteriList.Add(müşteri);

                        sayacID++;
                    }
                    if (müşteriSayısı > 4 && durak.TB > 1) { durak.TB = durak.TB - 2; müşteriSayısı = müşteriSayısı - 4; durak.BP = durak.BP + 2; } // TB ve yeterli müşteri varsa önce TB bitiyor
                    else if (müşteriSayısı > 2 && durak.TB > 0) { durak.TB = durak.TB - 1; müşteriSayısı = müşteriSayısı - 2; durak.BP = durak.BP + 1; }

                    durak.BP = durak.BP + müşteriSayısı;
                    durak.NB = durak.NB - müşteriSayısı;

                    agac.insert(durak, müşteriList);
                    devam = false;
                }

                else // Elimizde hiç müşteri yoksa buraya giriyor
                {
                    agac.insert(durak, null);
                }

            }


            return agac;
        }

        
        public static void agacDerinligiveBilgiler(Tree agac, String[] duraklar)
        {
            int n = duraklar.Length;
            int d = (int)Math.Log2(n + 1) - 1;



            Console.WriteLine("Ağaç derinliği: " + d);
            Console.ReadLine();

            agac.preOrder(agac.getRoot());



        }


        public static void müşteriAra(Tree agac)
        {
            Console.WriteLine("_______________________________________________________________________");

            Console.WriteLine("\n\n ***MÜŞTERİ ARAMA*** \n\n-> Aramak istediğiniz ID numarası için 'Enter'.\n");
            Console.ReadLine();
            int ID;
            Console.Write("ID :");
            ID = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n\n-SONUÇLAR-\n");

            agac.preOrderMüşteriBulmak(agac.getRoot(), ID);
        }


        public static void müşteriEkle(Tree agac)
        {
            Console.WriteLine("_______________________________________________________________________");

            Console.WriteLine("\n\n ***MÜŞTERİ EKLEME*** \n\n-> Eklemek istediğiniz ID numarası ve İstasyon için 'Enter'.\n");
            Console.ReadLine();
            int ID2;
            String istasyon;
            Console.Write("ID :");
            ID2 = Convert.ToInt16(Console.ReadLine());
            Console.Write("İstasyon :");
            istasyon = Console.ReadLine();

            agac.preOrderMüşteriEklemek(agac.getRoot(), ID2, istasyon);

            Console.WriteLine("\n\n->İşleminiz gerçekleşti...<-\n");
        }


        public static Hashtable hashTableOluştur(String[] duraklar)
        {
            Hashtable hashTAble = new Hashtable();


            for (int y = 0; y<duraklar.Length; y++)
            {

                String[] durakDIZI = duraklar[y].Split(',');

                int[] BPTBNB = new int[3];
                BPTBNB[0] = Int32.Parse(durakDIZI[1]);
                BPTBNB[1] = Int32.Parse(durakDIZI[2]);
                BPTBNB[2] = Int32.Parse(durakDIZI[3]);

                hashTAble.Add(durakDIZI[0], BPTBNB);

            }

            return hashTAble;


        } 


        public static Hashtable hashTableGüncelle(String[] duraklar, Hashtable hashTAble)
        {
            hashTAble = new Hashtable();

            for (int y = 0; y < duraklar.Length; y++)
            {

                String[] durakDIZI = duraklar[y].Split(',');

                int BP = Int32.Parse(durakDIZI[1]);
                int TB = Int32.Parse(durakDIZI[2]);
                int NB = Int32.Parse(durakDIZI[3]);

                if (BP > 5) { BP = BP - 5; NB = NB + 5; }


                int[] BPTBNB = new int[3];
                BPTBNB[0] = BP;
                BPTBNB[1] = TB;
                BPTBNB[2] = NB;

                hashTAble.Add(durakDIZI[0], BPTBNB);

            }

            return hashTAble;
        }

        public static Heap heapOluştur(int[] intDizi)
        {
            Heap heap = new Heap(6);
            for (int i = 0; i<intDizi.Length; i++)
            {
                heap.insert(intDizi[i]);
            }

            return heap;
        }

        public static DurakHeap durakHeapOluştur ( Durak[] durakNesneleri )
        {
            DurakHeap heap = new DurakHeap(durakNesneleri.Length);
            for (int i = 0; i < durakNesneleri.Length; i++)
            {
                heap.insert(durakNesneleri[i]);
            }

            return heap;
        }

        public static void durakHeapÜçAdetÇek ( DurakHeap durakHeap)
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                       Max Heap'ten Çekilen 3 Durak                       ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ReadLine();

            DurakNode root1 = durakHeap.remove();
            Console.WriteLine("1.Çekilen İstasyon;\nDurak Adı: " + root1.getKey().durakAdı + "\nBP: " + root1.getKey().BP + "\nTB: " + root1.getKey().TB + "\nNB: " + root1.getKey().NB);
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ReadLine();

            DurakNode root2 = durakHeap.remove();
            Console.WriteLine("2.Çekilen İstasyon;\nDurak Adı: " + root2.getKey().durakAdı + "\nBP: " + root2.getKey().BP + "\nTB: " + root2.getKey().TB + "\nNB: " + root2.getKey().NB);
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ReadLine();

            DurakNode root3 = durakHeap.remove();
            Console.WriteLine("3.Çekilen İstasyon;\nDurak Adı: " + root3.getKey().durakAdı + "\nBP: " + root3.getKey().BP + "\nTB: " + root3.getKey().TB + "\nNB: " + root3.getKey().NB);
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ReadLine();
        }
    
        public static void bubbleSortOluştur()
        {
            int geciciDeger;
            Console.Write("Sayı miktarı giriniz: ");
            int miktar = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[miktar];
            for (int i = 0; i < miktar; i++)
            {
                Console.Write("Dizinin " + (i + 1) + ". elemanını girin : ");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i <= array.Length - 1; i++) // Sıralıyoruz
            {
                for (int j = 1; j <= array.Length - 1; j++)
                {
                    if (array[j - 1] > array[j])
                    {
                        geciciDeger = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = geciciDeger;
                    }
                }
            }

        }

        public static void shellSortOluştur()
        {
            int i, j;
            int pozisyon;
            int geciciDeger;
            pozisyon = 3;

            Console.Write("Sayı miktarı giriniz: ");
            int miktar = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[miktar];
            for (int g = 0; g < miktar; g++)
            {
                Console.Write("Dizinin " + (g + 1) + ". elemanını girin : ");
                array[g] = Convert.ToInt32(Console.ReadLine());
            }

            while (pozisyon > 0) // Sıralıyoruz
            {
                for (i = 0; i < miktar; i++)
                {
                    j = i;
                    geciciDeger = array[i];
                    while ((j >= pozisyon) && (array[j - pozisyon] > geciciDeger))
                    {
                        array[j] = array[j - pozisyon];
                        j = j - pozisyon;
                    }
                    array[j] = geciciDeger;
                }
                if (pozisyon / 2 != 0)
                    pozisyon = pozisyon / 2;
                else if (pozisyon == 1)
                    pozisyon = 0;
                else
                    pozisyon = 1;
            }
        }
    }
}
