using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(Distractable))]
public class StoneHitPointShow : MonoBehaviour
{
    [SerializeField] private Text hitPointText;

    private Distractable distractable;

    private void Awake()
    {
        distractable = GetComponent<Distractable>();

        distractable.TakeDamage.AddListener(OnChangeHitPoint);
    }

    private void OnDestroy()
    {
        distractable.TakeDamage.RemoveListener(OnChangeHitPoint);
    }

    private void OnChangeHitPoint()
    {
        int hitPoints = distractable.GetHitPoints();

        if (hitPoints >= 1000) hitPointText.text = hitPoints / 1000 + "K";

        else
            hitPointText.text = hitPoints.ToString();
    }
}
