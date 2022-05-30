using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class RandomReward : MonoBehaviour
{
    public float duration;
    public float textDuration;
    public Ease ease;
    public Ease sliderEase;
    public int startRange;
    public int endRange;
    public PopupAnimation popupAnimation;
    [SerializeField] private Text text;

    [SerializeField] private Slider slider;
 
    private int quantity;

    private void Start()
    {
        slider.maxValue = endRange;
        slider.minValue = startRange;
        quantity=Random.Range(startRange, endRange);
        StartCoroutine(enumerator());
    }
    public void DisplayReward()
    {
        if (popupAnimation.rewarded)
        {
            Debug.Log(quantity);
            text.DOText(quantity.ToString(), 3f, false, ScrambleMode.Numerals, "0123456789").From("0").SetEase(ease);
            slider.DOValue(quantity, 2f).SetEase(sliderEase);
        }
    }
    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1);
        DisplayReward();
    }
}
