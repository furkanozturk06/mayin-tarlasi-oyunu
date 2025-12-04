# 💣 C# Mayın Tarlası Oyunu (Minesweeper)

![Language](https://img.shields.io/badge/Language-C%23-239120) ![Framework](https://img.shields.io/badge/Framework-Windows%20Forms%20(.NET)-purple) ![IDE](https://img.shields.io/badge/IDE-Visual%20Studio-blue)

Bu proje, **Kocaeli Üniversitesi Yazılım Mühendisliği** bölümü kapsamında geliştirilen, klasik strateji ve bulmaca oyunu Mayın Tarlası'nın C# ve Windows Forms teknolojileri ile uyarlanmış halidir. Oyuncuların gizli mayınlara basmadan tüm güvenli hücreleri açmasını ve en yüksek skoru elde etmesini hedefler.

## 🎮 Oynanış ve Özellikler

Proje, klasik oyunun kurallarına sadık kalınarak dinamik bir yapıda geliştirilmiştir.

* **Rastgele Mayın Yerleşimi:** Her yeni oyunda mayınlar rastgele koordinatlara atanır.
* **Bayrak Ekleme (Flagging):** Oyuncular mayın olduğunu düşündükleri karelere sağ tıklayarak bayrak koyabilir. `UpdateFlagCount()` fonksiyonu ile bayrakların doğru yerleşimi kontrol edilir.
* **Süre ve Hamle Takibi:** Oyun süresi ve yapılan hamle sayısı arayüzde anlık olarak gösterilir.
* **Skor Tablosu:** Oyuncuların başarıları `AddScore()` fonksiyonu ile hesaplanarak "En İyi 10" listesine eklenir.

## 🏗️ Teknik Mimari ve Sınıf Yapısı

Proje **Nesneye Yönelik Programlama (OOP)** prensipleri kullanılarak modüler bir yapıda tasarlanmıştır.

### Sınıflar (Classes)
* **`Oyun.cs`**: Oyunun ana mantığını yöneten sınıftır. Mayınların atanması, butonların işlevleri, süre kontrolü ve oyun kazanma/kaybetme durumları (örneğin tüm mayınlara bayrak konulması) burada işlenir.
* **`Skorboard.cs`**: Oyuncu bilgilerini ve skor işlemlerini yönetir. Puan hesaplama ve listeleme işlemleri bu sınıfta yapılır.

### Formlar (Forms)
* **`Form1` (Ana Ekran)**: Oyunun oynandığı ana arayüzdür. Sol tarafta mayın tarlası ızgarası, sağ tarafta ise bilgi etiketleri (Süre, Hamle, Oyuncu Adı) ve "Yeniden Başlat (Restart)" butonu bulunur.
* **`SkorboardForm`**: Veritabanı veya dosya sisteminden çekilen "En İyi 10 Oyuncu" listesini gösteren penceredir.

1. **Projeyi klonlayın:**
   ```bash
   git clone [https://github.com/kullaniciadi/mayin-tarlasi-csharp.git](https://github.com/kullaniciadi/mayin-tarlasi-csharp.git)
