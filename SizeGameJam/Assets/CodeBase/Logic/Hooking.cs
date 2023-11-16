using CodeBase.Behaviour;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Hooking : MonoBehaviour
    {
        private Fish _catchedFish;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Fish") && !_catchedFish)
            {
                _catchedFish = collision.GetComponent<Fish>();

                transform.parent.GetComponent<HookFish>().SetCatchedFish(_catchedFish);

               transform.parent.GetComponent<DistanceJoint2D>().enabled = true;
                _catchedFish.GetComponent<DistanceJoint2D>().enabled = true;
                transform.parent.GetComponent<DistanceJoint2D>().connectedBody = _catchedFish.GetComponent<Rigidbody2D>();
                _catchedFish.GetComponent<DistanceJoint2D>().connectedBody = transform.parent.GetComponent<Rigidbody2D>();
                transform.parent.GetComponent<DistanceJoint2D>().connectedAnchor = transform.position - _catchedFish.transform.position;
                _catchedFish.GetComponent<DistanceJoint2D>().connectedAnchor = transform.position - _catchedFish.transform.position;

                _catchedFish.GetComponent<Rigidbody2D>().gravityScale = 0.3f;

                _catchedFish.transform.DOPause();

                _catchedFish.CatchedOnHook();
            }
        }

        public void RemoveCathedFish()
        {
            _catchedFish = null;
        }
    }
}