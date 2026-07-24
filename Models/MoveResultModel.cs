using GungiBackend.models;

namespace GungiBackend.Models
{
    public class MoveResultModel
    {
        public List<Piece> Pieces { get; set; } = new();
        public bool turn { get; set; }
        public int MoveCount { get; set; }
        public int MaxMoveCount { get; set; }
        public int GameResult { get; set; }
    }
}