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

        private void OnEnable()
        {
            _fishContainer = FindFirstObjectByType<FishContainer>();

            List<FishStats> fishStats = _fishContainer.GetFishesStats();
            
            Debug.Log(fishStats);
            Debug.Log(fishStats.Count);

            for (int i = 0; i < fishStats.Count; i++)
            {
                FishSlot fishSlot = Instantiate(Resources.Load("Prefabs/FishSlot"), CellShopContent).GetComponent<FishSlot>();
                Debug.Log(fishStats[i].GetScale());
                Debug.Log(fishStats[i].GetSprite());

                fishSlot.InstantiateFishSlot(fishStats[i].GetScale(), fishStats[i].GetSprite(), fishStats[i].IsCleaned());
            }
        }
    }
}