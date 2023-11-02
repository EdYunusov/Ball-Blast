using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    private int damage;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Distractable distractable = collision.transform.root.GetComponent<Distractable>();

        if (distractable != null)

        {
            distractable.ApplayDamage(damage);
        }

        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

}
