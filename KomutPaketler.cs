using System.Collections.Generic;
using System.Linq;
using Rocket.API;
using Rocket.Unturned.Chat;

namespace DaeRpMarket
{
    internal class KomutPaketler : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "paketler";
        public string Help => "Sahip olunan paketlerin listelenmesini sağlar.";
        public string Syntax => "/paketler";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string> { "dae.rpmarket.paketler" };

        public void Execute(IRocketPlayer komutuÇalıştıran, string[] parametreler)
        {
            var eşyaPaketleri = RpMarket.Örnek.Configuration.Instance.EşyaPaketleri
                .Where(p => komutuÇalıştıran.HasPermission($"dae.rpmarket.{p.İsim}"))
                .Select(p => p.İsim)
                .ToArray();
            if (eşyaPaketleri.Any())
            {
                UnturnedChat.Say(komutuÇalıştıran, RpMarket.Örnek.Translate("Paketlerin", string.Join(", ", eşyaPaketleri)));
            }

            var araçPaketleri = RpMarket.Örnek.Configuration.Instance.AraçPaketleri
                .Where(p => komutuÇalıştıran.HasPermission($"dae.rpmarket.{p.İsim}"))
                .SelectMany(p => p.Araçlar.Select(a => a.Id))
                .Distinct()
                .OrderBy(id => id)
                .ToArray();
            if (araçPaketleri.Any())
            {
                UnturnedChat.Say(komutuÇalıştıran, RpMarket.Örnek.Translate("Araçların", string.Join(", ", araçPaketleri)));
            }
        }
    }
}