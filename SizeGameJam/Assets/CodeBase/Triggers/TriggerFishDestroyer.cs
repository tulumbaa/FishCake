using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Triggers
{
    public class TriggerFishDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Fish"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}