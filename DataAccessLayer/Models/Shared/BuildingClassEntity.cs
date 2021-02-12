
namespace RLBPulse.System.DAL.Entities
{
    public sealed class BuildingClassEntity
    {
        public int building_class_id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int parent_id { get; set; }
    }
}
