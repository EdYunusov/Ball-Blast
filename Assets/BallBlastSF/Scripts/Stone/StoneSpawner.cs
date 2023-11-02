using UnityEngine;
using UnityEngine.Events;

public class StoneSpawner : MonoBehaviour
{
    [Header("Stone")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;
    

    [Header("Balance")]
    [SerializeField] private Turret turret;
    [SerializeField] public int amount;
    
    [SerializeField] [Range(0.0f, 1.0f)] private float minHpPercentage;
    [SerializeField] private float maxHpRate;

    [Space(10)] public UnityEvent Complited;

    private float timer;
    private float amountSpawn;
    private int stoneMaxHp;
    private int stoneMinHp;
    private bool spawnDone;

    public int Amount
    {
        get
        {
            return amount;
        }
        set
        {
            amount = value;
        }
    }

    private void Start()
    {
        int damagePreSecond = (int)((turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate));

        stoneMaxHp = (int) (damagePreSecond * maxHpRate);
        stoneMinHp = (int) (stoneMaxHp * minHpPercentage);

        timer = spawnRate;
    }

    private void Update()
    {
        if(spawnDone == false)
        {
            timer += Time.deltaTime;

            if (timer >= spawnRate)
            {
                Spawn();

                timer = 0;
            }

            if (amountSpawn == amount)
            {
                enabled = false;

                spawnDone = true;
            }

            Complited.Invoke();
        }

        
    }

    private void Spawn()
    {
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stone.SetSize((Stone.Size)Random.Range(1, 4));
        stone.MaxHitPoints = Random.Range(stoneMinHp, stoneMaxHp + 1);
    }
}
