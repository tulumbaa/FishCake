using CodeBase.Behaviour;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Hooking : MonoBehaviour
    {
        [SerializeField]
        private float _fishingRodPower;
        [SerializeField]
        private float _fishingLineStrenght;
        [SerializeField]
        private float _bait;

        private Fish _catchedFish;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Fish") && !_catchedFish)
            {
                Debug.Log(collision);
                _catchedFish = collision.GetComponent<Fish>();

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

        /*        public IEnumerator HookingUp()
                {

                }*/
    }
}