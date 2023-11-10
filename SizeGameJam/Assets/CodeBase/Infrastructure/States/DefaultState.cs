using Codebase.Infrastructure.States;
using CodeBase.Services.SceneLoader;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.States
{
    public class DefaultState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneService _sceneService;

        public DefaultState(GameStateMachine stateMachine, ISceneService sceneService)
        {
            _stateMachine = stateMachine;
            _sceneService = sceneService;
        }

        public void Enter()
        {

        }

        public void Exit()
        {
            _sceneService.Unload(SceneManager.GetActiveScene());
        }
    }
}