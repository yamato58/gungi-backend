using GungiBackend.models;
using GungiBackend.Models;

namespace GungiBackend.Services
{
    public interface IMovePieceService
    {
        void UpdatePosition(List<Piece> allPieces, MovePieceModel movePiece);
    }
}
