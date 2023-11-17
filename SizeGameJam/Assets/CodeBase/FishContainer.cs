using CodeBase.Behaviour;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase
{
    public class FishContainer : IFishContainer
    {
        List<Fish> fishContainer = new List<Fish>();

        List<FishStats> fishStatsContainer = new List<FishStats>();

        public void AddFishToContainer(Fish fish)
        {
            fishStatsContainer.Add(new FishStats(fish.GetScale()));

            foreach (FishStats fishScale in fishStatsContainer)
            {
                Debug.Log(fishScale.GetScale());
            }
        }

        public void RemoveFishFromContainer(FishStats fish)
        {
            fishStatsContainer.Remove(fish);

            foreach (FishStats fishScale in fishStatsContainer)
            {
                Debug.Log(fishScale.GetScale());
            }
        }
    }

    public class FishStats
    {
        private int _scale;

        public FishStats(int scale)
        {
            _scale = scale;
        }

        public int GetScale()
        {
            return _scale;
        }
    }

    public interface IFishContainer
    {
        void AddFishToContainer(Fish fish);

        void RemoveFishFromContainer(FishStats fish);
    }
}