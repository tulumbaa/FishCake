using CodeBase.Behaviour;
using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public partial class FishSpawner : MonoBehaviour
    {
        [Header("Fish stats")]
        [SerializeField]
        private float _minSpawnDelay;
        [SerializeField]
        private float _maxSpawnDelay;

        [SerializeField]
        private Fish _fishToSpawn;

        [Tooltip("Speed")]
        [SerializeField]
        private float _swimSpeed;
        private float _swimDirection;

        [Header("Fish behaviour")]
        [SerializeField]
        private bool _isActive;
        [SerializeField]
        private float _shakeDuration;
        [SerializeField]
        private float _shakeStrenght;
        [SerializeField]
        private int _shakeVibro;
        [SerializeField]
        private int _shakeRandomness;
        [SerializeField]
        private bool _shakeSnapping = false;
        [SerializeField]
        private bool _shakeFadeOut = true;

        void Start()
        {
            StartCoroutine(FishSpawning());

            _swimDirection = transform.position.x;
        }

        private IEnumerator FishSpawning()
        {
            while (true)
            {
                float spawnDelay = Random.Range(_minSpawnDelay, _maxSpawnDelay);

                yield return new WaitForSeconds(spawnDelay);

                Sequence mySequence = DOTween.Sequence();

                GameObject newFish = Instantiate(_fishToSpawn.gameObject, transform.position, Quaternion.identity);

                newFish.transform.DOMoveX(_swimDirection * -1, _swimSpeed, false).SetEase(Ease.Linear);
                if (_isActive)
                {
                    mySequence.Join(newFish.transform.DOShakePosition(_shakeDuration, _shakeStrenght, _shakeVibro, _shakeRandomness, _shakeSnapping, _shakeFadeOut));
                }
            }
        }
    }
}