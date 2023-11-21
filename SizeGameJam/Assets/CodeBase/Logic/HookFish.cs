using Assets.CodeBase.Triggers;
using CodeBase.Behaviour;
using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace CodeBase.Logic
{
    public class HookFish : MonoBehaviour
    {
        [SerializeField]
        private float _fishingRodPower;
        [SerializeField]
        private float _fishingLineStrenght;
        [SerializeField]
        private bool _isIenumeratorWorking;

        private Rigidbody2D _rigidBody;

        private Fish _catchedFish;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();

            _rigidBody.mass = _fishingRodPower;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Catch") && _catchedFish)
            {
                collision.GetComponent<CatchTrigger>().Catch(_catchedFish);
                StopCoroutine(Slipping());

                RemoveCathedFish();

                Destroy(_catchedFish.gameObject);
            }
        }

        public void SetCatchedFish(Fish fish)
        {
            _catchedFish = fish;
            _catchedFish.ExpendingTimeToHook(_fishingLineStrenght);

            if(_isIenumeratorWorking)
                StartCoroutine(Slipping());
        }

        private IEnumerator Slipping()
        {
            yield return new WaitForSeconds(_catchedFish.GetTimeToHook());

            RemoveCathedFish();

            _catchedFish.Slepped();
            _catchedFish.GetComponent<DistanceJoint2D>().enabled = false;
            _catchedFish.transform.rotation = new Quaternion(0, 0, 0, 0);
            _catchedFish.GetComponent<Rigidbody2D>().gravityScale = 0;
            _catchedFish.GetComponent<Rigidbody2D>().freezeRotation = true;
            _catchedFish.transform.DOMoveX(_catchedFish.transform.position.x + 20, _catchedFish.GetSwimSpeed(), false).SetEase(Ease.Linear);

            _catchedFish = null;
        }

        private void RemoveCathedFish()
        {
            GetComponentInChildren<Hooking>().RemoveCathedFish();
            GetComponent<DistanceJoint2D>().enabled = false;
            GetComponent<DistanceJoint2D>().connectedBody = null;
        }
    }
}