namespace GungiBackend.models
{
    public class Piece
    {
        public int Id { get; set; }
        public string PieceName { get; set; } // 駒名
        public int CurrentX { get; set; } // 初期のx
        public int CurrentY { get; set; } // 初期のy
        public int CurrentZ { get; set; } // 高さ
        public bool Player { get; set; } // 黒か白か

        public Piece(int id, string name, int x, int y, int z, bool player)
        {
            this.Id = id;
            this.PieceName = name;
            this.CurrentX = x;
            this.CurrentY = y;
            this.CurrentZ = z;
            this.Player = player;
        }
    }
}
