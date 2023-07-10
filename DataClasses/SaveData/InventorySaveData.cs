namespace Scrappers.DataClasses.SaveData
{
    public class InventorySaveData
    {
        public DroneModificationSaveData[] DroneModifications { get; set; }
        public int ScrapCount { get; set; }
        public ShipUpgradeSaveData[] ShipUpgrades { get; set; }
    }
}