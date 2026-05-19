# Long Balls - 3D Hyper-Casual Platformer

Unity ile geliştirilmiş, matematiksel kapı mekaniklerine ve dinamik nesne yönetimine dayalı bir 3D hyper-casual platform oyunudur. Oyuncu, platform üzerinde ilerlerken topladığı değerlere göre arkasındaki top zincirini yönetir ve en yüksek skorla bitiş çizgisine ulaşmayı hedefler.

##  Oyun Mekanikleri ve Özellikleri

* **Matematiksel Kapı Sistemi:** Pist üzerinde yer alan pozitif ve negatif kapılar, oyuncunun mevcut top değerini dinamik olarak etkiler.
  
* **Dinamik Kuyruk (Queue) Yönetimi:** * **Pozitif Değerler:** Geçilen kapı pozitifse, ana topun arkasına matematiksel değere oranla yeni toplar eklenir ve takip sistemi tetiklenir.
  * **Negatif Değerler:** Geçilen kapı negatifse, mevcut top zincirinden fazla olan toplar eksilir.
* **Gelişmiş Takip Algoritması:** Arkaya dizilen topların birbirini pürüzsüz ve estetik bir şekilde takip etmesini sağlayan hareket mekaniği.
* **Level Sonu (Finish) Mantığı:** Bitiş çizgisine ulaşıldığında kalan toplam top sayısına göre kazanılan skor hesaplaması.

##  Teknik Detaylar ve Kullanılan Teknolojiler

* *Oyun Motoru:* Unity
* **Programlama Dili:** C#
* **Öne Çıkan Sistemler:**
  * Nesne yönelimli programlama ile temiz kod yapısı (Scriptable Objects veya modüler script tasarımları).
  * `BallController` ve `CameraController` ile optimize edilmiş hareket ve kamera takip sistemleri.
  * Performans dostu tetiklenme (Trigger) ve çarpışma (Collision) yönetimi.

##  Nasıl Oynanır?

1. Ana top platform üzerinde otomatik veya sürükleme (Swerve) mekaniği ile ileri doğru hareket eder.
2. Karşına çıkan kapıların üzerindeki sayıları analiz et.
3. Top sayını maksimuma çıkarmak için yeşil (pozitif) kapıları hedefle, kırmızı (negatif) kapılardan kaçın.
4. En kalabalık top grubuyla bitiş çizgisine ulaşarak bölümü tamamla!
