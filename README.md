# 💣 C# Mayın Tarlası Oyunu (Minesweeper)

![Language](https://img.shields.io/badge/Language-C%23-239120) ![Framework](https://img.shields.io/badge/Framework-Windows%20Forms%20(.NET)-purple) ![IDE](https://img.shields.io/badge/IDE-Visual%20Studio-blue)

[cite_start]Bu proje, **Kocaeli Üniversitesi Yazılım Mühendisliği** bölümü kapsamında geliştirilen, klasik strateji ve bulmaca oyunu Mayın Tarlası'nın C# ve Windows Forms teknolojileri ile uyarlanmış halidir[cite: 1]. Oyuncuların gizli mayınlara basmadan tüm güvenli hücreleri açmasını ve en yüksek skoru elde etmesini hedefler.

## 🎮 Oynanış ve Özellikler

[cite_start]Proje, klasik oyunun kurallarına sadık kalınarak dinamik bir yapıda geliştirilmiştir[cite: 1, 2].

* [cite_start]**Rastgele Mayın Yerleşimi:** Her yeni oyunda mayınlar rastgele koordinatlara atanır[cite: 5].
* **Bayrak Ekleme (Flagging):** Oyuncular mayın olduğunu düşündükleri karelere sağ tıklayarak bayrak koyabilir. [cite_start]`UpdateFlagCount()` fonksiyonu ile bayrakların doğru yerleşimi kontrol edilir[cite: 5].
* [cite_start]**Süre ve Hamle Takibi:** Oyun süresi ve yapılan hamle sayısı arayüzde anlık olarak gösterilir[cite: 5].
* [cite_start]**Skor Tablosu:** Oyuncuların başarıları `AddScore()` fonksiyonu ile hesaplanarak "En İyi 10" listesine eklenir[cite: 5].

## 🏗️ Teknik Mimari ve Sınıf Yapısı

Proje **Nesneye Yönelik Programlama (OOP)** prensipleri kullanılarak modüler bir yapıda tasarlanmıştır.

### Sınıflar (Classes)
* **`Oyun.cs`**: Oyunun ana mantığını yöneten sınıftır. [cite_start]Mayınların atanması, butonların işlevleri, süre kontrolü ve oyun kazanma/kaybetme durumları (örneğin tüm mayınlara bayrak konulması) burada işlenir[cite: 5].
* **`Skorboard.cs`**: Oyuncu bilgilerini ve skor işlemlerini yönetir. [cite_start]Puan hesaplama ve listeleme işlemleri bu sınıfta yapılır[cite: 5].

### Formlar (Forms)
* **`Form1` (Ana Ekran)**: Oyunun oynandığı ana arayüzdür. [cite_start]Sol tarafta mayın tarlası ızgarası, sağ tarafta ise bilgi etiketleri (Süre, Hamle, Oyuncu Adı) ve "Yeniden Başlat (Restart)" butonu bulunur[cite: 5].
* [cite_start]**`SkorboardForm`**: Veritabanı veya dosya sisteminden çekilen "En İyi 10 Oyuncu" listesini gösteren penceredir[cite: 5].

## 📸 Ekran Görüntüleri

| Oyun Ekranı | Skor Tablosu |
| :---: | :---: |
| ![Gameplay](https://via.placeholder.com/300x200?text=Oyun+Ekrani) | ![Scoreboard](https://via.placeholder.com/300x200?text=Skor+Tablosu) |


## ⚙️ Kurulum ve Çalıştırma

1.  Projeyi klonlayın:
    ```bash
    git clone [https://github.com/kullaniciadi/mayin-tarlasi-csharp.git](https://github.com/kullaniciadi/mayin-tarlasi-csharp.git)
    ```
2.  `Minesweeper.sln` dosyasını **Visual Studio** ile açın.
3.  Projeyi derleyin (`Ctrl + Shift + B`) ve çalıştırın (`F5`).

## 📚 Kaynakça

[cite_start]Proje geliştirme sürecinde aşağıdaki kaynaklardan yararlanılmıştır[cite: 6]:
1.  Khan Academy - Mayın Tarlası Algoritmaları
2.  GeeksforGeeks - C# Minesweeper Implementation
3.  Tutorials Point - C# Game Development

## 👨‍💻 Geliştirici

**Furkan Öztürk**
* **Bölüm:** Yazılım Mühendisliği
* **Okul:** Kocaeli Üniversitesi
* **İletişim:** [furknozturk06@gmail.com](mailto:furknozturk06@gmail.com)
