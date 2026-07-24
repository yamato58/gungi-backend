using GungiBackend.models;

namespace GungiBackend.Services
{
    public class ReplayService : IReplayService
    {
        public List<List<Piece>> AllPiecesList { get; set; } = new List<List<Piece>>();

        private int MoveCount = 0;  // 手数
        private int MaxMoveCount = 0;   // 最大手数

        // 駒情報のリストの数
        public int CountAllPieces()
        {
            return AllPiecesList.Count;
        }

        // 駒情報リストのクリア
        public void ResetAllPiecesList()
        {
            AllPiecesList.Clear();
        }

        // 最大手数を返す
        public int MoveMaxCountConfirm()
        {
            MaxMoveCount = AllPiecesList.Count - 1;
            return MaxMoveCount;
        }

        // リロード時に返す手数
        public int ReroadMoveCountConfirm()
        {
            return this.MoveCount;
        }

        // 手数を返す
        public int ReplayMoveCountConfirm(int replayNum)
        {
            return this.MoveCount;
        }

        // 駒情報を入れておくリストを作成
        public void ListCreate(List<Piece> allPieces)
        {
            List<Piece> CopyAllPieces = new();

            for (int i = 0; i < allPieces.Count; i++)
            {
                Piece copyPiece = new Piece
                (
                    allPieces[i].Id,
                    allPieces[i].PieceName,
                    allPieces[i].CurrentX,
                    allPieces[i].CurrentY,
                    allPieces[i].CurrentZ,
                    allPieces[i].Player
                );
                CopyAllPieces.Add(copyPiece);
            }
            AllPiecesList.Add(CopyAllPieces);
        }

        public List<List<Piece>> GetList()
        {
            return AllPiecesList;
        }

        // リプレイで表示させるデータの計算
        public List<Piece> ReplayData(int replayNum)
        {
            if (this.MoveCount < AllPiecesList.Count - 1 || this.MoveCount > 0)
            {
                this.MoveCount += replayNum;
            }

            return AllPiecesList[MoveCount];
        }

        // リプレイ前の準備
        public void StartReplay()
        {
            this.MoveCount = AllPiecesList.Count - 1;
        }
    }
}
