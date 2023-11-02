using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour
{

    [SerializeField] private Turret turret;
    [SerializeField] private Bag bag;
    [SerializeField] private int maxScores;
    [SerializeField] private int scores;

    private int current_Level = 1;
    public int Current_Level => current_Level;

    void Start()
    {
        Load();
    }

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) == true)
        {
            Reset();
        }

        if (Input.GetKeyDown(KeyCode.F2) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Reset()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("LevelProgress:CurrentLevel", current_Level);
        PlayerPrefs.SetFloat("LevelProgress:Upgrade:FireRate", turret.FireRate);
        PlayerPrefs.SetInt("LevelProgress:Upgrade:Damage", turret.Damage);
        PlayerPrefs.SetInt("LevelProgress:Upgrade:Damage", turret.ProjectileAmount);
        PlayerPrefs.SetInt("LevelProgress:Coins:Count", bag.coinCounter);
        
    }

    private void Load()
    {
        current_Level = PlayerPrefs.GetInt("LevelProgress:CurrentLevel", 1);

        turret.ProjectileAmount = PlayerPrefs.GetInt("LevelProgress:Upgrade:Damage", turret.ProjectileAmount);
        turret.FireRate = PlayerPrefs.GetFloat("LevelProgress:Upgrade:FireRate", turret.FireRate);
        turret.Damage = PlayerPrefs.GetInt("LevelProgress:Upgrade:Damage", turret.Damage);
        bag.coinCounter = PlayerPrefs.GetInt("LevelProgress:Coins:Count", bag.coinCounter);
    }
}
