using CodeBase.Behaviour;
using UnityEngine;

namespace Assets.CodeBase.Triggers
{
    public class CatchTrigger : MonoBehaviour
    {
        private IFishContainer _fishContainer;

        [SerializeField]
        private GameObject _fishPlace;

        private void Start()
        {
            _fishContainer = FindFirstObjectByType<FishContainer>();
        }

        public void Catch(Fish fish)
        {
            _fishContainer.AddFishToContainer(fish);

            GameObject fishInTheNet = (GameObject)Instantiate(Resources.Load("Prefabs/FishInTheNet"),
                 _fishPlace.transform.position,
                Quaternion.Euler(0,0, Random.Range(0, 360)), 
                _fishPlace.transform);

            fishInTheNet.GetComponent<SpriteRenderer>().sprite = fish.GetSprite();
        }
    }
}