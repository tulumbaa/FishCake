using Codebase.Infrastructure.States;
using CodeBase.Services.SceneLoader;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneService _sceneService;

        public LoadLevelState(GameStateMachine stateMachine, ISceneService sceneService)
        {
            _stateMachine = stateMachine;
            _sceneService = sceneService;
        }

        public void Enter(string sceneName)
        {
            // TODO: Enable loader screen
            _sceneService.Load(sceneName, LoadSceneMode.Single, OnLoaded);
        }

        public void Exit()
        {
            // TODO: Disable loader screen
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<DefaultState>();
        }
    }
}