using GungiBackend.models;

namespace GungiBackend.Services
{
    public interface IPiecePositionService
    {
        //List<Piece> Pieces { get; }
        //void PositionReset();
        List<Piece> CreateInitialPosition();
    }
}
