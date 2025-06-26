using UnityEngine;
using TMPro;

namespace Counters
{
    public class ProjectileCounter : MonoBehaviour
    {
        private readonly string _sympolSpace = " ";

        [SerializeField] private BallShooter _ballShooter;
        [SerializeField] private TextMeshProUGUI _projectileCountText;

        private void Update()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (_projectileCountText != null)
                _projectileCountText.text = _sympolSpace + _ballShooter.CurrentProjectileCount;
        }
    }
}