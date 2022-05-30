using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class ClaimReward : MonoBehaviour
{
    private Image img;
    private Text text;
   public Text notification;
    bool enable;
    Vector3 startedScale;
    Vector3 startedPosition;
    // Start is called before the first frame update
    void Start()
    {
      img= GetComponent<Image>();
      text = transform.GetChild(0).GetComponent<Text>();
     
        
    }
    private void OnEnable()
    {
        enable = true;
        startedScale = transform.localScale;
        startedPosition = transform.localPosition;
        notification.transform.localScale = Vector3.zero;
    }

   public void PressButton()
    {
        if (!enable)
        {
            CantClaim();
        }
        else
        {
            Claim();
        }
    }

    private void Claim()
    {
        notification.text = "You got reward!!";
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOPunchScale(startedScale * .22f, .2f));
        img.DOFade(.2f, .2f);
        text.DOFade(.2f, .2f);
        notification.transform.DOScale(new Vector3(1, 1, 1), .1f);
        enable = false;

    }

    private void CantClaim()
    {
        notification.text = "You already got the reward!!";
        notification.transform.DOShakePosition(.1f, 2, 1, 2, false,false);
        transform.DOPunchScale(startedScale * .22f, .2f);
        Debug.Log("Cant");
    }
    void ResetButton()
    {
     
    }
}
