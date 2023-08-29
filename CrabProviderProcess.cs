using KitchenXLB.Appliances;
using KitchenXLB.Mains;
using Unity.Transforms;

namespace KitchenXLB.Processes
{
    public class CrabProviderProcess : CustomProcess
    {
        public static int StaticID { get; private set; }
        public override string UniqueNameID => "crab_provider_process";
        public override bool CanObfuscateProgress => true;
        public override int EnablingApplianceCount => 1;
        public override GameDataObject BasicEnablingAppliance => GetCustomGameDataObject<CrabProvider>().GameDataObject;

        public override List<(Locale, ProcessInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateProcessInfo("Requires Crab", "?"))
        };

        public override void AttachDependentProperties(GameData gameData, GameDataObject gdo)
        {
            base.AttachDependentProperties(gameData, gdo);
            StaticID = gdo.ID;
        }
    }
}