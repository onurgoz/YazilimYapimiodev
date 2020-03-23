using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODEV
{
    class Program
    {
        static void Main(string[] args)
        {
            int puan = 0;
            Console.WriteLine("press the key to start the game");
            Console.ReadKey();
            puan = Basla();
            Console.ReadKey();
        }
        static int Basla()
        {
            int[] RandomSayilar = new int[7];
            int[] TempRandomSayilar = new int[6];
            int[] TempRandomSayilarCopy = new int[6];
            int[] Tut = new int[2];
            int[] Sonuc = new int[2];
            int i, puan = 0;
            Random Rand = new Random();
            for (i = 0; i < 5; i++)
            {
                RandomSayilar[i] = Rand.Next(1, 9);
            }
            RandomSayilar[5] = Rand.Next(1, 9) % 10 * 10;
            RandomSayilar[6] = Rand.Next(100, 999);
            for (i = 0; i < 6; i++)
            {
                TempRandomSayilarCopy[i] = RandomSayilar[i];
            }
            TempRandomSayilar = TempRandomSayilarCopy;
            for (i = 0; i < 7; i++)
            {
                Console.WriteLine(Convert.ToString(RandomSayilar[i]));
            }
            Tut[0] = RandomSayilar[6] / TempRandomSayilarCopy[5];
            Tut[1] = RandomSayilar[6] % TempRandomSayilarCopy[5];
            Sonuc = IslemYap(TempRandomSayilar, Tut);
            Console.WriteLine("\n naber" + Tut[0] + "\n" + Sonuc[0]);
            Console.WriteLine("\n naber" + Tut[1] + "\n" + Sonuc[1]);
            Console.WriteLine(Sonuc[0] + "*" + TempRandomSayilarCopy[5] + "=" + (Sonuc[0] * TempRandomSayilarCopy[5]));
            Console.WriteLine(Sonuc[1] + "+" + (Sonuc[0] * TempRandomSayilarCopy[5]) + "=" + ((Sonuc[0] * TempRandomSayilarCopy[5]) + Sonuc[1]));
            return puan;
        }
        static int[] IslemYap(int[] Sayilar, int[] Gerekli)
        {
            int[] TempRandomSayilar = new int[4];
            int[,] tut = new int[2, 5];// bunu kullanmanın bir yolunu bul....
            int[] Yansıt = new int[2];
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = i; j < 3; j++)
                    {
                        if (Gerekli[k] == (Sayilar[i] + Sayilar[j + 1]))//Bu kısımda kullandığım sayıların işime yarayığ yaramadığına bakıyorum ve ayırıyorum
                        {
                            Yansıt[k] = Sayilar[i] + Sayilar[j + 1];
                            tut[k, i] = Sayilar[i] + Sayilar[j + 1];// kullandığım sayılar tekrar işime yarayabilir :)
                            Console.WriteLine(Sayilar[i] + "+" + Sayilar[j + 1] + "=" + tut[k, i]);
                            int x = 0, y = 0;// x ve y yi kullanmadan çözebileceğim bir yol bulamadım ve bunları kullanarak hangi if bloğunun içine girdiğimi programa gösterip ona göre hareket etmesini sağladım
                            for (int l = 0; l < 3; l++)//bu kısımdaysa işime yarayan bu sayıları diziden ayıklayıp yeni bir diziye atıyorum
                            {
                                if (x > 4)//burda x in 4 den yukarı çıktığı durumlar bulunduğu için bunu engelledim
                                {
                                    x = 4;
                                }
                                else if (l == i && ((l + 1) == (j + 1)))//eğer atama yapıcağım index kulandığım sayının index'ine ait ise ve sonra ki sayıyı da zaten kullanmışsam 2 atlar ve dolayısıyla döngü 2 atlayıp devam etmeli
                                {
                                    TempRandomSayilar[l] = Sayilar[l + 2];
                                    x = x + 2;
                                    y++;
                                }
                                else if (l + 1 == j + 1)//yukardaki işlenle aynı gibi gözüksede öyle değil burda yaptığım sonraki sayıyı kullanıp kullanmadığımı kontrol etmek
                                {
                                    TempRandomSayilar[l] = Sayilar[l + 2];
                                    x = x + 2;
                                    y++;
                                }
                                else if ((l == i || l == j + 1) && y != 1)//şu anki alıcağım sayıyı kullanmışmıyım
                                {
                                    TempRandomSayilar[l] = Sayilar[l + 1];
                                    x++;
                                }
                                else// defaull olarak atama yap ve x'e bağlı kal
                                {
                                    TempRandomSayilar[l] = Sayilar[x];
                                }
                                x++;// x'i l gibi arttırmaya devam et ve döngüyü bozma
                            }
                            TempRandomSayilar[3] = Yansıt[k];// her zaman 3. indexe çıkan sonucu at :)
                            for (int m = 0; m < 4; m++)
                            {
                                Console.WriteLine(TempRandomSayilar[m]);
                            }
                            Console.ReadKey();
                            for (int o = 0; o < 4; o++)
                            {
                                if (Gerekli[k] == (Sayilar[i] + Sayilar[j + 1]))//Bu kısımda kullandığım sayıların işime yarayığ yaramadığına bakıyorum ve ayırıyorum
                                {
                                    Yansıt[k] = TempRandomSayilar[i] + TempRandomSayilar[j + 1];
                                    tut[k, i] = TempRandomSayilar[i] + TempRandomSayilar[j + 1];// kullandığım sayılar tekrar işime yarayabilir :)
                                    Console.WriteLine(Sayilar[i] + "+" + Sayilar[j + 1] + "=" + tut[k, i]);
                                    x = 0;
                                    y = 0;// x ve y yi kullanmadan çözebileceğim bir yol bulamadım ve bunları kullanarak hangi if bloğunun içine girdiğimi programa gösterip ona göre hareket etmesini sağladım
                                    for (int l = 0; l < 3; l++)//bu kısımdaysa işime yarayan bu sayıları diziden ayıklayıp yeni bir diziye atıyorum
                                    {
                                        if (x > 4)//burda x in 4 den yukarı çıktığı durumlar bulunduğu için bunu engelledim
                                        {
                                            x = 4;
                                        }
                                        else if (l == i && ((l + 1) == (j + 1)))//eğer atama yapıcağım index kulandığım sayının index'ine ait ise ve sonra ki sayıyı da zaten kullanmışsam 2 atlar ve dolayısıyla döngü 2 atlayıp devam etmeli
                                        {
                                            TempRandomSayilar[l] = Sayilar[l + 2];
                                            x = x + 2;
                                            y++;
                                        }
                                        else if (l + 1 == j + 1)//yukardaki işlenle aynı gibi gözüksede öyle değil burda yaptığım sonraki sayıyı kullanıp kullanmadığımı kontrol etmek
                                        {
                                            TempRandomSayilar[l] = Sayilar[l + 2];
                                            x = x + 2;
                                            y++;
                                        }
                                        else if ((l == i || l == j + 1) && y != 1)//şu anki alıcağım sayıyı kullanmışmıyım
                                        {
                                            TempRandomSayilar[l] = Sayilar[l + 1];
                                            x++;
                                        }
                                        else// defaull olarak atama yap ve x'e bağlı kal
                                        {
                                            TempRandomSayilar[l] = Sayilar[x];
                                        }
                                        x++;// x'i l gibi arttırmaya devam et ve döngüyü bozma
                                    }
                                    TempRandomSayilar[3] = Yansıt[k];// her zaman 3. indexe çıkan sonucu at :)
                                    for (int m = 0; m < 4; m++)
                                    {
                                        Console.WriteLine(TempRandomSayilar[m]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return Yansıt;
        }
    }
}