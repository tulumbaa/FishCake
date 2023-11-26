using Assets.CodeBase.Triggers;
using CodeBase.Behaviour;
using UnityEngine;

namespace CodeBase.Logic
{
    public class HookFish : MonoBehaviour
    {
        private FishRodStats _fishRodStats;

        private Rigidbody2D _rigidBody;

        private Fish _catchedFish;

        private void Start()
        {
            _fishRodStats = FindFirstObjectByType<FishRodStats>();

            _rigidBody = GetComponent<Rigidbody2D>();

            _rigidBody.mass = _fishRodStats.GetRodPower();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Catch") && _catchedFish)
            {
                collision.GetComponent<CatchTrigger>().Catch(_catchedFish);

                Destroy(_catchedFish.gameObject);
                _catchedFish = null;
            }
        }

        public void SetCatchedFish(Fish fish)
        {
            _catchedFish = fish;
            _catchedFish.ExpendingTimeToHook(_fishRodStats.GetLineStrenght());
            _catchedFish.CatchedOnHook();
        }

        public void RemoveCathedFish()
        {
            GetComponentInChildren<Hooking>().RemoveCathedFish();
            GetComponent<DistanceJoint2D>().enabled = false;
            GetComponent<DistanceJoint2D>().connectedBody = null;
        }
    }
}