using UnityEngine;

public class LoopRepeater : MonoBehaviour
{
    [SerializeField] private float _loopStartThreshold = -100f;
    [SerializeField] private  float _loopLength = 150f;

    private void Update()
    {
        EnviromentCheckup();
    }

    private void EnviromentCheckup()
    {
        Vector3 worldPosition = transform.position;

        if (worldPosition.z < _loopStartThreshold) 
            RepeatLoop(worldPosition);
    }

    private void RepeatLoop(Vector3 worldPosition)
    {
        worldPosition.z += _loopLength;
        transform.position = worldPosition;
    }
}