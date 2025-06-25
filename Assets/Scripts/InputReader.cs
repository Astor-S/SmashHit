using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _shootKey = KeyCode.Mouse0;

    public event Action Shooting;

    private void Update()
    {
        if(Input.GetKey(_shootKey))
            OnMove();
    }

    private void OnMove() =>
        Shooting?.Invoke();
}