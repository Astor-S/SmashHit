using UnityEngine;

public class BallShooter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.Shooting += OnShooting;
    }

    private void OnDisable()
    {
        _inputReader.Shooting -= OnShooting;
    }

    private void OnShooting()
    {
        Debug.Log("выстрел!");
    }
}