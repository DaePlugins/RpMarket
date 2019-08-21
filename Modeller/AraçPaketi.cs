using System.Collections.Generic;
using System.Xml.Serialization;

namespace DaeRpMarket.Modeller
{
    public class AraçPaketi
    {
        [XmlAttribute]
        public string İsim { get; set; }

        public List<Araç> Araçlar { get; set; }

        public AraçPaketi()
        {
        }

        public AraçPaketi(string isim, List<Araç> araçlar)
        {
            İsim = isim;

            Araçlar = araçlar;
        }
    }
}