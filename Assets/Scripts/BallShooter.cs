using UnityEngine;

public class BallShooter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private float _throwForce = 10f;

    private Pool<Projectile> _projectilePool;

    private void Awake()
    {
        _projectilePool = new Pool<Projectile>(() =>
        {
            Projectile projectile = Instantiate(_projectilePrefab);
            projectile.Initialize(_projectilePool); 
           
            return projectile;
        });
    }

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
        Shoot();
    }

    private void Shoot()
    {
        Projectile projectile = _projectilePool.GetObject();
        projectile.transform.position = transform.position;
        projectile.transform.rotation = Quaternion.identity;
        projectile.gameObject.SetActive(true);

        Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero; 

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 throwDirection = ray.direction.normalized;

        rigidbody.AddForce(throwDirection * _throwForce, ForceMode.Impulse);
    }
}