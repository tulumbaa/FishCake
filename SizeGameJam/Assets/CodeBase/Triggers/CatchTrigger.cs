using CodeBase.Behaviour;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Triggers
{
    public class CatchTrigger : MonoBehaviour
    {
        private IFishContainer _fishContainer;

        [Inject]
        private void Construct(FishContainer fishContainer)
        {
            _fishContainer = fishContainer;
        }

        public void Catch(Fish fish)
        {
            _fishContainer.AddFishToContainer(fish);
        }
    }
}