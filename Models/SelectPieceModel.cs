namespace GungiBackend.models
{
    public class SelectPieceModel
    {
        public string pieceName { get; set; } = string.Empty;
        public int currentX { get; set; }
        public int currentY { get; set; }
        public int currentZ { get; set; } // 高さ
        public bool player { get; set; }
    }
}
