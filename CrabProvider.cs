namespace KitchenXLB.Appliances
{
    public class CrabProvider : CustomAppliance
    {
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("crab_provider");
        public override string UniqueNameID => "crab_provider";
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateApplianceInfo("Crab", "Fresh crabs", new()
            {
                new()
                {
                    Title = "Crab",
                    Description = "Gives you fresh crabs"
                }
            }, new()))
        };
        public override bool IsPurchasable => true;
        public override PriceTier PriceTier => PriceTier.Cheap;
        public override RarityTier RarityTier => RarityTier.Common;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;
        public override bool SellOnlyAsDuplicate => true;

        public override List<IApplianceProperty> Properties => new()
        {
            GetUnlimitedCItemProvider(GetGDO<Item>(ItemReferences.CrabRaw).ID),
        };

        /*  public override List<IApplianceProperty> Properties => new()
          {
              GetCItemProvider(GetGDO<Item>(ItemReferences.CrabRaw).ID, 0, 0, false, false, false, false, false, true, false),
              new CAutomatedInteractor()
              {
                  Type = InteractionType.Grab,
                  DoNotReceive = true,
                  TransferOnly = false,
                  IsHeld = false,
                  RequiredFlags = TransferFlags.RequireMerge
              },
              new CItemHolder(),
              new CItemHolderFilter()
              {
                  NoDirectInsertion = true,
                  AllowAny = false,
                  Category = ItemCategory.Generic,
              }
          };*/

        public override void OnRegister(Appliance gdo)
        {
            Prefab.AddComponent<HoldPointContainer>().HoldPoint = Prefab.transform.Find("HoldPoint");


            Prefab.ApplyMaterialToChildGame("Cube", "Plastic - Blue");

            Prefab.ApplyMaterialToChildGame("Cube.001", "Metal Very Dark");

            Prefab.ApplyMaterialToChildren("Cube.002", "Ice");
            Prefab.ApplyMaterialToChildren("Cube.003", "Ice");
            Prefab.ApplyMaterialToChildren("Cube.004", "Ice");
            Prefab.ApplyMaterialToChildren("Cube.005", "Ice");
            Prefab.ApplyMaterialToChildren("Cube.006", "Ice");

            Prefab.ApplyMaterialToChildGame("Crab - Raw.001", "Crab - Raw Shell");
            Prefab.ApplyMaterialToChildGame("Crab - Raw.002", "Crab - Raw Shell");
            Prefab.ApplyMaterialToChildGame("Crab - Raw.003", "Crab - Raw Shell");
        }
    }
}

