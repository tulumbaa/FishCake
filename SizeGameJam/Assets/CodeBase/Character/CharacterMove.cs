using Codebase.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Character
{
    public class CharacterMove : MonoBehaviour
    {
        public float MovementSpeed;

        private IInputService _inputService;
        private Rigidbody2D _body2D;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _body2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _body2D.velocity = MovementSpeed * _inputService.Axis;
        }
    }
}