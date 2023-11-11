using Codebase.Triggers;
using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Triggers
{
    public class TriggerSceneLoader : MonoBehaviour, ITrigger
    {
        private bool _isPlayerInTrigger;

        private GameStateMachine _gameStateMachine;

        public string SceneName;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void PlayerEntered(bool isPlayerInTrigger) => 
            _isPlayerInTrigger = isPlayerInTrigger;

        public void Interact()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(SceneName);
        }
    }
}