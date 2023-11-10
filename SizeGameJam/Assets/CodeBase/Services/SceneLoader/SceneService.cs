using System;
using UnityEngine.SceneManagement;

namespace CodeBase.Services.SceneLoader
{
    public class SceneService : ISceneService
    {
        public event Action onBegin;
        public event Action onLoaded;
        public event Action onUnloaded;

        public void Load(string sceneName, LoadSceneMode loadMode = LoadSceneMode.Single, Action onComplete = null)
        {
            onBegin?.Invoke();

            var op = SceneManager.LoadSceneAsync(sceneName, loadMode);

            op.completed += _ => onLoaded?.Invoke();
            op.completed += _ => onComplete?.Invoke();
        }

        public void Unload(Scene scene)
        {
            var op = SceneManager.UnloadSceneAsync(scene, UnloadSceneOptions.None);
            op.completed += _ => onUnloaded?.Invoke();
        }
    }
}