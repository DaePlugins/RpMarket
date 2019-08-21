using System.Xml.Serialization;

namespace DaeRpMarket.Modeller
{
    public class Araç
    {
        [XmlAttribute]
        public ushort Id { get; set; }

        [XmlAttribute]
        public uint Ücret { get; set; }

        [XmlAttribute]
        public bool TecrübeKullanılsın { get; set; }

        public Araç()
        {
        }

        public Araç(ushort id, uint ücret, bool tecrübeKullanılsın)
        {
            Id = id;

            Ücret = ücret;
            
            TecrübeKullanılsın = tecrübeKullanılsın;
        }
    }
}