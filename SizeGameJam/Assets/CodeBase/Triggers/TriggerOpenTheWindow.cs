using Codebase.Services.Input;
using Codebase.Triggers;
using DG.Tweening;
using System.Collections;
using UnityEngine;
using Zenject;

namespace CodeBase.Triggers
{
    public class TriggerOpenTheWindow : MonoBehaviour, ITrigger
    {
        [SerializeField]
        private RectTransform _window;
        [SerializeField]
        private float _animDuration;

        private IGameInputService _gameInputService;
        private GameInput _gameInput;

        [Inject]
        private void Construct(IGameInputService gameInputService, GameInput gameInput)
        {
            _gameInputService = gameInputService;
            _gameInput = gameInput;
        }

        private void Start()
        {
            _window.localScale = Vector3.zero;
            _window.gameObject.SetActive(false);
        }

        public void Interact()
        {
            _gameInputService.Deactivate(_gameInput.GamePlay);

            _window.gameObject.SetActive(true);
            _window.DOScale(new Vector3(1, 1, 1), _animDuration).SetEase(Ease.OutBounce);
        }

        public void PlayerEntered(bool isPlayerInTrigger)
        {
            
        }

        public void CloseTheWindow()
        {
            Sequence mySequence = DOTween.Sequence();

            _window.DOScale(new Vector3(0, 0, 0), _animDuration).SetEase(Ease.InBounce);

            StartCoroutine(ActivateTheGameplayWhenTweenOver());
        }

        private IEnumerator ActivateTheGameplayWhenTweenOver()
        {
            yield return new WaitForSeconds(_animDuration);

            _window.gameObject.SetActive(false);
            _gameInputService.Activate(_gameInput.GamePlay);
        }
    }
}