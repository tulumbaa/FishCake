using CodeBase.Behaviour;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Triggers
{
    public class CatchTrigger : MonoBehaviour
    {
        private IFishContainer _fishContainer;

        private void Start()
        {
            _fishContainer = FindFirstObjectByType<FishContainer>();
        }

        public void Catch(Fish fish)
        {
            _fishContainer.AddFishToContainer(fish);
        }
    }
}