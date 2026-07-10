namespace GungiBackend.Models
{
    public class MovePieceModel
    {
        public int id { get; set; }
        public int nextX { get; set; }
        public int nextY { get; set; }
        public int nextZ { get; set; }
        public bool isPlayer { get; set; }
        public bool isGet { get; set; }
    }
}
