using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HomeScreenUI : MonoBehaviour
{
    public GameObject battleButton;
    private Vector3 originalbattleButtonScale;

    public float scaleUpFactor = 1.1f; // Scale factor when button is clicked
    public float scaleDownFactor = 0f; // Scale factor when button disappears
    public float scalingDuration = 0.3f; // Duration of scaling animations


    void Start()
    {
        originalbattleButtonScale = battleButton.transform.localScale;
    }

    public void BattleStart()
    {
        ScaleButton();
    }

    public void OnBattleEnd()
    {
        ScaleButtonBack();
    }

    void ScaleButton()
    {
        // Create a sequence for button scaling animations
        Sequence sequence = DOTween.Sequence();

        // Scale up
        sequence.Append(battleButton.transform.DOScale(originalbattleButtonScale * scaleUpFactor, scalingDuration).SetEase(Ease.InOutQuad));

        // Wait for scalingDuration seconds
        sequence.AppendInterval(scalingDuration);

        // Scale down
        sequence.Append(battleButton.transform.DOScale(originalbattleButtonScale * scaleDownFactor, scalingDuration).SetEase(Ease.InOutQuad));

        // Wait for scalingDuration seconds
        sequence.AppendInterval(scalingDuration);

        // Set the button inactive
        sequence.AppendCallback(() => battleButton.SetActive(false));
        sequence.AppendCallback(() => BattleManager.OnStartBattle());
        // Play the sequence
        sequence.Play();
    }

    void ScaleButtonBack()
    {
        // Set the button active
        battleButton.SetActive(true);

        // Create a sequence for button scaling animations
        Sequence sequence = DOTween.Sequence();

        // Scale up
        sequence.Append(battleButton.transform.DOScale(originalbattleButtonScale, scalingDuration).SetEase(Ease.InOutQuad));

        // Wait for scalingDuration seconds
        sequence.AppendInterval(scalingDuration);

        // Play the sequence
        sequence.Play();
    }
}
