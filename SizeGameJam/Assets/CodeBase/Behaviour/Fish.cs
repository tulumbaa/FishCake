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
        private float _timeToHooking;
        [SerializeField]
        private float _power;
        [SerializeField]
        private float _weight;
        [SerializeField]
        private float _agility;
        [SerializeField]
        private int _scale;

        private int _price;
        private Rigidbody2D _rigidBody;
        private bool _isHooked;

        [Tooltip("Скорость рыбы, когда она убегает после срыва")]
        [SerializeField]
        private float _swimSpeed;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();

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

        public float GetTimeToHook()
        {
            return _timeToHooking;
        }

        public float GetSwimSpeed()
        {
            return _swimSpeed;
        }

        public int GetScale()
        {
            return _scale;
        }

        public Sprite GetSprite()
        {
            return GetComponent<SpriteRenderer>().sprite;
        }

        public void Catched()
        {

        }

        public void CatchedOnHook()
        {
            _isHooked = true;
        }

        public void Slepped()
        {
            _isHooked = false;

            _rigidBody.velocity = new Vector2(0, 0);
        }
    }
}