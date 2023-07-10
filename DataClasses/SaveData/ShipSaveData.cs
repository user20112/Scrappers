namespace Scrappers.DataClasses.SaveData
{
    public class ShipSaveData
    {
        public int ActiveDroneBays { get; set; }
        public int DormantDroneBays { get; set; }
        public int JFuelStorageLimit { get; set; }
        public ShipUpgradeSaveData[] ModularlyInstalledUpgrades { get; set; }
        public int ModularShipUpgradeSlots { get; set; }
        public ShipUpgradeSaveData[] PermenantlyInstalledUpgrades { get; set; }
        public int PermenantShipUpgradeSlots { get; set; }
        public int PFuelStorageLimit { get; set; }
        public int ScrapStorageLimit { get; set; }
        public int StorageCount { get; set; }
    }
}