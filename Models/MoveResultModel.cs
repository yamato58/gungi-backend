using GungiBackend.models;

namespace GungiBackend.Models
{
    public class MoveResultModel
    {
        public List<Piece> Pieces { get; set; } = new();
        public int GameResult { get; set; }
    }
}