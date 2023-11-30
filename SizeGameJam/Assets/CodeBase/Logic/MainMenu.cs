using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Logic
{
    public class MainMenu : MonoBehaviour
    {
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}