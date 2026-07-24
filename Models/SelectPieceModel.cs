namespace GungiBackend.models
{
    public class SelectPieceModel
    {
        public string PieceName { get; set; } = string.Empty;
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public int CurrentZ { get; set; } // 高さ
        public bool Player { get; set; }
    }
}
