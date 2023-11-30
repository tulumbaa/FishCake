using Fungus;
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

    private Flowchart _flowchart;

    void Start()
    {
        Cursor.visible = true;

        _flowchart = FindFirstObjectByType<Flowchart>();

        _scaleContainer = FindFirstObjectByType<UniqueScaleContainer>();

        if(_scaleContainer.UniqueScaleAmmout() >= 0)
        {
            for(int i = 0; i <= _scaleContainer.UniqueScaleAmmout(); i++)
            {
                _scaleIcons[i].color = _uniqueScaleColor;
            }
        }

        if(_scaleContainer.UniqueScaleAmmout() == 7)
        {
            _flowchart.SetBooleanVariable("IsTheWholeScalesCollected", true);
        }
    }
}
