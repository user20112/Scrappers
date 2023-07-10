namespace Scrappers.DataClasses.SaveData
{
    public class DroneModificationSaveData
    {
        public string AdditionalDataJson { get; set; }
        public int[] FixedModificationsApplied { get; set; }
        public double LikelyHoodToBreak { get; set; }
        public int ModificationId { get; set; }
        public int NumberOfMissionsUsed { get; set; }
        public int UsesRemaining { get; set; }
    }
}