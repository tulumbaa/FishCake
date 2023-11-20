using CodeBase.Logic;
using Zenject;

namespace CodeBase.Installers
{
    public class WalletInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Wallet>().AsSingle().NonLazy();
        }
    }
}