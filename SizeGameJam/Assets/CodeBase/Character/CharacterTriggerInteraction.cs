using Codebase.Triggers;
using UnityEngine;
using Zenject;

namespace Codebase.Character
{
    public class CharacterTriggerInteraction : MonoBehaviour
    {
        private const string InteractionTriggerTag = "InteractionTrigger";
        [SerializeField]
        private GameObject _signIcon;

        private ITrigger _trigger;
        private GameInput _gameInput;

        [Inject]
        private void Construct(GameInput gameInput)
        {
            _gameInput = gameInput;
        }

        private void Start()
        {
            _signIcon.SetActive(false);
        }

        private void Update()
        {
            if (_trigger != null && _gameInput.GamePlay.Interact.WasPressedThisFrame())
            {
                _trigger.Interact();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GetTrigger(collision, true);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            GetTrigger(collision, false);
        }

        private void GetTrigger(Collider2D collision, bool isPlayerInTrigger)
        {
            if (collision.CompareTag(InteractionTriggerTag))
            {
                _signIcon.SetActive(isPlayerInTrigger);

                _trigger = collision.GetComponent<ITrigger>();

                _trigger.PlayerEntered(isPlayerInTrigger);
            }
        }
    }
}