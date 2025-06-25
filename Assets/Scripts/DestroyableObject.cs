using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destructionParticleEffect;
    [SerializeField] private float _effectLifeTime = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Projectile>(out _))
            Destruct();
    }

    private void Destruct()
    {
        if (_destructionParticleEffect != null)
        {
            _destructionParticleEffect.Play();
            Destroy(gameObject, _effectLifeTime);
        }
    }
}