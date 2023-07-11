namespace KitchenXLB.Mains
{
    public class XLBDish : CustomDish
    {
        public override string UniqueNameID => "xlb_dish";
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override bool IsUnlockable => true;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.None;
        public override int MinimumFranchiseTier => 0;
        public override bool IsSpecificFranchiseTier => false;
        public override float SelectionBias => 0;

        public override GameObject IconPrefab => Mod.Bundle.LoadAsset<GameObject>("xlb_icon");
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("xlb_icon");
        public override DishType Type => DishType.Base;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool DestroyAfterModUninstall => false;
        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Knead flour, add chopped meat. Fold this once and then cook. Portion, plate, and then serve. Add sprinkles if ordered." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateUnlockInfo("XLB", "Adds XLB as a main dish", "Love me a good doughnut!"))
        };
        public override HashSet<Process> RequiredProcesses => new()
        {
            GetGDO<Process>(ProcessReferences.Cook)
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            GetGDO<Item>(ItemReferences.Plate),
            GetGDO<Item>(ItemReferences.Flour),
            GetGDO<Item>(ItemReferences.Meat),
            GetGDO<Item>(ItemReferences.Pot),
            GetGDO<Item>(ItemReferences.Onion)
        };
        public override List<string> StartingNameSet => new()
        {
            "Steamy Bites",
            "Dragon's XLB",
            "The Bao Bar",
            "Bao Bliss",
            "Bao Bistro",
            "Bao & Beyond",
            "Bao Bonanza"
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, PlatedXLB>(),
                DynamicMenuType = DynamicMenuType.Static,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };

        public override void OnRegister(Dish gdo)
        {
            IconPrefab.ApplyMaterialToChildCafe("basket", "XLB - \"BasketDark\"");
            IconPrefab.ApplyMaterialToChildCafe("baos", "XLB - \"BaoDark\"");
        }
    }

}
