using System;
using UnityEngine.SceneManagement;

namespace CodeBase.Services.SceneLoader
{
    public interface ISceneService
    {
        event Action onBegin;
        event Action onLoaded;
        event Action onUnloaded;
        void Load(string sceneName, LoadSceneMode loadMode = LoadSceneMode.Single, Action onLoaded = null);
        void Unload(Scene scene);
    }
}