using UnityEngine;

public class UniqueScaleContainer : MonoBehaviour
{
    private int _uniqueScaleAmmout = -1;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void AddUniqueScale()
    {
        if (_uniqueScaleAmmout + 1 <= 7)
        {
            _uniqueScaleAmmout++;
        }
    }

    public int UniqueScaleAmmout() => 
        _uniqueScaleAmmout;
}
