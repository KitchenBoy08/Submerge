using MelonLoader;

[assembly: MelonInfo(typeof(Submerge.Core), "Submerge", "1.0.0", "KitchenBoy", null)]
[assembly: MelonGame("Unknown Worlds", "Subnautica")]

namespace Submerge
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }
    }
}