using Assets.CodeBase;
using CodeBase.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FishSlot : MonoBehaviour
{
    private IWallet _wallet;
    private IFishContainer _fishContainer;
    private FishStats _fishStat;

    private int _fishPrice;

    [SerializeField]
    private Image _fishIcon;

    [SerializeField]
    private TextMeshProUGUI _fishName;
    [SerializeField]
    private TextMeshProUGUI _fishCleaned;
    [SerializeField]
    private TextMeshProUGUI _fishPriceTxt;

    private void Start()
    {
        _wallet = FindFirstObjectByType<Wallet>();
        _fishContainer = FindFirstObjectByType<FishContainer>();
    }

    public void Cell()
    {
        _wallet.AddCoins(_fishPrice);
        _fishContainer.RemoveFishFromContainer(_fishStat);

        Destroy(gameObject);
    }

    public void InstantiateFishSlot(FishStats fishStat)
    {
        _fishStat = fishStat;

        _fishName.text = _fishStat.GetName();
        _fishPrice = _fishStat.GetPrice();
        _fishPriceTxt.text = _fishPrice.ToString();

        _fishIcon.sprite = _fishStat.GetSprite();

        if (_fishStat.IsCleaned())
        {
            _fishCleaned.text = "Yes";
        }
        else
        {
            _fishCleaned.text = "No";
        }
    }
}
