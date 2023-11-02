using UnityEngine;
using UnityEngine.UI;
public class UI_progressBar : MonoBehaviour
{
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private StoneSpawner stoneSpawner;

    [SerializeField] private Image progressBar;

    private float fillAmountStep;
    private int stoneAmount;

    private void Start()
    {
        progressBar.fillAmount = 0;
        fillAmountStep = 1 / stoneSpawner.Amount;
    }

    private void Update()
    {
        if(stoneSpawner.Amount == fillAmountStep)
        {
            progressBar.fillAmount += fillAmountStep;
        }
    }

}
