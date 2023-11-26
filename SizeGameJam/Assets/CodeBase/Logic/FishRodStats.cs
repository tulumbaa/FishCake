using System.Collections;
using UnityEngine;

namespace CodeBase.Logic
{
    public class FishRodStats : MonoBehaviour
    {
        [SerializeField]
        private int _fishingRodPower;
        [SerializeField]
        private int _fishingLineStrenght;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public int GetRodPower()
        {
            return _fishingRodPower;
        }

        public int GetLineStrenght()
        {
            return _fishingLineStrenght;
        }

        public void UpgrageRodPower(int additiveRodPower)
        {
            _fishingRodPower += additiveRodPower;
        }

        public void UpgrageLineStrenght(int additiveLineStrenght)
        {
            _fishingLineStrenght += additiveLineStrenght;
        }
    }
}