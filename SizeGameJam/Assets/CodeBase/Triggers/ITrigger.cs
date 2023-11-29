namespace Codebase.Triggers
{
    public interface ITrigger
    {
        void PlayerEntered(bool isPlayerInTrigger);

        void Interact();
    }

    public interface ITriggerDialogueInteraction : ITrigger
    {
        void StartDialogue();

        void DialogueFinished();
    }
}