using Codebase.Infrastructure.States;
using CodeBase.Services.SceneLoader;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string BootScene = "Boot";
        private const string MenuScene = "MenuScene";

        private readonly GameStateMachine _stateMachine;
        private readonly ISceneService _sceneService;

        public BootstrapState(GameStateMachine stateMachine, ISceneService sceneService)
        {
            _stateMachine = stateMachine;
            _sceneService = sceneService;
        }

        public void Enter()
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(BootScene));
            //_sceneService.Load("UI", false, LoadSceneMode.Additive);
            _stateMachine.Enter<LoadLevelState, string>(MenuScene);
        }

        public void Exit()
        {

        }
    }
}