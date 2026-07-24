using GungiBackend.models;
using GungiBackend.Models;

namespace GungiBackend.Services
{
    public interface IGameService
    {
        List<Piece> PiecePlacement { get; }
        MoveResultModel InitialPosition();
        List<MoveableRangeModel> GetMoveableLocation(SelectPieceModel selectedPiece);
        void PositionReset();
        void CellReset();
        void AllPiecesListReset();
        void TurnReset();
        MoveResultModel MovePiece(MovePieceModel movePiece);
        MoveResultModel ReplayData(int replayNum);
    }
}
