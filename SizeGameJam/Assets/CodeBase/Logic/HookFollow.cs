using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.CodeBase.Logic
{
    public class HookFollow : MonoBehaviour
    {
        [SerializeField]
        private float _followingDuration = 3;
        [SerializeField]
        private float maxDepth;

        private Rigidbody2D _rigidBody;

        private GameInput _gameInput;

        [Inject]
        private void Construct(GameInput gameInput)
        {
            _gameInput = gameInput;
        }

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Yes");

                SceneManager.LoadScene("GameScene");
            }

            Vector3 hookPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);

            _rigidBody.DOMove(new Vector3(Mathf.Clamp(Camera.main.ScreenToWorldPoint(hookPos).x, -8f, 8f),
                Mathf.Clamp(Camera.main.ScreenToWorldPoint(hookPos).y, maxDepth * -1, 3),
                Camera.main.ScreenToWorldPoint(hookPos).z),
                _followingDuration, false);
        }
    }
}