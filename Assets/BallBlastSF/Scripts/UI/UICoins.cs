using UnityEngine;
using UnityEngine.UI;

public class UICoins : MonoBehaviour
{
    [SerializeField] private Bag bag;
    [SerializeField] private Text text;


    private void Start()
    {
        
        bag.ChangeCounsCounter.AddListener(OnChangeText);
        OnChangeText();
    }

    private void OnDestroy()
    {
        bag.ChangeCounsCounter.RemoveListener(OnChangeText);
    }

    private void OnChangeText()
    {
        text.text = bag.GetCoinsCount().ToString();
    }
}
