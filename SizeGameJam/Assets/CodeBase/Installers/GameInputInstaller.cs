using Zenject;
using Codebase.Services.Input;

namespace Codebase.Installers
{
    public class GameInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DesktopInputService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameInputService>().AsSingle().NonLazy();
        }
    }
}