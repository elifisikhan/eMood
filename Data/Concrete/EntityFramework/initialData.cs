using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework
{
    public static class initialData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .GetRequiredService<eMoodContext>();

            context.Database.Migrate(); // bekleyen migration varsa çalıştırma
            using (var transaction = context.Database.BeginTransaction())
            {
                if (!context.Activities.Any())
                {
                    var emotions = new[]
                    {
                    new Emotion() {  EmotionName = "Happy" },
                    new Emotion() {  EmotionName = "Sad" },
                    new Emotion() {  EmotionName = "Angry" },
                    new Emotion() {  EmotionName = "Fear" },
                    new Emotion() {  EmotionName = "Neutral" },
                    new Emotion() {  EmotionName = "Surprise" },
                    new Emotion() {  EmotionName = "Disgust" }
                };
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Emotions] ON");
                    context.SaveChanges();
                    context.Emotions.AddRange(emotions);
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Emotions] OFF");



                    var activities = new[]
                    {
                    new Activity(){  ActivityName="Sinema"},
                    new Activity(){ ActivityName="Bisiklet"},
                    new Activity(){  ActivityName="Dizi"},
                    new Activity(){  ActivityName="Müzik"},
                    new Activity(){  ActivityName="Film"},
                    new Activity(){  ActivityName="Belgesel"},
                    new Activity(){ ActivityName="e-Book"},
                    new Activity(){  ActivityName="Oyun",},
                    new Activity(){  ActivityName="Alışveriş"},
                    new Activity(){  ActivityName="Yürüyüş"}
                };
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Activities] ON");
                    context.SaveChanges();
                    context.Activities.AddRange(activities);
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Activities] OFF");

                    transaction.Commit();


                    var activityattributes = new[]
                    {
                    new ActivityAttribute(){  AttributeName ="Amelie", Image="amelie.jpg", Rate=8, Description ="Amélie, Audrey Tautou’nun başrolünde olduğu, Jean-Pierre Jeunet filmi. Fransız yapımı bu romantik komedi, Jeunet ve Guillaume Laurant tarafından yazılmıştır. Montmartre’de geçen film, modern Paris hayatının idealize edilmiş, alaycı bir yorumudur.", Activity=activities[4],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Beni Sen İnandır", Image="pinhani.jpg", Rate=8, Description ="Pinhani - Beni Sen İnandır", Activity=activities[3],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="La Casa De Papel", Image="lcdp.jpg", Rate=8, Description ="La casa de papel, İspanya yapımı bir soygun ve suç dizisi. Álex Pina tarafından yaratılan televizyon dizisinin iki kısma ayrılan bir tek sezondan ibaret olması planlanmıştı. 15 bölümden oluşan dizi ilk olarak 2 Mayıs 2017 - 23 Kasım 2017 tarihlerinde İspanyol televizyon kanalı Antena 3'te yayımlandı. ", Activity=activities[2],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Kordon Bisiklet Sürme Alanı", Image="bike.jpg", Rate=8, Description ="  ", Activity=activities[1],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="17 Burda Cinemaximum", Image="cinema.jpg", Rate=8, Description =" ", Activity=activities[0],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Cosmos: Bir Uzay Serüveni", Image="cosmos.jpg", Rate=8, Description ="Cosmos: A Spacetime Odyssey; Carl Sagan, Ann Druyan ve Steven Soter tarafından yazılan, Cosmos: A Personal Voyage'ın devamı niteliğinde bir belgesel dizidir. Bu belgesel bilimadamlarının çalışmalarını sinematik bir şekilde anlatmakta, kozmostan ve evrenden örnekler vererek uzay-zamanı açıklamaktadır.", Activity=activities[5],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Fareler ve İnsanlar", Image="fvi.jpg", Rate=8, Description ="Fareler ve İnsanlar, Nobel Edebiyat Ödülü sahibi yazar John Steinbeck tarafından yazılmış bir roman. İlk defa 1937 yılında yayınlanan eser, iki gezgin çiftlik işçisi olan George Milton ve Lennie Small'un büyük bunalım sırasında Kaliforniya'da yaşadıkları trajik olayları anlatır. ", Activity=activities[6],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="The Elder Scrolls V: Skyrim ", Image="skyrim.jpg", Rate=8, Description ="The Elder Scrolls V: Skyrim, Bethesda Game Studios tarafından geliştirilip Bethesda Softworks tarafından piyasaya sürülen serbest dünya tipi aksiyon RPG video oyunudur. The Elder Scrolls serisinin The Elder Scrolls IV: Oblivion'dan sonra gelen toplamda beşinci uyarlamasıdır.", Activity=activities[7],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Aşıklar Tepesi", Image="walk2.jpg", Rate=8, Description ="yürüyüş festivali", Activity=activities[9],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="İmparatorun Yolculuğu", Image="impt.jpg", Rate=8, Description ="March of Penguins, Luc Jacquet tarafından yönetilen ve ortaklaşa yazılan ve Bonne Pioche ve National Geographic Society tarafından ortak olarak hazırlanan 2005 uzun metrajlı bir Fransız doğa belgeseli. Belgesel, Antarktika imparator penguenlerinin yıllık yolculuğunu tasvir ediyor.", Activity=activities[5],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Burma VJ: Kapalı Bir Ülkeden Raporlama ", Image="burma.jpg", Rate=8, Description ="Burma VJ: Kapalı Bir Ülkeden Raporlama, Anders Østergaard tarafından yönetilen 2008 Danimarkalı bir belgesel filmidir. Burma'daki askeri rejime karşı Safran Devrimi'ni takip ediyor. Başlıktaki VJ, video gazetecileri anlamına gelir. Bazıları elde taşınan kameralarda çekildi.", Activity=activities[5],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Mutluluk Faktörü ", Image="mutluluk.jpg", Rate=8, Description ="Mutluluk çevremizdeki şartların mükemmelliği, şans, sağlık, para, aşk gibi kavramlara mı bağlı yoksa bizim seçimlerimizle mi alakalı? Kariyer koçu Selin Yetimoğlu, kahkaha yogası, meditasyon, “Agni Sar”dan “Sufi”ye farklı nefes teknikleri, farkındalık, duygusal dayanıklılık ve esneklik, pozitif psikoloji gibi ana temaları aktarırken, okuru için hazırladığı oyun ve alıştırmalarla yeni bir yaşam şekline dair pozitif bir bakış açısı getirmeyi hedefliyor. ", Activity=activities[5],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Samsara", Image="samsara.jpg", Rate=8, Description ="Samsara, Ron Fricke'in yönetmenliğini ve Mark Magidson'ın yapımcılığını üstlendiği 2011 yapımı anlatımsız ve yorumsuz belgesel film. 1992 yapımı Baraka filmine benzer bir mantıkla aynı yönetmen tarafından çekilmiştir. ", Activity=activities[6],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Bir Gölge Gibi Silineceksin ", Image="golge.jpg", Rate=8, Description ="Selim İleri'den “Bir Gölge Gibi Silineceksin” Selim İleri'nin geçmiş zaman okumalarındaki daha önce paylaşmadığı notlarını, yazılarını gün yüzüne çıkardığı kitabı Bir Gölge Gibi Silineceksin, Everest Yayınları tarafından yayımlandı. İleri, hem kendi belleğine hem de edebiyata bir meydan okuma denemesine girişiyor. ", Activity=activities[6],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Zihin Avcısı", Image="mind.jpg", Rate=8, Description ="Zihin Avcısı Mindhunter Geliştirdiği stratejiler ile FBI içinde adeta efsane olan Özel Ajan John Douglas, en tehlikeli seri katillerin zihinlerini didik didik edip, işledikleri suçların ardındaki gerçek nedenleri anlamak için dünyada bir ilk olan ‘psikolojik profil çıkarma’ yöntemini kullandı. Bu yöntem suç biliminde yeni ve büyük ufuklar açtı.", Activity=activities[6],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Someone Like You", Image="adele.jpg", Rate=8, Description ="Adele – Someone Like You ", Activity=activities[3],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Please Don’t Go", Image="barcelona.jpg", Rate=8, Description ="Barcelona – Please Don’t Go ", Activity=activities[3],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Strawberry Swing", Image="coldplay.jpg", Rate=8, Description ="Coldplay – Strawberry Swing ", Activity=activities[3],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Silicon Valley", Image="valley.jpg", Rate=8, Description ="1980′lerin sonunda Silikon Vadisi’nde çalışan bir bilgisayar programcısının yaşadıklarını konu edinecek dizinin merkezinde; içine kapalı, asosyal bilgisayar programcısı Richard ve onun beş arkadaşının öyküsü yer alacak. Kara mizah türünde olacak yapımda, teknoloji dünyasındaki insanların başarıya ulaşabilmek için geçtiği yolları bir bir göreceğiz! ", Activity=activities[2],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="This is us", Image="us.jpg", Rate=8, Description ="This Is Us, 20 Eylül 2016'dan beri NBC'de yayınlanan bir ABD aile drama televizyon dizisi. ", Activity=activities[2],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Leyla ile Mecnun", Image="leyla.jpg", Rate=8, Description ="Leyla ile Mecnun, Eflatun Film tarafından yapılıp TRT 1'de 3 sezon yayımlanan ve final yapamadan yayından kaldırılan absürt komedi türündeki Türk televizyon dizisi. ", Activity=activities[2],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Tiffany’de Kahvaltı / Breakfast at Tiffany's (1961)", Image="tiff.jpg", Rate=8, Description ="New York Sosyetesinin renkli simalarından Holly, yan dairesine taşınan genç bir adama ilgi duymaya başlar. Holly aslında canı istediği ehr erkeği kendisine aşık edebilen bir kadındır. Gönlünce geçirdiği gecelerin sabahında mücevher dükkanı Tiffany vitrini önünde kahvaltısını yapar. Bu hep böyle yaşanır. Yalnız bir sabah işte bu genç adam Paul Varjak ortaya çıkar ve bu kez bir duygusallık oturuverir Holly’nin gündemine. Bu zamanla platonik bir aşka dönüşür.", Activity=activities[4],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Ekim Düşü / October Sky (1999)", Image="ekim.jpg", Rate=8, Description ="Coalwood adlı kasabada yaşayan Homer Hickam adlı gencin ilerde baba mesleği olan madenciliği yapmaktan başka seçeneği yok gibidir. Fakat 1957 Ekim'inde Sputnik adlı uydunun uzaya fırlatılmasıyla Homer roketlere ve bunların nasıl yapıldığına büyük ilgi duyar. Üç arkadaşı ile deneme yanılma yoluyla bazı denemeler yapmaya karar verir.Kasabada başta babası olmak üzere herkes bunun bir saçmalık olduğunu düşünmektedir. Sadece bir lise öğretmeni onların çabalarını ve emeklerine saygı gösterir ve Ulusal Bilim Yarışmasında büyük ödülü alabileceklerine onları inandırır.", Activity=activities[4],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Tom Clancy's Rainbow Six: Siege", Image="tomclancy.jpg", Rate=8, Description ="Rainbow Six: Siege veya Rainbow 6: Siege Ubisoft Montreal tarafından geliştirilen ve Ubisoft tarafından yayımlanan Birinci şahıs nişancı türünde bir video oyunu. Oyun IGN tarafından E3 2014'ün en iyi oyunu seçilmiştir.", Activity=activities[7],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="PUBG", Image="pubg.jpg", Rate=8, Description ="Playerunknown's Battlegrounds", Activity=activities[7],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Counter-Strike", Image="cs.jpg", Rate=8, Description ="Counter-Strike: Global Offensive(2018)", Activity=activities[7],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Hygge-Danimarkalıların Mutluluk Sırrı", Image="hygge.jpg", Rate=8, Description ="Danimarka’nın, dünyanın en mutlu insanlarının yaşadığı ülke olduğu kabul edilir. Onlara göre bu mutluluğun sırrı tek bir sözcükte saklıdır: hygge.", Activity=activities[6],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Ustalık Gerektiren Kafaya Takmama Sanatı", Image="takma.jpg", Rate=8, Description ="Danimarka’nın, dünyanın en mutlu insanlarının yaşadığı ülke olduğu kabul edilir. Onlara göre bu mutluluğun sırrı tek bir sözcükte saklıdır: hygge.", Activity=activities[6],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Bir Dolara Yaşamak", Image="dolar.jpg", Rate=8, Description ="'Bir Dolara Yaşamak' belgeseli ile devam ediyoruz. Öyle gidip görüp çekmekle olmuyor deyip gerçekten deneyimlemişler. Şükretmek için iyi bir yapım.", Activity=activities[5],Emotion=emotions[1], InInside=true},

                    new ActivityAttribute(){  AttributeName ="Dünyanın En Sıradışı Evleri", Image="siradisi.jpg", Rate=8, Description ="Bir de sadelikten nasibini almamış ya da tüm standartların dışına çıkmış, dünyanın birçok yerindeki çok farklı evler için bir belgeselimiz var: 'Dünyanın En Sıradışı Evleri'.", Activity=activities[5],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Minimalizm: Önemli Şeylere Dair Bir Belgesel", Image="minii.jpg", Rate=8, Description ="Tüketim bizi mutlu ediyor mu, yoksa sadelik çok daha huzur verici mi? 'Minimalizm: Önemli Şeylere Dair Bir Belgesel' sadece bilgilendirici değil, hemen hayatınızı değiştirmeniz için de oldukça yüreklendirici.", Activity=activities[5],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="The Big Bang Theory", Image="bigbang.jpg", Rate=8, Description ="En büyük zevkleri kuantum fiziğine kafa yormak olan üstün zekalı iki arkadaş, güzel bir kızla karşılaşınca ne yaparlar? The Big Bang Theory, işte o karşılaşma anında gerçekleşen büyük patlama ve sonrasını anlatan bir komedi dizisi.", Activity=activities[2],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="How I Met Your Mother", Image="himym.jpg", Rate=8, Description ="Dizi Ted Mosby'nin eşi ile nasıl tanıştığını çocuklarına anlatmasını konu alır. Dizi 2030 yılında başlar. Bob Saget 'in seslendirmesiyle asıl karakteri Ted size annenizle nasıl tanıştığımı anlatacağım der ve dizi 2005 yılına döner.", Activity=activities[2],Emotion=emotions[1], InInside=true},

                    new ActivityAttribute(){  AttributeName ="Friends", Image="friends.jpg", Rate=8, Description ="Manhattan'da yaşayan bir grup arkadaşın hayatı üzerinde dönen komedi dizisi", Activity=activities[2],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="I Will Survive", Image="gloria-gaynor.jpg", Rate=8, Description ="I Will Survive - Gloria Gaynor", Activity=activities[3],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Livin' On A Prayer ", Image="jovi.jpg", Rate=8, Description ="Livin' On A Prayer - Bon Jovi", Activity=activities[3],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Eye of the Tiger", Image="eye.jpg", Rate=8, Description ="Eye of the Tiger - Survivor", Activity=activities[3],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Neşeli Günler (1965)", Image="soundofmusic.jpg", Rate=8, Description ="Maria öylesine hayat dolu ve coşkulu bir genç kadındır ki manastır hayatı aslında hiç de onun ruhuna hitap etmemektedir. En sevdiği şey dağlara çıkıp şarkı söylemektir. Bu yüzden de genelde birçok dersi kaçırır. Bu duruma bir çare arayan Baş Rahibe Peggy, sorumluluk alması için Maria'yı bakıcı olarak karısını yeni kaybetmiş, 7 çocuklu Kaptan Von Trapp'ın yanına gönderir. Kaptan Trapp'ın çocuklarının haylazlığı yüzünden bütün bakıcılar bir süre sonra işi bırakmaktadırlar. Maria ise iyimserliği ve sevecenliğiyle hem kaptanın güvenini hem de çocukların sevgisini kazanacaktır.", Activity=activities[4],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Saksı Olmanın Faydaları (2012)", Image="saksiolmaninfaydalari.jpg", Rate=8, Description ="Duygusal ve utangaç olan Charlie, bir yandan değişen çevresini gözlemlerken bir yandan da en iyi arkadaşı Michael'ın yakın zamandaki intiharıyla uğraşmaktadır. İngilizce öğretmeni Bill, ona okuması için fazladan kitaplar vererek hayata katılmayı öğretmeye çalışır ve Bill'in çabaları Charlie'nin deneyimleriyle açığa çıkacaktır.", Activity=activities[4],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Roman Holiday (1953)", Image="romatatili.jpg", Rate=8, Description ="Saray protokollerine göre yaşamak zorunda olan Prenses Ann, Avrupa turunun yoğun temposundan sıkılmış, Roma'ya geldiklerinde nihayet yaşı gereği neşeli ve çılgın günler geçirmek istediğini kendine itiraf edebilmiştir. Bir gece çılgınlık yapıp kimseye haber vermeden saraydan ayrılan Prenses, bir bankta uyuyakalır. Genç kadının şansı yaver gider ve yardımsever bir adam onu kendi evine götürür; ancak bu durum genç kadına pahalıya patlayacaktır. Ülkenin en gözü açık gazetecilerinden biri olan Joe Bradley'in evinde kalan Prenses Ann, büyük bir habere manşet olmak üzeredir.", Activity=activities[4],Emotion=emotions[1], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Kepez Sahil Yürüyüş Alanı", Image="walk3.jpg", Rate=8, Description ="", Activity=activities[9],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Tekzen", Image="tekzen.jpg", Rate=8, Description =" ", Activity=activities[8],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Soul Raiver", Image="kain.jpg", Rate=8, Description ="Kain Serisi", Activity=activities[7],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Tomb Raider ", Image="tombraider.jpg", Rate=8, Description ="Tomb Raider serisi ", Activity=activities[7],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Evrenin Şifresi", Image="evren.jpg", Rate=8, Description ="İnsanlık yeni bir evrenin kıyısında mı?Daha derin bir ruhani amaca mı ulaşılıyor?Zaman hızlanıyor mu?Bütün bu sorulara ‘evet’ diye karşılık veriyorsanız, tebrikler!Rüyadan uyandınız ve kaderinizin sorumluluğunu üstlendiniz demektir.", Activity=activities[5],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Yağmur Yüreklim", Image="yagmur.jpg", Rate=8, Description ="Seksendört", Activity=activities[3],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Berzerk", Image="bezerk.jpg", Rate=8, Description ="Eminem Album", Activity=activities[3],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Kepez Sahil", Image="bike2.jpg", Rate=8, Description ="", Activity=activities[1],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Eragon", Image="eragon.jpg", Rate=8, Description ="Eragon, 2006 yapımı ABD yapımı fantastik film. Film, Christopher Paolini'nin filmle aynı ismi taşıyan kitabından uyarlanmıştır. Filmde, Edward Speleers, Jeremy Irons, Garrett Hedlund, Sienna Guillory, Robert Carlyle, John Malkovich, Djimon Hounsou ve Joss Stone gibi isimler yer almıştır. ", Activity=activities[6],Emotion=emotions[0], InInside=true},

                    new ActivityAttribute(){  AttributeName ="Üç Büyük Usta", Image="usta.jpg", Rate=8, Description ="Üç Büyük Usta: Balzac, Dickens, Dostoyevski, Stefan Zweig'in eserlerindendir. Stefan Zweig yazılarında kişilerin içerisinde yaşadığı çağı, toplumu ve kültür çevresini titizlikle incelemiştir.", Activity=activities[6],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Yeraltından Notlar", Image="notlar.jpg", Rate=8, Description ="Yeraltından Notlar, Dostoyevski'nin, Camus dahil olmak üzere birçok Batılı düşünürü varoluşçu anlamda etkilemiş bir klasik olarak kabul edilen kısa romanıdır. 1864 yılında Petersburg'da basılmıştır.", Activity=activities[6],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="LA LA LAND", Image="lalaland1.jpg", Rate=8, Description ="Aşıklar Şehri, Damien Chazelle tarafından yazılan ve yönetilen Amerikan romantik müzikal komedi-drama filmi. Filmin başrollerinde Ryan Gosling ve Emma Stone yer almaktadır. Film oyunculuğa hevesli Mia ile caz piyanisti Sebastian'ın ilişkisini konu edinmektedir.", Activity=activities[4],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Atiye", Image="atiye.jpg", Rate=8, Description ="Atiye, 27 Aralık 2019 tarihinde 8 bölümden oluşan ilk sezonun yayımlandığı, senaryosunu Jason George, Nuran Evren Şit ve Fatih Ünal'ın birlikte kaleme aldıkları, aksiyon ve fantastik türündeki Netflix'in ikinci Türk orijinal internet dizisi. Yazar Şengül Boybaş'ın Dünyanın Uyanışı adlı eserinden uyarlanmıştır. ", Activity=activities[2],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="You", Image="you.jpg", Rate=8, Description ="You, Greg Berlanti ve Sera Gamble tarafından geliştirilen Amerikan psikolojik gerilim türündeki televizyon dizisidir.", Activity=activities[2],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Mandalorian", Image="mandalorian.jpg", Rate=8, Description ="The Mandalorian, 12 Kasım 2019'da Disney+'da yayınlanan Amerikan uzay western, internet tabanlı televizyon dizisidir. Yıldız Savaşları evreninde geçen seri, Jedi'nin Dönüşü döneminden beş yıl sonra gerçekleşen ve Yeni Cumhuriyet'in ulaşamayacağı yerlerde bir Mandaloryalı ödül avcısını izler. ", Activity=activities[2],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Marriage Story", Image="marriage.jpg", Rate=8, Description ="Marriage Story, evli bir çiftin New York'tan Los Angeles'a kadar uzanan boşanma hikayesini konu ediyor. Bir yönetmen olan Charlie ve oyuncu olan eşi Nicole, evliliklerinde sona gelen bir çiftir. Boşanmaya karar veren çift, bu süreci kolayca sona erdirmeyi düşünse de işler pek de düşündükleri gibi gitmez. Çocuklarının velayeti işin içine girince, süreç beklediklerinden daha karmaşık bir hal alır.", Activity=activities[4],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Vikings", Image="vikings.jpg", Rate=8, Description ="Vikings, tarihsel drama türünde bir Kanada-İrlanda ortak yapımı televizyon dizisi. Yazarlığını ve yapımcılığını Michael Hirst'in yaptığı dizi History kanalında yayınlanmaktadır. ", Activity=activities[2],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Gelibolu Sineması", Image="sinema.jpg", Rate=8, Description =" ", Activity=activities[0],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Bozcaada Bisiklet Yolu", Image="bikee.jpg", Rate=8, Description =" ", Activity=activities[1],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Asos", Image="walk5.jpg", Rate=8, Description =" ", Activity=activities[9],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Bozcaada ", Image="walk4.jpg", Rate=8, Description =" ", Activity=activities[9],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Kepez AVM", Image="avm.jpg", Rate=8, Description =" ", Activity=activities[8],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName =" ", Image="avm2.jpg", Rate=8, Description =" ", Activity=activities[8],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName =" ", Image="avm3.jpg", Rate=8, Description =" ", Activity=activities[8],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Metro Exodus", Image="metro.jpg", Rate=8, Description ="4A Games tarafından geliştirilen ve Deep Silver tarafından yayınlanan birinci şahıs nişancı tarzında video oyunudur. Yazar Dmitry Glukhovsky'nin romanlarından esinlenen Metro oyun serisinin üçüncü oyunudur. Metro 2033 ve Metro: Last Light oyunlarında yaşanan hadiseleri izlemektedir.", Activity=activities[7],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Hollow Knight", Image="ho.jpg", Rate=8, Description ="2017 Metroidvania tarzı bir video oyunudur. Cherry Takımı tarafından geliştirilmiş ve yayınlanmıştır. ", Activity=activities[7],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Ori and the Will of the Wisps", Image="ori.jpg", Rate=8, Description ="Moon Studios tarafından geliştirilen ve Xbox One ve Microsoft Windows için Xbox Game Studios tarafından yayınlanan bir platform macerası Metroidvania video oyunudur. E3 2017 sırasında duyurulan 2015 Ori ve Kör Ormanı'nın doğrudan devamıdır ve 11 Mart 2020'de yayınlanmıştır.", Activity=activities[7],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="AO Tennis 2", Image="ao.jpg", Rate=8, Description ="AO Tennis 2 kendi topluluğu tarafından ve kendi topluluğu için geliştirilen tek tenis oyunu. Kendi oyuncularını, kortlarını ve efsanevi maçlarını yarat. Kariyer Modunda tenis dünyasının zirvesine tırmanmak için mücadele et", Activity=activities[7],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Kardeş Payı", Image="kardes.jpg", Rate=8, Description ="Kardeş Payı, Mehmet Yiğit Alp'in yapımcılığını ve Selçuk Aydemir'in yönetmenliğini üstlendiği komedi türündeki Türk televizyon dizisi. NTC Medya tarafından yapılan dizinin ilk bölümü 13 Şubat 2014 tarihinde Star TV'de gösterime girdi. ", Activity=activities[2],Emotion=emotions[2], InInside=true},
                    new ActivityAttribute(){  AttributeName ="Suç ve Ceza", Image="sucveceza.jpg", Rate=8, Description ="Suç ve Ceza, Rus yazar Fyodor Dostoyevski tarafından yazılan romandır. İlk olarak 1866 yılı boyunca edebiyat dergisi Rus Habercisi'nde on iki ayda yayımlandı. Daha sonra tek cilt olarak yayımlandı. Dostoyevski'nin beş yıl süren Sibirya sürgününün dönüşü yazdığı tam uzunluktaki ikinci romanıdır.", Activity=activities[6],Emotion=emotions[0], InInside=true},
                    new ActivityAttribute(){  AttributeName ="An Inconvenient Truth", Image="an.jpg", Rate=8, Description ="Uygunsuz Gerçek, 2006 ABD yapımı belgesel filmdir. Yönetmenliğini Davis Guggenheim'ın üstlendiği film, eski ABD Başkan Yardımcısı Al Gore'un vatandaşları kapsamlı bir slayt gösterisiyle küresel ısınma konusunda eğitmeyi amaçlayan kampanyasına ilişkindir.", Activity=activities[5],Emotion=emotions[0], InInside=true},
                     };
                    context.ActivityAttributes.AddRange(activityattributes);

                    var activityEmotions = new[]
                    {
                    new ActivityEmotion(){ Activity = activities[0], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[1], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[2], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[3], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[4], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[5], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[6], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[7], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[8], Emotion=emotions[0]},
                    new ActivityEmotion(){ Activity = activities[9], Emotion=emotions[0]},

                    new ActivityEmotion(){ Activity = activities[0], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[1], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[2], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[3], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[4], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[5], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[6], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[7], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[8], Emotion=emotions[1]},
                    new ActivityEmotion(){ Activity = activities[9], Emotion=emotions[1]},

                    new ActivityEmotion(){ Activity = activities[0], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[1], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[2], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[3], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[4], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[5], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[6], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[7], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[8], Emotion=emotions[2]},
                    new ActivityEmotion(){ Activity = activities[9], Emotion=emotions[2]},

                    new ActivityEmotion(){ Activity = activities[0], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[1], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[2], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[3], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[4], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[5], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[6], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[7], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[8], Emotion=emotions[3]},
                    new ActivityEmotion(){ Activity = activities[9], Emotion=emotions[3]},

                    new ActivityEmotion(){ Activity = activities[0], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[1], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[2], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[3], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[4], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[5], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[6], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[7], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[8], Emotion=emotions[4]},
                    new ActivityEmotion(){ Activity = activities[9], Emotion=emotions[4]},

                    new ActivityEmotion(){ Activity = activities[0], Emotion=emotions[5]},
                    new ActivityEmotion(){ Activity = activities[1], Emotion=emotions[5]},
                    new ActivityEmotion(){ Activity = activities[2], Emotion=emotions[5]},
                    new ActivityEmotion(){ Activity = activities[3], Emotion=emotions[5]},
                    new ActivityEmotion(){ Activity = activities[4], Emotion=emotions[5]},
                    new ActivityEmotion(){ Activity = activities[5], Emotion=emotions[5]},
                    new ActivityEmotion(){ Activity = activities[6], Emotion=emotions[5]},
                    new ActivityEmotion(){ Activity = activities[7], Emotion=emotions[5]},
                    new ActivityEmotion(){ Activity = activities[8], Emotion=emotions[5]},
                    new ActivityEmotion(){ Activity = activities[9], Emotion=emotions[5]},

                    new ActivityEmotion(){ Activity = activities[0], Emotion=emotions[6]},
                    new ActivityEmotion(){ Activity = activities[1], Emotion=emotions[6]},
                    new ActivityEmotion(){ Activity = activities[2], Emotion=emotions[6]},
                    new ActivityEmotion(){ Activity = activities[3], Emotion=emotions[6]},
                    new ActivityEmotion(){ Activity = activities[4], Emotion=emotions[6]},
                    new ActivityEmotion(){ Activity = activities[5], Emotion=emotions[6]},
                    new ActivityEmotion(){ Activity = activities[6], Emotion=emotions[6]},
                    new ActivityEmotion(){ Activity = activities[7], Emotion=emotions[6]},
                    new ActivityEmotion(){ Activity = activities[8], Emotion=emotions[6]},
                    new ActivityEmotion(){ Activity = activities[9], Emotion=emotions[6]},


                };
                    context.ActivityEmotions.AddRange(activityEmotions);
                    context.SaveChanges();
                }
            }
        }
    }
}

