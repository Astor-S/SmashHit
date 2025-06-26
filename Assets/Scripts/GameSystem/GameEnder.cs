using UnityEngine;

namespace GameSystem
{
    public class GameEnder : MonoBehaviour
    {
        [SerializeField] BallShooter _ballShooter;
        [SerializeField] LevelRestarter _levelRestarter;

        private void OnEnable()
        {
            _ballShooter.ProjectilesDepleted += OnGameOver;
        }

        private void OnDisable()
        {
            _ballShooter.ProjectilesDepleted -= OnGameOver;
        }

        private void OnGameOver() =>
            _levelRestarter.RestartLevel();
    }
}