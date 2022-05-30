using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RewardButton : MonoBehaviour
{
    public Image popup;
    private Vector3 startedScale;
    private IEnumerator coroutine;
    private void Start()
    {
        startedScale = transform.localScale;
    }
    public void OpenPopup()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(this.transform.DOPunchScale(startedScale * .22f, .2f)).AppendCallback(DisableButton);
        
       
        
    }
    void DisableButton()
    {
        
        this.GetComponent<Image>().DOFade(0, .1f);
        this.GetComponentInChildren<Text>().DOFade(0, .1f);
        StartCoroutine(Wait());
    }
    public void EnableButton()
    {
        this.GetComponent<Image>().DOFade(1, .1f);
        this.GetComponentInChildren<Text>().DOFade(1, .1f);
        this.transform.DOPunchScale(startedScale * .22f, .3f);
    }
    IEnumerator Wait()
    {     
            yield return new WaitForSeconds(1);
            popup.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
    }

}
