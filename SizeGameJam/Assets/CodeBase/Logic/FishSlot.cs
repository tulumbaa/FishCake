using CodeBase.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FishSlot : MonoBehaviour
{
    private IWallet _wallet;

    private int _fishPrice;
    private TextMeshProUGUI _fishPriceTxt;

    private Image _fishIcon;

    private TextMeshProUGUI _fishCleaned;

    [Inject]
    private void Construct(IWallet wallet)
    {
        _wallet = wallet;
    }

    public void Cell()
    {
        _wallet.AddCoins(_fishPrice);

        Destroy(gameObject);
    }

    public void InstantiateFishSlot(int fishPrice, Sprite fishIcon, bool isFishCleaned)
    {
        _fishPrice = fishPrice;
        _fishPriceTxt.text = _fishPrice.ToString();

        _fishIcon.sprite = fishIcon;

        if (isFishCleaned)
        {
            _fishCleaned.text = "Yes";
        }
        else
        {
            _fishCleaned.text = "No";
        }
    }
}
