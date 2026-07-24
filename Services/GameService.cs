using GungiBackend.models;
using GungiBackend.Models;

namespace GungiBackend.Services
{
    public class GameService : IGameService
    {
        private readonly IPiecePositionService _piecePositionService;
        private readonly ISelectPieceService _selectPieceService;
        private readonly IReplayService _replayService;
        private readonly ITurnService _turnService;
        private readonly IMovePieceService _movePieceService;
        private readonly IGameJudgeService _gameJudgeService;

        public List<Piece> PiecePlacement { get; set; }

        private List<Piece> CopyPiecePlacement { get; set; }

        // コンストラクタ
        public GameService(IPiecePositionService piecePositionService, ISelectPieceService selectPieceService, IReplayService replayService, ITurnService turnService, IMovePieceService movePieceService, IGameJudgeService gameJudgeService)
        {
            _piecePositionService = piecePositionService;
            _selectPieceService = selectPieceService;
            _replayService = replayService;
            _turnService = turnService;
            _movePieceService = movePieceService;
            _gameJudgeService = gameJudgeService;
            PiecePlacement = _piecePositionService.CreateInitialPosition();
            CopyPiecePlacement = PiecePlacement;
        }

        // 初期の駒データ
        public MoveResultModel InitialPosition()
        {
            // 最初の場合のみ呼び出される
            if (_replayService.CountAllPieces() == 0)
            {
                _replayService.ListCreate(PiecePlacement);

                return new MoveResultModel
                {
                    Pieces = PiecePlacement,
                    turn = _turnService.CurrentTurn(),
                    MoveCount = _replayService.MoveMaxCountConfirm(),
                    MaxMoveCount = _replayService.MoveMaxCountConfirm(),
                    GameResult = _gameJudgeService.CalGameJudege(PiecePlacement, _replayService.GetList()),
                };
            }

            // リロード時に呼び出される
            return new MoveResultModel
            {
                //Pieces = PiecePlacement,
                Pieces = this.CopyPiecePlacement,
                turn = _turnService.CurrentTurn(),
                MoveCount = _replayService.ReroadMoveCountConfirm(),
                MaxMoveCount = _replayService.MoveMaxCountConfirm(),
                GameResult = _gameJudgeService.CalGameJudege(PiecePlacement, _replayService.GetList()),
            };
        }

        // 駒のリセット
        public void PositionReset()
        {
            PiecePlacement = _piecePositionService.CreateInitialPosition();
        }

        // 選択された駒の動ける範囲
        public List<MoveableRangeModel> GetMoveableLocation(SelectPieceModel selectedPiece)
        {
            return _selectPieceService.GetMoveableLocation(PiecePlacement, selectedPiece);
        }

        // 範囲のリセット
        public void CellReset()
        {
            _selectPieceService.ResetMoveableLocation();
        }

        // 駒情報を保存するためのListをリセット
        public void AllPiecesListReset()
        {
            _replayService.ResetAllPiecesList();
        }

        // ターン情報をリセット
        public void TurnReset()
        {
            _turnService.ResetTurn();
        }

        // 駒の移動
        public MoveResultModel MovePiece(MovePieceModel movePiece)
        {
            _movePieceService.UpdatePosition(PiecePlacement, movePiece);

            int result = _gameJudgeService.CalGameJudege(PiecePlacement, _replayService.GetList());

            _replayService.ListCreate(PiecePlacement);

            // 結果が勝利または引き分けのときに実行
            if (result != 0)
            {
                _replayService.StartReplay();
            }

            return new MoveResultModel
            {
                Pieces = PiecePlacement,
                turn = _turnService.CalTurn(),
                MoveCount = _replayService.MoveMaxCountConfirm(),
                MaxMoveCount = _replayService.MoveMaxCountConfirm(),
                GameResult = result,
            };
        }

        // リプレイデータの呼び出し
        public MoveResultModel ReplayData(int replayNum)
        {
            this.CopyPiecePlacement = _replayService.ReplayData(replayNum);

            return new MoveResultModel
            {
                Pieces = this.CopyPiecePlacement,
                turn = _turnService.CalTurn(),
                MoveCount = _replayService.ReplayMoveCountConfirm(replayNum),
                MaxMoveCount = _replayService.MoveMaxCountConfirm(),
                GameResult = 0
            };
        }
    }
}
