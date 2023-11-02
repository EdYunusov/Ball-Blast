using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class levelState : MonoBehaviour
{
    [SerializeField] private Cart cart;
    [SerializeField] private StoneSpawner stoneSpawner;

    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;

    private float timer;
    private bool checkPassed;

    private void Awake()
    {
        stoneSpawner.Complited.AddListener(OnSpawnComlited);
        cart.CollisionStone.AddListener(OnCartCollisionStone);
    }


    private void OnDestroy()
    {
        cart.CollisionStone.RemoveListener(OnCartCollisionStone);
        stoneSpawner.Complited.RemoveListener(OnSpawnComlited);
    }

    private void OnSpawnComlited()
    {
        checkPassed = true;
    }

    private void OnCartCollisionStone()
    {
        Defeat.Invoke();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {

        timer += Time.deltaTime;
        
        if(timer > 0.5f)
        {
            if(checkPassed == true)
            {
                if (FindObjectsOfType<Stone>().Length == 0)
                {
                    Passed.Invoke();
                    Time.timeScale = 1;
                }
            }

            timer = 0;
        } 

    }
}
