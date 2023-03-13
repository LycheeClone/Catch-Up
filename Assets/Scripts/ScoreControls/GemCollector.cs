using System;
using UnityEngine;

namespace ScoreControls
{
    public class GemCollector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var gemValue = FindObjectOfType<ScoreKeeper>();
                gemValue.gemCount++;
                print(gemValue.gemCount);
                Destroy(gameObject);
            }
        }
    }
}
