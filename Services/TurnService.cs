namespace GungiBackend.Services
{
    public class TurnService : ITurnService
    {
        bool turn = Random.Shared.NextDouble() >= 0.5;  // 先行か後攻ランダム

        // 現在のターン
        public bool CurrentTurn()
        {
            return this.turn;
        }

        // ターン変更時の計算
        public bool CalTurn()
        {
            return this.turn = !this.turn;
        }

        // ターンをリセット
        public bool ResetTurn()
        {
            return this.turn = Random.Shared.NextDouble() >= 0.5;
        }
    }
}