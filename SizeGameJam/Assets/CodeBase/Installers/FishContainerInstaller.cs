using Assets.CodeBase;
using Zenject;

namespace CodeBase.Installers
{
    public class FishContainerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FishContainer>().AsSingle().NonLazy();
        }
    }
}