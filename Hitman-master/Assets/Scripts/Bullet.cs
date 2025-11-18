using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Collider m_bulletCollider;
    [SerializeField] private int m_speed = 5;
    Rigidbody rb;
    void Start()
    {
        m_bulletCollider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * m_speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy")){
            Enemy tempEnemy = collision.collider.GetComponent<Enemy>();
            tempEnemy.Damage(gameObject);
        }
        Destroy(gameObject);
    }
}
