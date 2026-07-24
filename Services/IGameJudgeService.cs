using GungiBackend.models;

namespace GungiBackend.Services
{
    public interface IGameJudgeService
    {
        int CalGameJudege(List<Piece> allPieces, List<List<Piece>> allPiecesList);
    }
}
