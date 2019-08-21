using System.Collections.Generic;
using System.Xml.Serialization;

namespace DaeRpMarket.Modeller
{
    public class EşyaPaketi
    {
        [XmlAttribute]
        public string İsim { get; set; }

        [XmlAttribute]
        public uint Ücret { get; set; }
        
        [XmlAttribute]
        public bool TecrübeKullanılsın { get; set; }

        public List<Eşya> Eşyalar { get; set; }

        public EşyaPaketi()
        {
        }

        public EşyaPaketi(string isim, uint ücret, bool tecrübeKullanılsın, List<Eşya> eşyalar)
        {
            İsim = isim;

            Ücret = ücret;

            TecrübeKullanılsın = tecrübeKullanılsın;

            Eşyalar = eşyalar;
        }
    }
}