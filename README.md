# Form Çizimi Konsol Uygulaması

Bu proje, C# konsol ortamında geliştirilmiş form tabanlı bir cari, stok ve fiş işlemleri uygulamasıdır. 

Uygulama üzerinden cari kayıtları oluşturulabilir, stok kartları eklenebilir, kayıtlar listelenebilir, güncellenebilir ve fiş işlemleri yapılabilir. Veriler dosya tabanlı olarak `.txt` dosyalarında saklanmaktadır.

---

## Projenin Genel Amacı

Bu uygulamanın amacı, konsol ekranında form mantığını kullanarak temel cari ve stok işlemlerini gerçekleştirmektir. Kullanıcı; ana menüden cari işlemlerine, stok işlemlerine veya fiş işlemlerine geçebilir. Her ekran kendi içinde metin kutuları, etiketler ve butonlardan oluşur.

Projede form geçişleri, aktif kutu yönetimi, klavye ile gezinme ve dosya tabanlı kayıt sistemi kullanılmıştır.

---

## Veri Dosyaları

| Dosya | Görevi |
|---|---|
| `cariler.txt` | Cari kayıtlarının tutulduğu dosyadır. |
| `stoklar.txt` | Stok kartı kayıtlarının tutulduğu dosyadır. |
| `fisler.txt` | Stok fişi kayıtlarının tutulduğu dosyadır. |
| `carifisler.txt` | Cari fiş kayıtlarının tutulduğu dosyadır. |

---


# Sınıf Açıklamaları

## Program.cs

`Program` sınıfı, konsol uygulamasının ana sınıfıdır. Uygulama ilk açıldığında bu sınıftaki `Main` metodu çalışır.

Bu sınıfta bulunan `AktifForm` değişkeni, konsolda o anda açık olan formu tutar. Örneğin `AktifForm = new AnaMenuForm()` ise ekranda ana menü formu vardır.

`FormGecmisi`, kullanıcının gezdiği formları tutar. Bu yapı `Stack` mantığı ile çalışır. Stack yapısında son eklenen form ilk çıkar. Bu sayede kullanıcı `Shift + Tab` ile bir önceki forma dönebilir.

### Önemli Metotlar

| Metot | Açıklama |
|---|---|
| `Main()` | Uygulamayı başlatır ve ilk form olarak `AnaMenuForm` ekranını açar. |
| `FormDegistir()` | Aktif formu değiştirir. Önceki formu geçmişe ekler ve yeni formu ekranda gösterir. |
| `OncekiFormaDon()` | Form geçmişinden son formu alarak kullanıcıyı bir önceki ekrana döndürür. |

---

## Form.cs

`Form` sınıfı, projedeki tüm ekranların temel sınıfıdır. Bu sınıfın amacı; kutuları ekranda göstermek, aktif kutuyu yönetmek, kullanıcının bastığı tuşları işlemek ve form içinde dolaşmayı sağlamaktır.

`List<Kutu>` yapısı ile form üzerindeki tüm kutular `Kutular` listesinde tutulur. Bu kutular metin kutusu, buton kutusu veya etiket kutusu olabilir.

`AktifKutu` özelliği, o anda aktif olan kutuyu döndürür. `aktifKutuIndex` değişkeni ise aktif kutunun listedeki sırasını tutar.

### Önemli Metotlar

| Metot | Açıklama |
|---|---|
| `Form()` | Form nesnesi oluşturulduğunda kutu listesini hazırlar. |
| `Goster()` | Form üzerindeki tüm kutuları çizer ve ilk aktif kutuyu aktif hale getirir. |
| `TusIsle()` | Klavyeden basılan tuşa göre işlem yapar. `Tab` ve `Enter` ile kutular arasında geçiş yapılır. `Shift + Tab` ile önceki forma dönülür. |

---

## Kutu.cs

`Kutu` sınıfı, projedeki bütün görsel kutuların temel sınıfıdır. `MetinKutusu`, `EtiketKutusu` ve `ButonKutusu` sınıfları bu sınıftan türetilir.

