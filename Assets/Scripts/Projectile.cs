using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3f;

    public event Action<Projectile> Destroyed;

    private Pool<Projectile> _pool;
    private WaitForSeconds _waitLifeTime;

    private void OnEnable()
    {
        _waitLifeTime = new WaitForSeconds(_lifeTime);
        StartCoroutine(DelayedDestroy());
    }

    public void Initialize(Pool<Projectile> pool)
    {
        _pool = pool;
    }

    private IEnumerator DelayedDestroy()
    {
        yield return _waitLifeTime;
        Destroy();
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
        _pool.Release(this);
    }

    private void Destroy()
    {
        Destroyed?.Invoke(this);
        Destroy(gameObject);
    }
}