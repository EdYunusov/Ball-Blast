using UnityEngine;

public class TestUpgradeSctipt : MonoBehaviour
{
    
    [SerializeField] public int UpgradePrise;
    [SerializeField] private Bag bag;

    [SerializeField] private Turret turret;

    private int CoinsAmount;

    public int upgradePrise
    {
        get
        {
            return UpgradePrise;
        }
        set
        {
            UpgradePrise = value;
        }
    }

    public void IncreaseDamage()
    {
        CoinsAmount = bag.coinCounter;

        if (bag.coinCounter >= 2)
        {

            bag.coinCounter = CoinsAmount;

            turret.Damage += 1;

            bag.RemoveCoin();
        }
    }

    public void IncreaseFireRate()
    {
        CoinsAmount = bag.coinCounter;

        if (bag.coinCounter >= 2)
        {

            bag.coinCounter = CoinsAmount;

            turret.FireRate -= 0.1f;

            bag.RemoveCoin();
        }

        if(turret.FireRate == 0.1f)
        {
            turret.FireRate = 0.1f;
        }
    }

    public void IncreaseProjectile()
    {
        CoinsAmount = bag.coinCounter;

        if (bag.coinCounter >= 2)
        {

            bag.coinCounter = CoinsAmount;

            turret.ProjectileAmount += 1;

            bag.RemoveCoin();
        }
    }
}