Bu sınıf kutunun boyutunu, konumunu, çizim şeklini ve aktiflik durumunu yönetir. `Size` kutunun genişliğini ve yüksekliğini, `Point` ise kutunun console ekranında nereden başlayacağını belirtir.

### Önemli Özellikler

| Özellik | Açıklama |
|---|---|
| `Boyut` | Kutunun genişlik ve yükseklik bilgisini tutar. |
| `Konum` | Kutunun console ekranındaki başlangıç konumunu tutar. |
| `AktifOlabilir` | Kutunun seçilebilir olup olmadığını belirtir. |
| `AktifMi` | Kutunun o anda aktif olup olmadığını belirtir. |

### Önemli Metotlar

| Metot | Açıklama |
|---|---|
| `Ciz()` | Kutuyu console ekranına çizer. |
| `Isle()` | Tuş işlemleri için ortak bir metot tanımlar. Alt sınıflar bu metodu kendilerine göre kullanır. |
| `AktifEt()` | Kutuyu aktif hale getirir. |
| `PasifEt()` | Kutuyu pasif hale getirir. |

---

## MetinKutusu.cs

`MetinKutusu` sınıfı, kullanıcıdan yazı veya sayı girişi almak için kullanılır. Bu sınıf `Kutu` sınıfından türetilmiştir.

Kullanıcı bir metin kutusuna geldiğinde kutu aktif olur, imleç görünür hale gelir ve imleç kutunun içindeki yazının sonuna getirilir. Kullanıcı klavyeden yazı yazdığında, basılan tuş bilgisi `Isle()` metoduna gelir ve değer kutunun içine işlenir.

Bu sınıf; ad soyad, telefon, firma adı, stok kodu, stok adı, fiyat, adet gibi bilgilerin kullanıcıdan alınmasını sağlar.

---

## ButonKutusu.cs

`ButonKutusu` sınıfı, console ekranında buton oluşturmak için kullanılır. Bu sınıf da `Kutu` sınıfından türetilmiştir.

Butonun temel görevi, üzerinde yazan işlemi kullanıcı `Space` tuşuna bastığında çalıştırmaktır. Örneğin kullanıcı `Kaydet` butonuna gelip `Space` tuşuna basarsa, bu butona bağlı olan kaydetme metodu çalışır.

### Önemli Yapılar

| Yapı | Açıklama |
|---|---|
| `IslemYap` | Butona basıldığında çalışacak işlemi tutar. |
| `Deger` | Butonun üzerinde yazan metni tutar. |
| `AktifEt()` | Butonu aktif hale getirir ve kalın çizgilerle çizer. |
| `PasifEt()` | Butonu pasif hale getirir ve ince çizgilerle çizer. |
| `Isle()` | Buton aktifken `Space` tuşuna basılırsa bağlı işlemi çalıştırır. |

---

## EtiketKutusu.cs

`EtiketKutusu` sınıfı, ekranda sadece bilgi göstermek için kullanılır. Kullanıcı bu kutu üzerinde işlem yapamaz.

Bu sınıf da `Kutu` sınıfından türediği için konum ve boyut özelliklerini `Kutu` sınıfından alır. `AktifOlabilir = false` olduğu için kullanıcı `Tab` veya `Enter` ile gezerken bu kutulara gelmez.

Etiketler genellikle metin kutularının ne işe yaradığını göstermek için kullanılır. Örneğin `Ad Soyad`, `Telefon`, `Stok Kodu`, `Fiş Tarihi` gibi başlıklar etiket kutusu ile gösterilir.

---

## AnaMenuForm.cs

`AnaMenuForm` sınıfı, uygulamanın ana menü ekranını oluşturur. Bu sınıf `Form` sınıfından türetildiği için form sisteminin özelliklerini kullanır.

Ana menüde kullanıcıya üç temel seçenek sunulur:

- Cari İşlemleri
- Stok İşlemleri
- Fiş İşlemleri

