using System;

namespace Scrappers.DataClasses.SaveData
{
    public class SaveData
    {
        public InventorySaveData CurrentInventory { get; set; }
        public ShipSaveData CurrentShip { get; set; }
        public DroneSaveData[] DronesEquiped { get; set; }
        public DroneSaveData[] DronesOwned { get; set; }
        public int NumberOfDaysSurvived { get; set; }
        public DateTime TimeLastSaved { get; set; }
        public DateTime TimePlayed { get; set; }
    }
}