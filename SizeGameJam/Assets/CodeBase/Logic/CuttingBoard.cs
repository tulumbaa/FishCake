using Assets.CodeBase;
using UnityEngine;

namespace CodeBase.Logic
{
    public class CuttingBoard : MonoBehaviour
    {
        private const string ScalePath = "Prefabs/Scale";

        [SerializeField]
        private GameObject _cuttingFish;
        [SerializeField]
        private int _ammountOfCommonScales;
        [SerializeField]
        private Color _colorForUniqueScale;

        private IFishContainer _fishContainer;
        private int _currentScale = 0;

        private BoxCollider2D _boxCollider;
        private bool _isCleaning;

        private void Start()
        {
            _fishContainer = FindFirstObjectByType<FishContainer>();
            _boxCollider = _cuttingFish.AddComponent<BoxCollider2D>();
            _boxCollider.isTrigger = true;

            if (_currentScale < _fishContainer.GetFishesStats().Count && !_fishContainer.GetFishesStats()[_currentScale].IsCleaned())
            {
                GetFishInfo();
            }
            else
            {
                _cuttingFish.GetComponent<SpriteRenderer>().sprite = null;
            }
        }

        private void Update()
        {
            CheckClean();

            if(_cuttingFish.transform.childCount == 0 && _isCleaning)
            {
                _fishContainer.GetFishesStats()[_currentScale].Cleaning();

                _currentScale++;

                _isCleaning = false;
            }
        }

        private void CheckClean()
        {
            if (_currentScale < _fishContainer.GetFishesStats().Count && !_fishContainer.GetFishesStats()[_currentScale].IsCleaned() && !_isCleaning)
            {
                GetFishInfo();
            }
        }

        private void GetFishInfo()
        {
            _cuttingFish.GetComponent<SpriteRenderer>().sprite = _fishContainer.GetFishesStats()[_currentScale].GetSprite();

            _fishContainer.GetFishesStats()[_currentScale].SetNewPrice();

            Bounds colliderBounds = _boxCollider.bounds;
            Vector3 colliderCenter = colliderBounds.center;

            ScaleSpawner(_ammountOfCommonScales, colliderBounds, colliderCenter);

            int ammountOfUniqueScales = Random.Range(0, _fishContainer.GetFishesStats()[_currentScale].GetScale());

            if (ammountOfUniqueScales > 0)
            {
                ScaleSpawner(ammountOfUniqueScales, colliderBounds, colliderCenter, true);
            }
        }

        private void ScaleSpawner(int scaleAmmount, Bounds colliderBounds, Vector3 colliderCenter, bool isScaleUnique = false)
        {
            for (int i = 0; i < scaleAmmount; i++)
            {
                float randomX = Random.Range(colliderCenter.x - colliderBounds.extents.x, colliderCenter.x + colliderBounds.extents.x);
                float randomY = Random.Range(colliderCenter.y - colliderBounds.extents.y, colliderCenter.y + colliderBounds.extents.y);

                Vector2 randomPos = new Vector2(randomX, randomY);

                GameObject scale = (GameObject)Instantiate(Resources.Load(ScalePath), randomPos, Quaternion.identity, _cuttingFish.transform);

                if (isScaleUnique)
                {
                    scale.GetComponent<SpriteRenderer>().color = _colorForUniqueScale;
                    scale.GetComponent<Scale>().SetUnique();
                }
            }

            _isCleaning = true;
        }
    }
}