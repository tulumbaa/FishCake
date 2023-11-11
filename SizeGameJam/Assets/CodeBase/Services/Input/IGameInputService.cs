using UnityEngine.InputSystem;

namespace Codebase.Services.Input
{
    public interface IGameInputService
    {
        void Activate(InputActionMap inputActions);
        void Deactivate(InputActionMap inputActions);
    }
}