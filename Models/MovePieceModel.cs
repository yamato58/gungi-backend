namespace GungiBackend.Models
{
    public class MovePieceModel
    {
        public int Id { get; set; }
        public int NextX { get; set; }
        public int NextY { get; set; }
        public int NextZ { get; set; }
        public bool IsPlayer { get; set; }
        public bool IsGet { get; set; }
    }
}
