using UnityEngine;

namespace GameSystem
{
    public class LevelMover : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        private void Update()
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}