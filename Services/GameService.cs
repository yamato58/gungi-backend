using GungiBackend.models;

namespace GungiBackend.Services
{
    public class GameService
    {
        // 駒の情報を入れるリスト
        public List<Piece> allPieces { get; set; } = new List<Piece>();

        public GameService()
        {
            initialPosition();
        }

        // 駒の初期配置をListに追加
        public void initialPosition()
        {
            // 先手
            allPieces.Add(new Piece(1, "帥", 4, 8, 1, true));
            allPieces.Add(new Piece(2, "大", 3, 8, 1, true));
            allPieces.Add(new Piece(3, "中", 5, 8, 1, true));
            allPieces.Add(new Piece(4, "小", -1, -1, 1, true));
            allPieces.Add(new Piece(5, "小", -1, -1, 1, true));
            allPieces.Add(new Piece(6, "侍", 3, 6, 1, true));
            allPieces.Add(new Piece(7, "侍", 5, 6, 1, true));
            allPieces.Add(new Piece(8, "槍", 4, 7, 1, true));
            allPieces.Add(new Piece(9, "槍", -1, -1, 1, true));
            allPieces.Add(new Piece(10, "槍", -1, -1, 1, true));
            allPieces.Add(new Piece(11, "馬", 7, 7, 1, true));
            allPieces.Add(new Piece(12, "馬", -1, -1, 1, true));
            allPieces.Add(new Piece(13, "忍", 1, 7, 1, true));
            allPieces.Add(new Piece(14, "忍", -1, -1, 1, true));
            allPieces.Add(new Piece(15, "砦", 2, 6, 1, true));
            allPieces.Add(new Piece(16, "砦", 6, 6, 1, true));
            allPieces.Add(new Piece(17, "兵", 0, 6, 1, true));
            allPieces.Add(new Piece(18, "兵", 4, 6, 1, true));
            allPieces.Add(new Piece(19, "兵", 8, 6, 1, true));
            allPieces.Add(new Piece(20, "兵", -1, -1, 1, true));
            allPieces.Add(new Piece(21, "弓", 2, 7, 1, true));
            allPieces.Add(new Piece(22, "弓", 6, 7, 1, true));

            // 後手
            allPieces.Add(new Piece(23, "帥", 4, 0, 1, false));
            allPieces.Add(new Piece(24, "大", 5, 0, 1, false));
            allPieces.Add(new Piece(25, "中", 3, 0, 1, false));
            allPieces.Add(new Piece(26, "小", -1, -1, 1, false));
            allPieces.Add(new Piece(27, "小", -1, -1, 1, false));
            allPieces.Add(new Piece(28, "侍", 3, 2, 1, false));
            allPieces.Add(new Piece(29, "侍", 5, 2, 1, false));
            allPieces.Add(new Piece(30, "槍", 4, 1, 1, false));
            allPieces.Add(new Piece(31, "槍", -1, -1, 1, false));
            allPieces.Add(new Piece(32, "槍", -1, -1, 1, false));
            allPieces.Add(new Piece(33, "馬", 1, 1, 1, false));
            allPieces.Add(new Piece(34, "馬", -1, -1, 1, false));
            allPieces.Add(new Piece(35, "忍", 7, 1, 1, false));
            allPieces.Add(new Piece(36, "忍", -1, -1, 1, false));
            allPieces.Add(new Piece(37, "砦", 2, 2, 1, false));
            allPieces.Add(new Piece(38, "砦", 6, 2, 1, false));
            allPieces.Add(new Piece(39, "兵", 0, 2, 1, false));
            allPieces.Add(new Piece(40, "兵", 4, 2, 1, false));
            allPieces.Add(new Piece(41, "兵", 8, 2, 1, false));
            allPieces.Add(new Piece(42, "兵", -1, -1, 1, false));
            allPieces.Add(new Piece(43, "弓", 2, 1, 1, false));
            allPieces.Add(new Piece(44, "弓", 6, 1, 1, false));
        }
    }
}
