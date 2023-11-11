using UnityEngine.InputSystem;

namespace Codebase.Services.Input
{
    public class GameInputService : IGameInputService
    {
        public void Activate(InputActionMap inputActions)
        {
            inputActions.Enable();
        }

        public void Deactivate(InputActionMap inputActions)
        {
            inputActions.Disable();
        }
    }
}