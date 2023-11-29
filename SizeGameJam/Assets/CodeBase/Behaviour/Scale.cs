using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    Vector2 _flyDirection = Vector2.zero;

    private bool _isUnique;

    [SerializeField]
    private float _timeToDestroy = 5;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Cleaned()
    {
        _flyDirection.x = Random.Range(-8f, 8f);
        _flyDirection.y = Random.Range(-2.5f, 4f);

        _rigidBody.AddForce(_flyDirection, ForceMode2D.Impulse);
        _rigidBody.gravityScale = 1;

        _boxCollider.enabled = false;
        transform.parent = null;

        Destroy(gameObject, _timeToDestroy);
    }

    public void SetUnique() 
    {
        _isUnique = true;
    }

    public bool GetUnique()
    {
        return _isUnique;
    }
}