### Önemli Metotlar

| Metot | Açıklama |
|---|---|
| `CariIslemleriAc()` | Kullanıcıyı cari işlemleri ekranına yönlendirir. |
| `StokIslemleriAc()` | Kullanıcıyı stok işlemleri ekranına yönlendirir. |
| `FisIslemleriAc()` | Kullanıcıyı fiş işlemleri ekranına yönlendirir. |

Bu ekranın temel amacı, kullanıcıyı yapmak istediği işleme göre doğru forma yönlendirmektir.

---

## CariForm.cs

`CariForm` sınıfı, uygulamada cari kayıt işlemlerinin yapıldığı ana formdur. Kullanıcı bu ekranda cari bilgilerini girerek yeni cari kaydı oluşturabilir.

Bu formda etiket kutuları, metin kutuları ve butonlar oluşturulur. Kullanıcıdan alınan bilgiler `cariler.txt` dosyasına kaydedilir.

### Önemli Metotlar

| Metot | Açıklama |
|---|---|
| `KaydeteBasildi()` | Kullanıcının girdiği cari bilgilerini `cariler.txt` dosyasına kaydeder. |
| `ListeleyeBasildi()` | Cari listeleme ekranına geçiş yapar. |
| `CariGuncelleyeBasildi()` | Cari güncelleme ekranına geçiş yapar. |
| `VazgeceBasildi()` | Formdaki bütün metin kutularını temizler. |

`File.AppendAllText` kullanıldığı için dosya yoksa oluşturulur, dosya varsa mevcut kayıtlar silinmeden yeni kayıt dosyanın sonuna eklenir.

---

## CariListele.cs

`CariListele` sınıfı, kayıtlı carileri listelemek için kullanılan formdur. Bu sınıf `cariler.txt` dosyasındaki kayıtları okur ve console ekranında listeler.

`oncekiForm` değişkeni, listeleme ekranına hangi formdan gelindiğini tutar. Böylece kullanıcı `ESC` tuşuna bastığında önceki forma dönebilir.

### Önemli Metotlar

| Metot | Açıklama |
|---|---|
| `KayitlariOku()` | `cariler.txt` dosyasındaki kayıtları okur ve listeye aktarır. |
| `KayitlariGoster()` | Okunan kayıtları console ekranında gösterir. |
| `TemizleIcerikAlani()` | Listeleme alanını temizler. |
| `GeriDon()` | Kullanıcıyı önceki forma döndürür. |

---

## CariGuncelleme.cs

`CariGuncelleme` sınıfı, `cariler.txt` dosyasındaki kayıtlı cari bilgilerini güncellemek için kullanılır.

Bu sınıf önce kayıtlı carileri okuyup kullanıcıya bir seçim ekranı sunar. Kullanıcı güncellemek istediği cari kaydının numarasını girer. Seçilen carinin bilgileri düzenleme ekranındaki metin kutularına getirilir. Kullanıcı gerekli değişiklikleri yaptıktan sonra `Güncelle` butonuna basarak kaydı günceller.

Bu sınıfta iki ekran mantığı vardır:

| Mod | Açıklama |
|---|---|
| Seçim modu | Kullanıcı hangi cari kaydı güncellemek istediğini seçer. |
| Düzenleme modu | Kullanıcı seçtiği cari kaydının bilgilerini değiştirir. |

### Önemli Metotlar

| Metot | Açıklama |
|---|---|
| `SecimEkraniniHazirla()` | Kullanıcının kayıt seçebileceği ekranı hazırlar. |
| `DuzenlemeEkraniniHazirla()` | Seçilen kaydın düzenleneceği ekranı hazırlar. |
| `Guncelle()` | Seçili cari kaydı yeni girilen bilgilere göre günceller. |
| `DosyayaTumKayitlariYaz()` | Tüm cari kayıtlarını güncel haliyle tekrar dosyaya yazar. |

---

## StokForm.cs

