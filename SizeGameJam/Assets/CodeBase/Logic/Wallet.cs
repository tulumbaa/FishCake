using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Logic
{
    public class Wallet : MonoBehaviour, IWallet
    {
        //[SerializeField] 
        private int _coins;

        private TextMeshProUGUI _coinsAmmountTxt;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            Debug.Log(_coins);

            if(SceneManager.GetActiveScene().name == "GameScene" && !_coinsAmmountTxt) 
            {
                _coinsAmmountTxt = GameObject.FindGameObjectWithTag("CoinsAmmountTxt").GetComponent<TextMeshProUGUI>();

                _coinsAmmountTxt.text = _coins.ToString();
            }
        }

        public int GetCoins() =>
            _coins;

        public void AddCoins(int addtiveCoins)
        {
            _coins += addtiveCoins;

            _coinsAmmountTxt.text = _coins.ToString();
        }

        public void SubstractCoins(int removeCoins)
        {
            _coins -= removeCoins;

            _coinsAmmountTxt.text = _coins.ToString();
        }
    }
}