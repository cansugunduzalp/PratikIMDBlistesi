using System;
using System.Collections.Generic;

public class Film
{
    public string Isim { get; set; }
    public double ImdbPuani { get; set; }

    public Film(string isim, double imdbPuani)
    {
        Isim = isim;
        ImdbPuani = imdbPuani;
    }
}

class Program
{
    static void Main()
    {
        List<Film> filmler = new List<Film>();
        bool devamEt = true;

        // Filmler eklenene kadar döngü çalışacak
        while (devamEt)
        {
            Console.Write("Film İsmini Girin: ");
            string isim = Console.ReadLine();

            Console.Write("IMDb Puanını Girin: ");
            double imdbPuani;
            while (!double.TryParse(Console.ReadLine(), out imdbPuani) || imdbPuani < 0 || imdbPuani > 10)
            {
                Console.Write("Geçersiz bir IMDb puanı. Lütfen 0 ile 10 arasında bir değer girin: ");
            }

            // Film nesnesi oluşturulup listeye ekleniyor
            Film yeniFilm = new Film(isim, imdbPuani);
            filmler.Add(yeniFilm);

            // Kullanıcıya yeni film eklemek isteyip istemediği soruluyor
            Console.Write("Başka bir film eklemek ister misiniz? (Evet/Hayır): ");
            string cevap = Console.ReadLine().ToLower();
            if (cevap == "hayır" || cevap == "h")
            {
                devamEt = false;
            }
        }

        // Bütün Filmleri Listele
        Console.WriteLine("\n1. Bütün Filmler:");
        foreach (var film in filmler)
        {
            Console.WriteLine($"{film.Isim} - IMDb Puanı: {film.ImdbPuani}");
        }

        // IMDb Puanı 4 ile 9 Arasında Olan Filmleri Listele
        Console.WriteLine("\n2. IMDb Puanı 4 ile 9 arasında olan Filmler:");
        foreach (var film in filmler)
        {
            if (film.ImdbPuani >= 4 && film.ImdbPuani <= 9)
            {
                Console.WriteLine($"{film.Isim} - IMDb Puanı: {film.ImdbPuani}");
            }
        }

        // İsmi 'A' ile Başlayan Filmleri Listele
        Console.WriteLine("\n3. İsmi 'A' ile Başlayan Filmler:");
        foreach (var film in filmler)
        {
            if (film.Isim.StartsWith("A", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"{film.Isim} - IMDb Puanı: {film.ImdbPuani}");
            }
        }
    }
}