`StokForm` sınıfı, uygulamada stok kartı kayıt işlemlerinin yapıldığı formdur. Ana menüden stok işlemleri seçildiğinde bu ekran açılır.

Kullanıcı stok bilgilerini ilgili metin kutularına girer ve `Kaydet` butonuna bastığında bilgiler `stoklar.txt` dosyasına kaydedilir.

### Önemli Metotlar

| Metot | Açıklama |
|---|---|
| `KaydeteBasildi()` | Stok bilgilerini `stoklar.txt` dosyasına kaydeder. |
| `ListeleyeBasildi()` | Stok listeleme ekranına geçiş yapar. |
| `StokGuncelleyeBasildi()` | Stok güncelleme ekranına geçiş yapar. |
| `VazgeceBasildi()` | Giriş alanlarını temizler. |

---

## StokListele.cs

`StokListele` sınıfı, `stoklar.txt` dosyasındaki kayıtlı stok bilgilerini listelemek için kullanılır.

### Önemli Metotlar

| Metot | Açıklama |
|---|---|
| `Goster()` | Stok listeleme ekranı gösterildiğinde çalışır. |
| `KayitlariOku()` | `stoklar.txt` dosyasındaki stok kayıtlarını okur. |
| `KayitlariGoster()` | Okunan stok kayıtlarını console ekranında gösterir. |

Bu sınıf kayıt eklemez veya güncellemez. Sadece mevcut stok kayıtlarını kullanıcıya gösterir.

---

## StokGuncelleme.cs

`StokGuncelleme` sınıfı, `stoklar.txt` dosyasına kaydedilmiş stok bilgilerinin güncellenmesi için kullanılır.

İlk olarak `stoklar.txt` dosyasındaki kayıtlar okunur ve `kayitlar` listesine aktarılır. Sonra kullanıcıya bir seçim ekranı gösterilir. Kullanıcı düzenlemek istediği stok kaydının numarasını girer. Seçilen kayıt düzenleme ekranındaki alanlara yüklenir.

### Önemli Metotlar

| Metot | Açıklama |
|---|---|
| `SecimEkraniniHazirla()` | Kullanıcının stok kaydı seçebileceği ekranı hazırlar. |
| `DuzenlemeEkraniniHazirla()` | Seçilen stok kaydının düzenleneceği ekranı hazırlar. |
| `KayitSec()` | Kullanıcının girdiği kayıt numarasına göre stok kaydını seçer. |
| `SecilenKaydiKutularaYukle()` | Seçilen stok kaydını metin kutularına yükler. |
| `Guncelle()` | Seçilen stok kaydını günceller. |
| `DosyayaTumKayitlariYaz()` | Stok kayıtlarını güncel haliyle tekrar `stoklar.txt` dosyasına yazar. |

---

## FisIslemleriForm.cs

`FisIslemleriForm` sınıfı, fiş işlemleri için bir seçim ekranı oluşturur.

Bu ekranda kullanıcıya şu seçenekler sunulur:

- Cari Fiş İşlemleri
- Stok Fiş İşlemleri
- Ana Menüye Dönüş

### Önemli Metotlar

| Metot | Açıklama |
|---|---|
| `CariFisIslemleriAc()` | Kullanıcıyı cari fiş ekranına yönlendirir. |
| `StokFisIslemleriAc()` | Kullanıcıyı stok fiş ekranına yönlendirir. |
| `AnaMenuyeDon()` | Kullanıcıyı ana menü ekranına döndürür. |

---

## StokFis.cs

`StokFis` sınıfı, stok fişi oluşturmak için kullanılır. Bu sınıfta oluşturulan fişlerde girilen stok adetleri, stok kartındaki mevcut adetten düşülür.

Bu sınıf `Form` sınıfından türediği için `Kutular`, `Goster`, `TusIsle` ve aktif kutu belirleme özelliklerini kullanır.

### Temel Görevleri

