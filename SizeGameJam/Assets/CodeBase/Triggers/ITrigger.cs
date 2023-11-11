namespace Codebase.Triggers
{
    public interface ITrigger
    {
        void PlayerEntered(bool isPlayerInTrigger);

        void Interact();
    }
}