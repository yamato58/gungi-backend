using GungiBackend.models;

namespace GungiBackend.Services
{
    public class GameJudgeService : IGameJudgeService
    {
        // 勝敗判定の計算
        public int CalGameJudege(List<Piece> allPieces, List<List<Piece>> allPiecesList)
        {
            // データ分ループ
            foreach (Piece piece in allPieces)
            {
                if (piece.PieceName == "帥" && piece.CurrentX == 10)
                {
                    if (piece.Player)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            if (DrawJudge(allPiecesList))
            {
                return 3;
            }
            return 0;
        }

        // 引き分けの計算
        public bool DrawJudge(List<List<Piece>> allPiecesList)
        {
            List<Piece> currentBoard = allPiecesList[allPiecesList.Count - 1];

            int judgeCount = 0;

            for (int i = 0; i < allPiecesList.Count; i++)
            {
                if (IsCompareBoard(currentBoard, allPiecesList[i]))
                {
                    judgeCount++;
                }
            }

            return judgeCount >= 4;
        }

        // 現在の盤と過去の盤が同じかどうかの比較
        public bool IsCompareBoard(List<Piece> currentBoard, List<Piece> PastBoard)
        {
            for (int i = 0; i < currentBoard.Count; i++)
            {
                if (currentBoard[i].Id != PastBoard[i].Id
                    || currentBoard[i].CurrentX != PastBoard[i].CurrentX
                    || currentBoard[i].CurrentY != PastBoard[i].CurrentY
                    || currentBoard[i].CurrentZ != PastBoard[i].CurrentZ)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
