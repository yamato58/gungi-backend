namespace GungiBackend.Models
{
    public class MoveableRangeModel
    {
        public int[] moveableLocation { get; set; } // 移動できる座標

        public MoveableRangeModel(int[] moveableLocation)
        {
            this.moveableLocation = moveableLocation;
        }
    }
}
