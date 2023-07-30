using IngredientLib.Ingredient.Items;
using Unity.Entities;

namespace KitchenXLB.Mains
{
    internal class UncookedXLBSoup : CustomItemGroup<UncookedXLBSoup.View>
    {
        public override string UniqueNameID => "uncooked_xlb_soup";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("uncooked_xlb_soup");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);
        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Cook),
                Duration = 4.0f,
                Result = GetCastedGDO<Item, CookedXLBSoup>()
            }
        };

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetGDO<Item>(ItemReferences.SoupMeatCooked),
                Text = "Sm"
            },
            new()
            {
                Item = GetCastedGDO<Item, Ice>(),
                Text = "Ic"
            }
        };
        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.SoupMeatCooked),
                    GetCastedGDO<Item, Ice>()
                },
                 IsMandatory = true,
                Max = 2,
                Min = 2
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.TryAddComponent<View>().Setup(gdo);

            var pot = Prefab.GetChild("Pot/Pot.001");
            pot.ApplyMaterialToChild("Cylinder", "Metal");

            pot.ApplyMaterialToChild("Cylinder.003", "Metal Dark");

            var pumpkin = Prefab.GetChild("Pumpkin Group");
            pumpkin.ApplyMaterialToChild("Pumpkin", "Soup - Meat");

            pumpkin.GetChild("Pumpkin/Pumpkin - Chopped").ApplyMaterialToChild("Meat - Chopped.001", "Ice");
            pumpkin.GetChild("Pumpkin/Pumpkin - Chopped").ApplyMaterialToChild("Meat - Chopped.002", "Ice");
        }

        public class View : AccessedItemGroupView
        {
            protected override List<ComponentGroup> groups => new()
            {
                new()
                {
                    GameObject = gameObject.GetChild("Meat - Chopped"),
                    Item = GetGDO<Item>(ItemReferences.SoupMeatCooked)
                },
                new()
                {
                    GameObject = gameObject.GetChild("Ice"),
                    Item = GetCastedGDO<Item, Ice>()
                }
            };
        }
    }
}
