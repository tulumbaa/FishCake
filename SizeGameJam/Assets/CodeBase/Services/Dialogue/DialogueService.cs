using Codebase.Services.Input;
using Fungus;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Codebase.Services.Dialogue
{
    public class DialogueService : IDialogueService
    {
        private const float StartButtonAlfa = 0.8f;
        private const float ChosenButtonAlfa = 1.0f;

        private GameInput _gameInput;
        private IGameInputService _gameInputService;

        private Button _activeMenuButton;
        private DialogInput _dialogInput;
        private MenuDialog _menuDialogue;

        private bool _isFirstSliding = true;
        private int _phraseIndex;

        [Inject]
        private void Construct(GameInput gameInput, IGameInputService gameInputService)
        {
            _gameInput = gameInput;
            _gameInputService = gameInputService;
        }

        public void StartDialogue(Flowchart flowchart, string messageName, Button activeMenuButton, DialogInput dialogInput, MenuDialog menuDialog)
        {
            _activeMenuButton = activeMenuButton;
            _dialogInput = dialogInput;
            _menuDialogue = menuDialog;

            _gameInputService.Deactivate(_gameInput.GamePlay);
            _gameInputService.Activate(_gameInput.Dialogues);

            flowchart.SendFungusMessage(messageName);
        }

        public void PhraseSliding()
        {
            if (_gameInput.Dialogues.SlidePhrase.WasPressedThisFrame())
            {
                _dialogInput.SetNextLineFlag();
            }
        }
        
        public void SlidingAnswers()
        {
            if (_gameInput.Dialogues.SlideAnswers.WasPressedThisFrame() && _menuDialogue.IsActive())
            {
                if (_isFirstSliding)
                {
                    _activeMenuButton = _menuDialogue.CachedButtons[0];
                    _activeMenuButton.GetComponent<CanvasGroup>().alpha = ChosenButtonAlfa;

                    _isFirstSliding = false;
                }
                else
                {
                    _phraseIndex += (int)_gameInput.Dialogues.SlideAnswers.ReadValue<Vector2>().y;

                    if (_phraseIndex < 0)
                    {
                        _phraseIndex = _menuDialogue.DisplayedOptionsCount - 1;
                    }
                    else if (_phraseIndex == _menuDialogue.DisplayedOptionsCount)
                    {
                        _phraseIndex = 0;
                    }

                    if (_activeMenuButton)
                    {
                        _activeMenuButton.GetComponent<CanvasGroup>().alpha = StartButtonAlfa;
                    }

                    _activeMenuButton = _menuDialogue.CachedButtons[_phraseIndex];
                    _activeMenuButton.GetComponent<CanvasGroup>().alpha = ChosenButtonAlfa;
                }
            }
        }

        public void EnterTheAnswer()
        {
            if (_gameInput.Dialogues.EnterAnswer.WasPressedThisFrame() && _activeMenuButton)
            {
                _activeMenuButton.GetComponent<CanvasGroup>().alpha = StartButtonAlfa;
                _activeMenuButton.onClick.Invoke();
                _activeMenuButton = null;
            }
        }

        public void EndDialogue()
        {
            _gameInputService.Activate(_gameInput.GamePlay);
            _gameInputService.Deactivate(_gameInput.Dialogues);
        }
    }
}