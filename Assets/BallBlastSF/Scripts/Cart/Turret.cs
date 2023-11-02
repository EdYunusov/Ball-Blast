using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject fire_sound;
    [SerializeField] private float fireRate;
    [SerializeField] private int projectileAmount;
    [SerializeField] private float projectileInterval;
    [SerializeField] private int damage;

    public float FireRate
    {
        get
        {
            return fireRate;
        }
        set
        {
            fireRate = value;
        }
    }
    public int ProjectileAmount
    {
        get
        {
            return projectileAmount;
        }
        set
        {
            projectileAmount = value;
        }
    }
    public float Interval
    {
        get
        {
            return projectileInterval;
        }
        set
        {
            projectileInterval = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }


    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void SpawnProjectile()
    {
        float startPosX = shootPoint.position.x - projectileInterval * (projectileAmount - 1) * 0.5f;

        for (int i = 0; i < projectileAmount; i++)
        {
            Projectile projectile = Instantiate(projectilePrefab, new Vector3(startPosX + i * projectileInterval, shootPoint.position.y, shootPoint.position.z), transform.rotation);
            projectile.SetDamage(damage);
        }
    }

    public void Fire()
    {
        if(timer >= fireRate)
        {
            SpawnProjectile();

            timer = 0;
            Instantiate(fire_sound);
        }
    }
}
