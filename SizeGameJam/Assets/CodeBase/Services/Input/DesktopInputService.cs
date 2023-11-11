using System;
using UnityEngine;
using Zenject;

namespace Codebase.Services.Input
{
    public class DesktopInputService : IInputService, IInitializable, IDisposable
    {
        private GameInput _gameInput;
        private readonly IGameInputService _gameInputService;

        [Inject]
        public DesktopInputService(GameInput gameInput, IGameInputService gameInputService)
        {
            _gameInput = gameInput;
            _gameInputService = gameInputService;
        }

        public Vector2 Axis =>
			_gameInput.GamePlay.Movement.ReadValue<Vector2>();

        public bool Action =>
            _gameInput.GamePlay.Interact.triggered;

		public void Initialize()
		{
            _gameInputService.Activate(_gameInput.GamePlay);
            _gameInputService.Deactivate(_gameInput.UI);
        }

		public void Dispose()
		{
            _gameInputService.Deactivate(_gameInput.GamePlay);
		}
    }
}