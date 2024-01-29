using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HomeScreenUI : MonoBehaviour
{
    public GameObject battleButton;
    public GameObject bottomNavbar;
    public GameObject CurrencyManager;
    private Vector3 originalbattleButtonScale;


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
        sequence.Append(battleButton.transform.DOScale(originalbattleButtonScale * GlobalConstants.buttonScaleUpFactor, GlobalConstants.buttonscalingDuration).SetEase(Ease.InOutQuad));

        // Wait for scalingDuration seconds
        sequence.AppendInterval(GlobalConstants.buttonscalingDuration);

        // Scale down
        sequence.Append(battleButton.transform.DOScale(originalbattleButtonScale * GlobalConstants.buttonscaleDownFactor, GlobalConstants.buttonscalingDuration).SetEase(Ease.InOutQuad));

        // Wait for scalingDuration seconds
        sequence.AppendInterval(GlobalConstants.buttonscalingDuration);

        // Set the button inactive
        sequence.AppendCallback(() => battleButton.SetActive(false));
        sequence.AppendCallback(() => BattleManager.OnStartBattle());
        sequence.AppendCallback(() => bottomNavbar.SetActive(false));
        sequence.AppendCallback(() => CurrencyManager.SetActive(true));
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
        sequence.Append(battleButton.transform.DOScale(originalbattleButtonScale, GlobalConstants.buttonscalingDuration).SetEase(Ease.InOutQuad));

        // Wait for scalingDuration seconds
        sequence.AppendInterval(GlobalConstants.buttonscalingDuration);
        sequence.AppendCallback(() => bottomNavbar.SetActive(true));
        sequence.AppendCallback(() => CurrencyManager.SetActive(false));

        // Play the sequence
        sequence.Play();
    }
}
