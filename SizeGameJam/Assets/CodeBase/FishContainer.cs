using CodeBase.Behaviour;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase
{
    public class FishContainer : MonoBehaviour, IFishContainer
    {
        private List<Fish> _fishContainer = new List<Fish>();

        private List<FishStats> _fishStatsContainer = new List<FishStats>();

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public List<FishStats> GetFishesStats()
        {
            return _fishStatsContainer;
        }

        public void AddFishToContainer(Fish fish) => 
            _fishStatsContainer.Add(new FishStats(fish.GetScale(), fish.GetSprite()));

        public void RemoveFishFromContainer(FishStats fish) => 
            _fishStatsContainer.Remove(fish);
    }
}