- Fiş numarası, fiş tarihi ve açıklama alanlarını oluşturmak
- Stok satırı eklemek
- Stok koduna göre stok adını otomatik getirmek
- Stok adı alanının kullanıcı tarafından değiştirilmesini engellemek
- Stok adedini kullanıcıdan almak
- Fişi `fisler.txt` dosyasına kaydetmek
- Girilen adet kadar stok miktarını düşürmek

### Önemli Metotlar

| Metot | Açıklama |
|---|---|
| `StokFis()` | Stok fiş ekranı açıldığında çalışır ve form elemanlarını oluşturur. |
| `TusIsle()` | Kullanıcı klavyeden tuşa bastığında çalışır. |
| `StokAdiAlaniniAtla()` | Kullanıcının stok adı alanına müdahale etmesini engeller. |
| `IlkSatiriEkle()` | Fiş ekranına ilk stok satırını ekler. |
| `YeniSatirEkle()` | Yeni stok satırı ekler. |
| `StokKodlariniKontrolEt()` | Girilen stok kodunu kontrol eder ve stok adını otomatik getirir. |
| `StokBul()` | `stoklar.txt` dosyasında stok kodunu arar. |
| `Kaydet()` | Fişi kaydeder ve stok adetlerini düşürür. |
| `StokAdediniDusur()` | İlgili stok kaydının adedini girilen miktar kadar azaltır. |
| `Vazgec()` | Fiş formunu temizler. |
| `SiradakiFisNumarasiniOlustur()` | Sıradaki fiş numarasını oluşturur. |
| `MesajYaz()` | Kullanıcıya bilgi mesajı verir. |

Stok kodu girildiğinde sistem `stoklar.txt` dosyasında bu kodu arar. Stok varsa stok adı otomatik olarak getirilir. Stok adedi ise otomatik getirilmez; kullanıcı tarafından girilir.

---

## CariFisForm.cs

`CariFisForm` sınıfı, cari fiş işlemlerini yapmak için kullanılır. Kullanıcı cari kodunu girer, sistem `cariler.txt` dosyasından ilgili cariyi bulur ve cari adı, mevcut borç, mevcut alacak bilgilerini ekrana getirir.

Bu formda kullanıcıdan işlem türü ve tutar bilgisi alınır. İşlem türüne göre cari borç veya alacak bilgisi güncellenir.

### İşlem Türleri

| İşlem Türü | Açıklama |
|---|---|
| `A` | Mevcut alacak değerinden düşüm yapar. |
| `B` | Mevcut borç değerinden düşüm yapar. |

### Önemli Metotlar

| Metot | Açıklama |
|---|---|
| `CariFisForm()` | Cari fiş ekranı açıldığında çalışır ve form elemanlarını oluşturur. |
| `TusIsle()` | Kullanıcının klavyeden bastığı tuşları işler. |
| `OtomatikAlanlariAtla()` | Cari adı, mevcut borç ve mevcut alacak alanlarının atlanmasını sağlar. |
| `CariKodunuKontrolEt()` | Girilen cari koduna göre cari bilgilerini getirir. |
| `CariBul()` | Kullanıcının girdiği cari kodunu `cariler.txt` dosyasında arar. |
| `Kaydet()` | Cari fişi kaydeder ve cari borç/alacak bilgisini günceller. |
| `CariDosyasiniGuncelle()` | `cariler.txt` dosyasındaki cari kaydını günceller. |
| `DecimalDegereCevir()` | Girilen tutarı decimal sayıya çevirir. |
| `DecimalYaz()` | Decimal değeri Türkçe formatta yazar. |
| `Vazgec()` | Cari fiş formunu temizler. |
| `GeriDon()` | Fiş işlemleri ekranına döner. |
| `AnaMenuyeDon()` | Ana menüye döner. |
| `MesajYaz()` | Kullanıcıya bilgi mesajı verir. |

Cari adı, mevcut borç ve mevcut alacak alanları otomatik alanlardır. Bu nedenle kullanıcı `Tab` veya `Enter` ile gezerken bu alanlar atlanır ve kullanıcı tarafından değiştirilmesi engellenir.

---
