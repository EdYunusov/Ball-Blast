using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(CoinsMovement))]
public class Coins : Distractable
{
    [SerializeField] private Stone stone;
    

    [SerializeField] private float LifeTime;
    [SerializeField] private float spawnUpForce;

    public CoinsMovement movement;

    private void Awake()
    {
        movement = GetComponent<CoinsMovement>();
        Die.AddListener(OnCoinsDestroyed);
    }

    private void OnCoinsDestroyed()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Die.RemoveListener(OnCoinsDestroyed);
    }

    public void CoinsSpawn(Vector3 position)
    {
        for (int i = 0; i < 1; i++)
        {
            Coins coins = Instantiate(this, position, Quaternion.identity);
            coins.movement.AddVerticalVelosity(spawnUpForce);
            coins.movement.SetHorizontalDirection((i % 2 * 2) - 1);
        }

    }

}