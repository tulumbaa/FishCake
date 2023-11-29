using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private const string ScaleTag = "Scale";

    private UniqueScaleContainer _scaleContainer;

    private void Start()
    {
        _scaleContainer = FindFirstObjectByType<UniqueScaleContainer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ScaleTag))
        {
            collision.GetComponent<Scale>().Cleaned();

            if (collision.GetComponent<Scale>().GetUnique())
            {
                _scaleContainer.AddUniqueScale();
            }
        }
    }
}
