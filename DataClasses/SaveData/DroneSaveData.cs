namespace Scrappers.DataClasses.SaveData
{
    public class DroneSaveData
    {
        public int CurrentHealthy { get; set; }
        public DroneModificationSaveData[] ModularModificationsAttatched { get; set; }
        public int ModularUpgradeSlots { get; set; }
        public double MotorsFailingPercent { get; set; }
        public DroneModificationSaveData[] PermenantModificationsAttatched { get; set; }
        public int PermenantUpgradeSlots { get; set; }
        public int TotalHealth { get; set; }
        public double VideoFailingPercent { get; set; }
    }
}