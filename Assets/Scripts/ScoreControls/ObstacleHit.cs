using UnityEngine;

namespace ScoreControls
{
    public class ObstacleHit : MonoBehaviour
    {

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                var gemAmount = FindObjectOfType<ScoreKeeper>();
                gemAmount.gemCount--;
                print(gemAmount.gemCount);

                // var ScoreAmount = FindObjectOfType<ScoreKeeper>();
                // ScoreAmount.score++;
                // print(ScoreAmount.score);

            }
        }
    }
}