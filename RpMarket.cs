using Rocket.API.Collections;
using Rocket.Core.Plugins;

namespace DaeRpMarket
{
    public class RpMarket : RocketPlugin<RpMarketYapılandırma>
    {
        public static RpMarket Örnek { get; private set; }

        protected override void Load()
        {
            Örnek = this;
        }

        protected override void Unload()
        {
            Örnek = null;
        }

        public override TranslationList DefaultTranslations => new TranslationList
        {
            { "HatalıParametre", "Hatalı parametre." },
            { "YetersizBakiye", "Ücreti karşılayamıyorsun. Eksik miktar: {0}" },
            { "Paketlerin", "Paketlerin: {0}" },
            { "Araçların", "Araçların: {0}" },
            { "OyuncuBulunamıyor", "Oyuncu bulunamıyor." },
            { "TecrübeYetersiz", "Mevcut tecrübenden daha fazlasını yollayamazsın. Eksik miktar: {0}" },
            { "TecrübeYollanamıyor", "Kendine tecrübe yollayamazsın." },
            { "TecrübeYolladın", "{0} adlı oyuncuya {1} tecrübe yolladın. Mevcut tecrüben: {2}" },
            { "TecrübeAldın", "{0} adlı oyuncudan {1} tecrübe aldın. Mevcut tecrüben: {2}" },
            { "PaketBulunamadı", "Paket bulunamadı." },
            { "PaketSatınAlındı", "{0} isimli paketi satın aldın. Mevcut bakiyen: {1}" },
            { "AraçBulunamadı", "Araç bulunamadı." },
            { "AraçSatınAlındı", "{0} numaralı aracı satın aldın. Mevcut bakiyen: {1}" }
        };
    }
}