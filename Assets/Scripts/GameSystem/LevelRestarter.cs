using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystem
{
    public class LevelRestarter : MonoBehaviour
    {
        [SerializeField] private LevelLoader _levelLoader;

        public void RestartLevel()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            StartCoroutine(_levelLoader.LoadLevelAsync(currentSceneName));
        }
    }
}