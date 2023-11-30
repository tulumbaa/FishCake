using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Logic
{
    public class MainMenu : MonoBehaviour
    {
        public void StartTheGame()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}