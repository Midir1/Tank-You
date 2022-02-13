using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;

    public float speed;

    public bool isMegaBullet;

    private Rigidbody _rigidbody;

    private const string TankTag = "Tank";

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    public void Initialize()
    {
        if (!isMegaBullet)
        {
            var localDirection = transform.rotation.y * -transform.right;
            
            _rigidbody.velocity = localDirection.normalized * speed;
        }
        else
        {
            var localDirection = transform.rotation.z * transform.up;
            
            _rigidbody.velocity = localDirection.normalized * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TankTag) && other.transform != transform)
        {
            var tankEnemy = other.gameObject.GetComponent<TankManager>();
            
            tankEnemy.TakeDamage(damage);
            
            Destroy(gameObject);
        }
        else if (other.transform != transform)
        {
            Destroy(gameObject);
        }
    }
}