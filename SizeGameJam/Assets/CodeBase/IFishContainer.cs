using CodeBase.Behaviour;
using System.Collections.Generic;

namespace Assets.CodeBase
{
    public interface IFishContainer
    {
        List<FishStats> GetFishesStats();

        void AddFishToContainer(Fish fish);

        void RemoveFishFromContainer(FishStats fish);
    }
}