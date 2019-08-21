using System;
using System.Collections.Generic;
using System.Linq;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using UnityEngine;
using fr34kyn01535.Uconomy;

namespace DaeRpMarket
{
    internal class KomutPaketAl : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "paketal";
        public string Help => "Hazır paket almayı sağlar.";
        public string Syntax => "/paketal";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string> { "dae.rpmarket.paketal" };

        public void Execute(IRocketPlayer komutuÇalıştıran, string[] parametreler)
        {
            if (parametreler.Length != 1)
            {
                UnturnedChat.Say(komutuÇalıştıran, RpMarket.Örnek.Translate("HatalıParametre"), Color.red);
                return;
            }

            var paket = RpMarket.Örnek.Configuration.Instance.EşyaPaketleri.FirstOrDefault(p => string.Equals(p.İsim.ToLower(), parametreler[0].ToLower(), StringComparison.CurrentCultureIgnoreCase)
                                                                                                && komutuÇalıştıran.HasPermission($"dae.rpmarket.{p.İsim.ToLower()}") && p.Eşyalar.Count > 0);
            if (paket == null)
            {
                UnturnedChat.Say(komutuÇalıştıran, RpMarket.Örnek.Translate("PaketBulunamadı"), Color.red);
                return;
            }
            
            var oyuncu = (UnturnedPlayer)komutuÇalıştıran;

            if (paket.TecrübeKullanılsın)
            {
                if (paket.Ücret > oyuncu.Experience)
                {
                    UnturnedChat.Say(oyuncu, RpMarket.Örnek.Translate("YetersizBakiye", paket.Ücret - oyuncu.Experience), Color.red);
                    return;
                }

                oyuncu.Experience -= paket.Ücret;

				UnturnedChat.Say(oyuncu, RpMarket.Örnek.Translate("PaketSatınAlındı", paket.İsim, oyuncu.Experience));
            }
            else
            {
				var bakiye = Uconomy.Instance.Database.GetBalance(komutuÇalıştıran.Id);

                if (paket.Ücret > bakiye)
                {
                    UnturnedChat.Say(oyuncu, RpMarket.Örnek.Translate("YetersizBakiye", paket.Ücret - bakiye), Color.red);
                    return;
                }

                Uconomy.Instance.Database.IncreaseBalance(komutuÇalıştıran.Id, -paket.Ücret);

				UnturnedChat.Say(oyuncu, RpMarket.Örnek.Translate("PaketSatınAlındı", paket.İsim, bakiye));
            }

            foreach (var eşya in paket.Eşyalar)
            {
                oyuncu.GiveItem(eşya.Id, eşya.Miktar);
            }
        }
	}
}