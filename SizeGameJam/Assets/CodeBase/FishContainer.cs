using CodeBase.Behaviour;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase
{
    public class FishContainer : IFishContainer
    {
        private List<Fish> _fishContainer = new List<Fish>();

        private List<FishStats> _fishStatsContainer = new List<FishStats>();

        public List<FishStats> GetFishesStats()
        {
            return _fishStatsContainer;
        }

        public void AddFishToContainer(Fish fish)
        {
            _fishStatsContainer.Add(new FishStats(fish.GetScale(), fish.GetSprite()));

            foreach (FishStats fishScale in _fishStatsContainer)
            {
                Debug.Log(fishScale.GetScale());
            }
        }

        public void RemoveFishFromContainer(FishStats fish)
        {
            _fishStatsContainer.Remove(fish);

            foreach (FishStats fishScale in _fishStatsContainer)
            {
                Debug.Log(fishScale.GetScale());
            }
        }
    }
}