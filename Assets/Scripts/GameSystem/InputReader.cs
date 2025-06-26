using System;
using UnityEngine;

namespace GameSystem
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private KeyCode _shootKey = KeyCode.Mouse0;

        public event Action Shooting;

        private void Update()
        {
            if (Input.GetKeyDown(_shootKey))
                OnShoot();
        }

        private void OnShoot() =>
            Shooting?.Invoke();
    }
}