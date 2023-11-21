using CodeBase.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FishSlot : MonoBehaviour
{
    private IWallet _wallet;

    private int _fishPrice;
    [SerializeField]
    private TextMeshProUGUI _fishPriceTxt;

    [SerializeField]
    private Image _fishIcon;

    [SerializeField]
    private TextMeshProUGUI _fishCleaned;

    private void Start()
    {
        _wallet = FindFirstObjectByType<Wallet>();
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

        Debug.Log(fishPrice);

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
