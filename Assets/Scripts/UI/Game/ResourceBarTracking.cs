using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ResourceBarTracking : MonoBehaviour
{
    [Header("Core Settings")]
    [SerializeField] private Image bar;
    [SerializeField] private int resourceCurrent = 100;
    [SerializeField] private int resourceMax = 100;
    [Space]
    [SerializeField] private bool overkillPossible;

    private Coroutine fillRoutine;

    [Header("Animation Speed")] 
    [SerializeField, Range(0.1f, 0.5f)] private float animationTime = 0.25f;

    [Header("Text Settings")]
    [SerializeField] private DisplayType howToDisplayValueText = DisplayType.ShortValue;
    [SerializeField] private TMP_Text resourceValueTextField;
    
    public enum DisplayType
    {
        LongValue,
        ShortValue,
        Percentage,
        None
    }
    
    private void Start()
    {
        UpdateBarAndResourceText();
    }
    
    private void UpdateBarAndResourceText()
    {
        if (resourceMax <= 0)
        {
            bar.fillAmount = 0;
            SetCurrentResourceValueText();
            return;
        }
        float fillAmount = (float) resourceCurrent / resourceMax;
        bar.fillAmount = fillAmount;
        SetCurrentResourceValueText();
    }

    public bool ChangeResourceByAmount(int amount)
    {
        if (!overkillPossible && resourceCurrent + amount < 0)
        {
            return false;
        }
        resourceCurrent += amount;
        resourceCurrent = Mathf.Clamp(resourceCurrent, 0, resourceMax);
        TriggerFillAnimation();
        SetCurrentResourceValueText();
        return true;
    }

    private void TriggerFillAnimation()
    {
        float targetFill = (float) resourceCurrent / resourceMax;
        if (Mathf.Approximately(bar.fillAmount, targetFill))
        {
            return;
        }
        if (fillRoutine != null)
        {
            StopCoroutine(fillRoutine);
        }
        fillRoutine = StartCoroutine(SmoothlyTransitionToNewValue(targetFill));
    }
    
    private IEnumerator SmoothlyTransitionToNewValue(float targetFill)
    {
        float originalFill = bar.fillAmount;
        float elapsedTime = 0f;
        while (elapsedTime < animationTime)
        {
            elapsedTime += Time.deltaTime;
            float time = elapsedTime / animationTime;
            bar.fillAmount = Mathf.Lerp(originalFill, targetFill, time);
            yield return null;
        }
        bar.fillAmount = targetFill;
    }

    private void SetCurrentResourceValueText()
    {
        switch (howToDisplayValueText)
        {
            case DisplayType.LongValue:
                resourceValueTextField.SetText($"{resourceCurrent}/{resourceMax}");
                break;
            case DisplayType.ShortValue:
                resourceValueTextField.SetText($"{resourceCurrent}");
                break;
            case DisplayType.Percentage:
                float percentage = (float)resourceCurrent / resourceMax * 100f;
                resourceValueTextField.SetText($"{Mathf.RoundToInt(percentage)}%");
                break;
            case DisplayType.None:
                resourceValueTextField.SetText(string.Empty);
                break;
        }
    }
}
