using System.Collections.Generic;
using DaeRpMarket.Modeller;
using Rocket.API;

namespace DaeRpMarket
{
	public class RpMarketYapılandırma : IRocketPluginConfiguration
    {
        public List<EşyaPaketi> EşyaPaketleri { get; set; } = new List<EşyaPaketi>();
        public List<AraçPaketi> AraçPaketleri { get; set; } = new List<AraçPaketi>();

        public void LoadDefaults()
        {
            EşyaPaketleri = new List<EşyaPaketi>
            {
                new EşyaPaketi
                (
                    "tamirci",
                    250,
                    true,
                    new List<Eşya>
                    {
                        new Eşya(76, 1),
                        new Eşya(277, 1),
                        new Eşya(1451, 4)
                    }
                ),
                new EşyaPaketi
                (
                    "pizzaci",
                    100,
                    false,
                    new List<Eşya>
                    {
                        new Eşya(1164, 5)
                    }
                ),
                new EşyaPaketi
                (
                    "galerici",
                    150,
                    true,
                    new List<Eşya>
                    {
                        new Eşya(1451, 4)
                    }
                )
            };

            AraçPaketleri = new List<AraçPaketi>
            {
                new AraçPaketi
                (
                    "galerici",
                    new List<Araç>
                    {
                        new Araç(1, 250, true),
                        new Araç(25, 500, false),
                        new Araç(67, 1000, true)
                    }
                ),
                new AraçPaketi
                (
                    "asker",
                    new List<Araç>
                    {
                        new Araç(87, 1000, false),
                        new Araç(138, 250, false)
                    }
                )
            };
		}
	}
}