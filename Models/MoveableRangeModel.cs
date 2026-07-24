namespace GungiBackend.Models
{
    public class MoveableRangeModel
    {
        public int[] MoveableLocation { get; set; } // 移動できる座標

        public MoveableRangeModel(int[] moveableLocation)
        {
            this.MoveableLocation = moveableLocation;
        }
    }
}
