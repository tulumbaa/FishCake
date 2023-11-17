using CodeBase.Behaviour;
using UnityEngine;

namespace CodeBase.Logic
{
    public class QTEReader : MonoBehaviour
    {
        private GameInput _gameInput;

        private void Construct(GameInput gameInput) => 
            _gameInput = gameInput;

        private void Test(Fish fish)
        {
            _gameInput.HookingQTE.Enable();
            var bindings = _gameInput.HookingQTE.AnyKeyReader.bindings.ToArray();


        }
    }
}