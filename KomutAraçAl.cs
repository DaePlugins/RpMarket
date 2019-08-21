using System.Collections.Generic;
using System.Linq;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using UnityEngine;
using fr34kyn01535.Uconomy;

namespace DaeRpMarket
{
	internal class KomutAraçAl : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "aracal";
        public string Help => "Araç almayı sağlar.";
        public string Syntax => "/aracal";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string> { "dae.rpmarket.aracal" };

        public void Execute(IRocketPlayer komutuÇalıştıran, string[] parametreler)
        {
            if (parametreler.Length != 1 || !ushort.TryParse(parametreler[0], out var id))
            {
                UnturnedChat.Say(komutuÇalıştıran, RpMarket.Örnek.Translate("HatalıParametre"), Color.red);
                return;
            }

            var paket = RpMarket.Örnek.Configuration.Instance.AraçPaketleri.FirstOrDefault(p => komutuÇalıştıran.HasPermission($"dae.rpmarket.{p.İsim.ToLower()}")
                                                                                                && p.Araçlar.Any(a => a.Id == id));
            if (paket == null)
            {
                UnturnedChat.Say(komutuÇalıştıran, RpMarket.Örnek.Translate("AraçBulunamadı"), Color.red);
                return;
            }
            
            var oyuncu = (UnturnedPlayer)komutuÇalıştıran;

            var araç = paket.Araçlar.First(a => a.Id == id);

            if (araç.TecrübeKullanılsın)
            {
                if (araç.Ücret > oyuncu.Experience)
                {
                    UnturnedChat.Say(oyuncu, RpMarket.Örnek.Translate("YetersizBakiye", araç.Ücret - oyuncu.Experience), Color.red);
                    return;
                }

                oyuncu.Experience -= araç.Ücret;

				UnturnedChat.Say(oyuncu, RpMarket.Örnek.Translate("AraçSatınAlındı", id, oyuncu.Experience));
            }
            else
            {
				var bakiye = Uconomy.Instance.Database.GetBalance(komutuÇalıştıran.Id);

                if (araç.Ücret > bakiye)
                {
                    UnturnedChat.Say(oyuncu, RpMarket.Örnek.Translate("YetersizBakiye", araç.Ücret - bakiye), Color.red);
                    return;
                }

                Uconomy.Instance.Database.IncreaseBalance(komutuÇalıştıran.Id, -araç.Ücret);

				UnturnedChat.Say(oyuncu, RpMarket.Örnek.Translate("AraçSatınAlındı", id, bakiye));
            }

            oyuncu.GiveVehicle(id);
        }
	}
}