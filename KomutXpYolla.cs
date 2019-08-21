using System.Collections.Generic;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using UnityEngine;

namespace DaeRpMarket
{
    internal class KomutXpYolla : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "xpyolla";
        public string Help => "Tecrübe aktarımını sağlar.";
        public string Syntax => "/xpyolla <Oyuncu> <Miktar>";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string> { "dae.rpmarket.xpyolla" };

        public void Execute(IRocketPlayer komutuÇalıştıran, string[] parametreler)
        {
            if (parametreler.Length != 2 || !uint.TryParse(parametreler[1], out var tecrübe))
            {
                UnturnedChat.Say(komutuÇalıştıran, RpMarket.Örnek.Translate("HatalıParametre"), Color.red);
                return;
            }

            var hedefOyuncu = UnturnedPlayer.FromName(parametreler[0]);
            if (hedefOyuncu == null)
            {
                UnturnedChat.Say(komutuÇalıştıran, RpMarket.Örnek.Translate("OyuncuBulunamıyor"), Color.red);
                return;
            }

            var oyuncu = (UnturnedPlayer)komutuÇalıştıran;

            if (tecrübe > oyuncu.Experience)
            {
                UnturnedChat.Say(oyuncu, RpMarket.Örnek.Translate("TecrübeYetersiz", tecrübe - oyuncu.Experience), Color.red);
                return;
            }

			if (oyuncu.CSteamID == hedefOyuncu.CSteamID)
			{
                UnturnedChat.Say(oyuncu, RpMarket.Örnek.Translate("TecrübeYollanamıyor"), Color.red);
                return;
			}

            oyuncu.Experience -= tecrübe;
            hedefOyuncu.Experience += tecrübe;

            UnturnedChat.Say(oyuncu, RpMarket.Örnek.Translate("TecrübeYolladın", hedefOyuncu.CharacterName, tecrübe, oyuncu.Experience));
            UnturnedChat.Say(hedefOyuncu, RpMarket.Örnek.Translate("TecrübeAldın", oyuncu.CharacterName, tecrübe, hedefOyuncu.Experience));
        }
	}
}