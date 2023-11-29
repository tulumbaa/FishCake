using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleCounter : MonoBehaviour
{
    private UniqueScaleContainer _scaleContainer;

    [SerializeField]
    private List<Image> _scaleIcons = new List<Image>();
    [SerializeField]
    private Color _uniqueScaleColor;

    void Start()
    {
        _scaleContainer = FindFirstObjectByType<UniqueScaleContainer>();

        if(_scaleContainer.UniqueScaleAmmout() >= 0)
        {
            for(int i = 0; i <= _scaleContainer.UniqueScaleAmmout(); i++)
            {
                _scaleIcons[i].color = _uniqueScaleColor;
            }
        }
    }
}
