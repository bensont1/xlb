using IngredientLib.Ingredient.Items;

namespace KitchenXLB.Mains
{
    public class CrabXLBDish : CustomDish
    {
        public override string UniqueNameID => "crab_xlb_dish";
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override bool IsUnlockable => true;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override int MinimumFranchiseTier => 0;
        public override bool IsSpecificFranchiseTier => false;
        public override float SelectionBias => 0;

        public override GameObject IconPrefab => Mod.Bundle.LoadAsset<GameObject>("xlb");
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("xlb");
        public override DishType Type => DishType.Base;
        public override List<Unlock> HardcodedRequirements => new() { GetCastedGDO<Unlock, XLBDish>() };
        public override List<Unlock> HardcodedBlockers => new();
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
            GetGDO<Item>(ItemReferences.Onion),
        };
        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new()
        {
            new()
            {
                MenuItem = GetCastedGDO<ItemGroup, PlatedXLB>(),
                Ingredient = GetCastedGDO<Item, Caramel>()
            },
        };


    }

}
