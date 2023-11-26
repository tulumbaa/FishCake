using Assets.CodeBase;
using Codebase.Services.Input;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic
{
    public class SellShop : MonoBehaviour
    {
        public RectTransform SlotParentContent;

        private IFishContainer _fishContainer;

        private void OnEnable()
        {
            _fishContainer = FindFirstObjectByType<FishContainer>();

            Debug.Log(_fishContainer);

            List<FishStats> fishStats = _fishContainer.GetFishesStats();

            for (int i = 0; i < fishStats.Count; i++)
            {
                FishSlot fishSlot = Instantiate(Resources.Load("Prefabs/FishSlot"), SlotParentContent).GetComponent<FishSlot>();

                fishSlot.InstantiateFishSlot(fishStats[i]);
            }
        }
    }
}