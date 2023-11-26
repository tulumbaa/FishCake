using TMPro;
using UnityEngine;

namespace CodeBase.Logic
{
    public class UpgradeSlot : MonoBehaviour
    {
        private FishRodStats _fishRodStats;
        private IWallet _wallet;

        [SerializeField]
        private string _upgradeStatName;

        [SerializeField]
        private int _upgradePrice;
        [SerializeField]
        private int _upgradeStep;

        private int _currentUpgrade;

        [SerializeField]
        private TextMeshProUGUI _upgradePriceTxt;
        [SerializeField]
        private TextMeshProUGUI _currentUpgradeTxt;
        [SerializeField]
        private TextMeshProUGUI _nextLineStrenghtTxt;

        void Start()
        {
            _upgradePriceTxt.text = _upgradePrice.ToString();

            _fishRodStats = FindFirstObjectByType<FishRodStats>();
            _wallet = FindFirstObjectByType<Wallet>();

            switch (_upgradeStatName)
            {
                case "Rod Power":
                    _currentUpgrade = _fishRodStats.GetRodPower();
                    break;

                case "Line Strenght":
                    _currentUpgrade = _fishRodStats.GetLineStrenght();
                    break;
            }

            _currentUpgradeTxt.text = _currentUpgrade.ToString();
            _nextLineStrenghtTxt.text = (_currentUpgrade + _upgradeStep).ToString();
        }

        public void Unpgrade()
        {
            if(_wallet.GetCoins() >= _upgradePrice)
            {
                switch (_upgradeStatName)
                {
                    case "Rod Power":
                        _fishRodStats.UpgrageRodPower(_upgradeStep);
                        _currentUpgrade = _fishRodStats.GetRodPower();
                        break;

                    case "Line Strenght":
                        _fishRodStats.UpgrageLineStrenght(_upgradeStep);
                        _currentUpgrade = _fishRodStats.GetLineStrenght();
                        break;
                }

                _currentUpgradeTxt.text = _currentUpgrade.ToString();
                _nextLineStrenghtTxt.text = (_currentUpgrade + _upgradeStep).ToString();

                _wallet.SubstractCoins(_upgradePrice);
            }
        }
    }
}