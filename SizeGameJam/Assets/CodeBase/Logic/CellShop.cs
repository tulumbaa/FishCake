using Assets.CodeBase;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic
{
    public class CellShop : MonoBehaviour
    {
        public RectTransform CellShopContent;

        private IFishContainer _fishContainer;

        private List<FishStats> _fishStats;

        [Inject]
        private void Construct(IFishContainer fishContainer)
        {
            _fishContainer = fishContainer;
        }

        private void OnEnable()
        {
            _fishStats = _fishContainer.GetFishesStats();
            
            Debug.Log(_fishStats);

            for (int i = 0; i < _fishStats.Count; i++)
            {
                FishSlot fishSlot = Instantiate(Resources.Load("Prefabs/FishSlot"), CellShopContent).GetComponent<FishSlot>();

                fishSlot.InstantiateFishSlot(_fishStats[i].GetScale(), _fishStats[i].GetSprite(), _fishStats[i].IsCleaned());
            }
        }
    }
}