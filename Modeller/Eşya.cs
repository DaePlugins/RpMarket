using System.Xml.Serialization;

namespace DaeRpMarket.Modeller
{
    public class Eşya
    {
        [XmlAttribute]
        public ushort Id { get; set; }

        [XmlAttribute]
        public byte Miktar { get; set; }

        public Eşya()
        {
        }

        public Eşya(ushort id, byte miktar)
        {
            Id = id;

            Miktar = miktar;
        }
    }
}