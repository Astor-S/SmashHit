using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3f;

    private Pool<Projectile> _pool;
    private WaitForSeconds _waitLifeTime;
    private Coroutine _lifeTimeCoroutine;

    private void OnEnable()
    {
        _waitLifeTime = new WaitForSeconds(_lifeTime);
        StartCoroutine(DelayedDestroy());
    }

    private void OnDisable()
    {
        if (_lifeTimeCoroutine != null)
        {
            StopCoroutine(_lifeTimeCoroutine);
            _lifeTimeCoroutine = null;
        }
    }

    public void Initialize(Pool<Projectile> pool) =>
        _pool = pool;

    private IEnumerator DelayedDestroy()
    {
        yield return _waitLifeTime;
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
        _pool.Release(this);
    }
}