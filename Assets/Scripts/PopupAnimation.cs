using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PopupAnimation : MonoBehaviour
{
    public Button closeBtn;
    public bool rewarded;
    public Button rewardBtn;
    
    private void OnEnable()
    {
        rewarded = true;
        this.transform.DOPunchScale(this.transform.localScale * .22f, .2f);
    }
    private void ClosePopup()
    {
        this.transform.DOScale(Vector3.zero, .2f);
    }
    private void OnDisable()
    {
        rewarded = false;
    }
    public void Close()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(closeBtn.transform.DOPunchScale(closeBtn.transform.localScale * .22f, .2f)).AppendCallback(ClosePopup);
        StartCoroutine(enumerator());
       
    }
    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
        rewardBtn.gameObject.SetActive(true);
        rewardBtn.GetComponent<RewardButton>().EnableButton();
    }
}
