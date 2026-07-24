using GungiBackend.models;

namespace GungiBackend.Services
{
    public interface IReplayService
    {
        int MoveMaxCountConfirm();
        int ReroadMoveCountConfirm();
        int ReplayMoveCountConfirm(int replayNum);
        int CountAllPieces();
        void StartReplay();
        void ListCreate(List<Piece> allPieces);
        void ResetAllPiecesList();
        List<Piece> ReplayData(int replayNum);
        List<List<Piece>> GetList();
    }
}
