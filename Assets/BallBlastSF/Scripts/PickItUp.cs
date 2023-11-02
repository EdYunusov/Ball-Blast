using UnityEngine;

public class PickItUp : MonoBehaviour
{
    [SerializeField] private Cart cart;
    [SerializeField] private Coins coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cart cart = collision.transform.root.GetComponent<Cart>();
        //Coins coins = collision.transform.root.GetComponent<Coins>();

        if(cart != null)
        {
            Destroy(coins);
        }    
    }
}
