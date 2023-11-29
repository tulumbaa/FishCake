using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class KnifeFollow : MonoBehaviour
{
    private GameInput _gameInput;

    [Inject]
    private void Construct(GameInput gameInput)
    {
        _gameInput = gameInput;
    }

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("KitchenScene");
        }

        Vector3 hookPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);

        transform.position = (new Vector3(Mathf.Clamp(Camera.main.ScreenToWorldPoint(hookPos).x, -6.5f, 6.5f),
                Mathf.Clamp(Camera.main.ScreenToWorldPoint(hookPos).y, -3.5f, 3.5f),
                Camera.main.ScreenToWorldPoint(hookPos).z));
    }
}
