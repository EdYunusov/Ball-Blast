using UnityEngine;
using UnityEngine.Events;

public class Distractable : MonoBehaviour
{
    public int MaxHitPoints;


    [HideInInspector] public UnityEvent Die;
    [HideInInspector] public UnityEvent TakeDamage;
    private int HitPoints;

    private bool IsDie = false;


    private void Start()
    {
        HitPoints = MaxHitPoints;
        TakeDamage.Invoke();
    }
    public void ApplayDamage(int damage)
    {
        HitPoints -= damage;

        TakeDamage.Invoke();

        if (HitPoints <= 0)
        {
            Kill();
        }
    }

    public void ApplayHP (int health)
    {
        HitPoints = HitPoints + health;


        if (HitPoints > MaxHitPoints)
        {
            HitPoints = MaxHitPoints;
        }
    }

    public void Kill()
    {
        if (IsDie == true) return;

        HitPoints = 0;

        IsDie = true;

        TakeDamage.Invoke();
        Die.Invoke();
    }

    public int GetHitPoints()
    {
        return HitPoints;
    }
}
