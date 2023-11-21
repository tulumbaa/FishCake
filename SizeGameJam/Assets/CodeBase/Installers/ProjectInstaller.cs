using Assets.CodeBase;
using Codebase.Services.Input;
using CodeBase.Infrastructure.States;
using CodeBase.Services.SceneLoader;
using Zenject;

namespace CodeBase.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SceneService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameInput>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameInputService>().AsSingle().NonLazy();
        }
    }
}