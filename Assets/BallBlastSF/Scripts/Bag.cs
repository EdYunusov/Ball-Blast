using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    [SerializeField] private Coins coins;
    [SerializeField] private TestUpgradeSctipt upgradeSctipt;
    [SerializeField] private GameObject soundEffect;

    private int CoinCounter;
    public UnityEvent ChangeCounsCounter;


    public int coinCounter
    {
        get
        {
            return CoinCounter;
        }
        set
        {
            CoinCounter = value;
        }
    }

    public void AddCoins(int count)
    {
        CoinCounter += count;
        ChangeCounsCounter.Invoke();
    }

    public void RemoveCoin()
    {
        CoinCounter -= upgradeSctipt.upgradePrise;
        ChangeCounsCounter.Invoke();
    }

    public bool DrawCoins(int count)
    {
        if (CoinCounter - count < 0) return false;

        CoinCounter -= count;
        ChangeCounsCounter.Invoke();

        return true;
    }

    public int GetCoinsCount()
    {
        return CoinCounter;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Coins>() != null)
        {
            Destroy(collision.gameObject);
            AddCoins(4);
            Instantiate(soundEffect);
        }
    }

}
