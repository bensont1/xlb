using IngredientLib.Ingredient.Items;
using KitchenXLB.Appliances;
using KitchenXLB.Processes;

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
        public override DishType Type => DishType.Main;
        public override List<Unlock> HardcodedRequirements => new() { GetCastedGDO<Unlock, XLBDish>() };
        public override List<Unlock> HardcodedBlockers => new();
        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Knead flour (or add water) to create dough, add chopped crab and portioned XLB soup (meat soup add ice). Fold once and then cook. Plate, and serve." }        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateUnlockInfo("Crab XLB", "Adds Crab XLB as a main dish", "Give me some crab!"))
        };
        public override HashSet<Process> RequiredProcesses => new()
        {
            GetGDO<Process>(ProcessReferences.Cook),
            GetCastedGDO<Process, CrabProviderProcess>(),
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
           GetGDO<Item>(ItemReferences.Flour)
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, PlatedCrabXLB>(),
                DynamicMenuType = DynamicMenuType.Static,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
      /*  public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new()
        {
            new()
            {
                MenuItem = GetCastedGDO<ItemGroup, PlatedCrabXLB>(),
                Ingredient = GetGDO<Item>(ItemReferences.CrabRaw)
            },
        };*/


    }

}
