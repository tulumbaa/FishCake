using Codebase.Services.Dialogue;
using Codebase.Services.Input;
using Codebase.Triggers;
using Fungus;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Codebase.Triggers
{
    public class TriggerDialogue : MonoBehaviour, ITriggerDialogueInteraction
    {
        private const float StartButtonAlfa = 0.8f;
        private const float ChosenButtonAlfa = 1.0f;

        [SerializeField]
        private string BlockName = "TestBlock";
        [SerializeField]
        private string MessageToExecuteDialogue = "TestMessage";

        public Flowchart Flowchart;
        public MenuDialog MenuDialog;

        private bool _isPlayerInTrigger;

        private GameInput _gameInput;
        private IGameInputService _gameInputService;
        private IDialogueService _dialogueService;

        private GameObject _sayDialogue;
        private DialogInput _inputDialogue;
        private Button _activeMenuButton;

        private bool _isDialogueInProcess;

        [Inject]
        private void Construct(GameInput gameInput, IGameInputService gameInputService, IDialogueService dialogueService)
        {
            _gameInput = gameInput;
            _gameInputService = gameInputService;
            _dialogueService = dialogueService;
        }

        private void Start()
        {
            _sayDialogue = FindObjectOfType<SayDialog>().gameObject;
            _inputDialogue = _sayDialogue.GetComponent<DialogInput>();
        }

        private void Update()
        {
            if (_isDialogueInProcess)
            {
                _dialogueService.PhraseSliding();

                _dialogueService.SlidingAnswers();

                _dialogueService.EnterTheAnswer();
            }

            DialogueFinished();
        }
        public void PlayerEntered(bool isPlayerInTrigger)
        {
            _isPlayerInTrigger = isPlayerInTrigger;
        }

        public void Interact()
        {
            StartDialogue();
        }

        public void StartDialogue()
        {
            _dialogueService.StartDialogue(Flowchart, MessageToExecuteDialogue, _activeMenuButton, _inputDialogue, MenuDialog);

            _isDialogueInProcess = true;
        }

        public void DialogueFinished()
        {
            if (!_sayDialogue.activeSelf)
            {
                _dialogueService.EndDialogue();
                _isDialogueInProcess = false;
            }
        }
    }
}
