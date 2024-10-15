using System;
using System.Collections.Generic;
using System.Linq;

namespace KutuphaneYonetimSistemi
{
    class Program
    {
        static void Main(string[] args)
        {
            Kutuphane kutuphane = new Kutuphane();
            while (true)
            {
                Console.WriteLine("--- Kütüphane Yönetim Sistemi ---");
                Console.WriteLine("1. Kitap Ekle");
                Console.WriteLine("2. Kitapları Listele");
                Console.WriteLine("3. Kitap Ara");
                Console.WriteLine("4. Kitap Sil");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminizi yapın: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.Write("Kitap Adı: ");
                        string kitapAdi = Console.ReadLine();
                        Console.Write("Yazar Adı: ");
                        string yazarAdi = Console.ReadLine();
                        Console.Write("ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Yayın Yılı: ");
                        int yayinYili = int.Parse(Console.ReadLine());

                        kutuphane.KitapEkle(new Kitap(kitapAdi, yazarAdi, isbn, yayinYili));
                        Console.WriteLine("Kitap başarıyla eklendi!\n");
                        break;

                    case "2":
                        kutuphane.KitaplariListele();
                        break;

                    case "3":
                        Console.Write("Aramak istediğiniz kitap adı: ");
                        string arananKitapAdi = Console.ReadLine();
                        kutuphane.KitapAra(arananKitapAdi);
                        break;

                    case "4":
                        Console.Write("Silmek istediğiniz kitabın ISBN'ini girin: ");
                        string silinecekIsbn = Console.ReadLine();
                        kutuphane.KitapSil(silinecekIsbn);
                        break;

                    case "5":
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;

                    default:
                        Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.\n");
                        break;
                }
            }
        }
    }

    class Kitap
    {
        public string KitapAdi { get; set; }
        public string YazarAdi { get; set; }
        public string ISBN { get; set; }
        public int YayinYili { get; set; }

        public Kitap(string kitapAdi, string yazarAdi, string isbn, int yayinYili)
        {
            KitapAdi = kitapAdi;
            YazarAdi = yazarAdi;
            ISBN = isbn;
            YayinYili = yayinYili;
        }

        public override string ToString()
        {
            return $"Kitap Adı: {KitapAdi}, Yazar: {YazarAdi}, ISBN: {ISBN}, Yayın Yılı: {YayinYili}";
        }
    }

    class Kutuphane
    {
        private List<Kitap> kitaplar = new List<Kitap>();

        public void KitapEkle(Kitap kitap)
        {
            kitaplar.Add(kitap);
        }

        public void KitaplariListele()
        {
            if (kitaplar.Count == 0)
            {
                Console.WriteLine("Kütüphanede kitap yok.\n");
            }
            else
            {
                Console.WriteLine("Kütüphanedeki Kitaplar:");
                foreach (var kitap in kitaplar)
                {
                    Console.WriteLine(kitap.ToString());
                }
                Console.WriteLine();
            }
        }

        public void KitapAra(string kitapAdi)
        {
            var bulunanKitaplar = kitaplar.Where(k => k.KitapAdi.ToLower().Contains(kitapAdi.ToLower())).ToList();

            if (bulunanKitaplar.Count > 0)
            {
                Console.WriteLine("Bulunan Kitaplar:");
                foreach (var kitap in bulunanKitaplar)
                {
                    Console.WriteLine(kitap.ToString());
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun kitap bulunamadı.\n");
            }
        }

        public void KitapSil(string isbn)
        {
            var kitap = kitaplar.FirstOrDefault(k => k.ISBN == isbn);

            if (kitap != null)
            {
                kitaplar.Remove(kitap);
                Console.WriteLine("Kitap başarıyla silindi.\n");
            }
            else
            {
                Console.WriteLine("ISBN numarası ile eşleşen kitap bulunamadı.\n");
            }
        }
    }
}
