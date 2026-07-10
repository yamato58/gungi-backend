using GungiBackend.models;

namespace GungiBackend.Services
{
    public class GameJudgeService
    {
        public List<List<Piece>> allPiecesList { get; set; } = new List<List<Piece>>();

        public int CalGameJudege(List<Piece> allPieces)
        {
            // データ分ループ
            foreach (Piece piece in allPieces)
            {
                if (piece.pieceName == "帥" && piece.currentX == 10)
                {
                    if (piece.player)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else if (DrawJudge(allPieces))
                {
                    return 3;
                }
            }
            return 0;
        }

        public bool DrawJudge(List<Piece> allPieces)
        {
            for (int i = 0; i < allPieces.Count; i++)
            {
                allPiecesList.Add(allPieces);
                //Console.WriteLine(allPiecesList);
            }
            //Console.WriteLine(allPiecesList[0][0]);
            return false;
        }
    }
}
