﻿using Codebase.Infrastructure.States;
using CodeBase.Services.SceneLoader;
using System;
using System.Collections.Generic;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachine : IInitializable
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneService sceneService)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneService),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneService),
                [typeof(DefaultState)] = new DefaultState(this, sceneService)
            };
        }

        public void Initialize()
        {
            Enter<BootstrapState>();
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}