namespace GungiBackend.Services
{
    public interface ITurnService
    {
        bool CurrentTurn();
        bool CalTurn();
        bool ResetTurn();
    }
}
