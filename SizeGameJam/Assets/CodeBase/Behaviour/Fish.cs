using CodeBase.Logic;
using DG.Tweening;
using Fungus;
using System.Collections;
using UnityEngine;

namespace CodeBase.Behaviour
{
    public class Fish : MonoBehaviour, IFish
    {
        private const int HookingPerSecond = 10;

        [SerializeField]
        private string _name;
        [SerializeField]
        private int _price;
        [SerializeField]
        private int _scale;
        [SerializeField]
        private float _power;
        [SerializeField]
        private float _weight;
        [SerializeField]
        private float _timeToHooking;

        private Rigidbody2D _rigidBody;
        private bool _isHooked;

        private HookFish _hookFish;

        [Tooltip("Скорость рыбы, когда она убегает после срыва")]
        [SerializeField]
        private float _swimSpeed;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();

            _hookFish = FindFirstObjectByType<HookFish>();

            _rigidBody.mass = _weight;
        }

        private void Update()
        {
            if (_isHooked)
            {
                _rigidBody.velocity = new Vector2(Random.Range(-10, 10), _power * -1 * Random.Range(1, _power));
            }
        }
        
        public void ExpendingTimeToHook(float addtionalTime)
        {
            _timeToHooking += addtionalTime;
        }

        public float GetTimeToHook() => 
            _timeToHooking;

        public float GetSwimSpeed() => 
            _swimSpeed;

        public int GetScale() => 
            _scale;

        public Sprite GetSprite() => 
            GetComponent<SpriteRenderer>().sprite;

        public string GetName() => 
            _name;

        public int GetPrice() => 
            _price;

        public void Catched()
        {

        }

        public void CatchedOnHook()
        {
            StartCoroutine(Slipping());
            _isHooked = true;
        }

        public void Slepped()
        {
            _isHooked = false;

            _rigidBody.velocity = new Vector2(0, 0);

            GetComponent<DistanceJoint2D>().enabled = false;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().freezeRotation = true;
            transform.DOMoveX(transform.position.x + 20, GetSwimSpeed(), false).SetEase(Ease.Linear);

            _hookFish.RemoveCathedFish();
        }

        public IEnumerator Slipping()
        {
            yield return new WaitForSeconds(_timeToHooking);

            Slepped();
        }

    }
}