using GungiBackend.models;
using GungiBackend.Models;

namespace GungiBackend.Services
{
    public interface ISelectPieceService
    {
        List<MoveableRangeModel> GetMoveableLocation(List<Piece> allPieces, SelectPieceModel selectedPiece);
        void ResetMoveableLocation();
    }
}