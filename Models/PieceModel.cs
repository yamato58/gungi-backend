namespace GungiBackend.models
{
    public class Piece
    {
        public int id { get; set; }
        public string pieceName { get; set; } // 駒名
        public int currentX { get; set; } // 初期のx
        public int currentY { get; set; } // 初期のy
        public int currentZ { get; set; } // 高さ
        public bool player { get; set; } // 黒か白か

        public Piece(int id, string name, int x, int y, int z, bool player)
        {
            this.id = id;
            this.pieceName = name;
            this.currentX = x;
            this.currentY = y;
            this.currentZ = z;
            this.player = player;
        }
    }
}
