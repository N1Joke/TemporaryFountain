using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] private RectTransform _boy;
    [SerializeField] private RectTransform _infoTab;
    [SerializeField] private RectTransform _buttonStart;
    [SerializeField] private float _delayBetweenAnimations;

    public void ShowStartIntro()
    {
        StartCoroutine(StartIntro());
    }

    public void HideStartIntro()
    {
        StartCoroutine(HideIntro());
    }

    private IEnumerator StartIntro()
    {
        Vector3 startPosBoy = _boy.anchoredPosition;
        Vector3 startPosInfoTab = _infoTab.anchoredPosition;
        Vector3 startPosButtonStart = _buttonStart.anchoredPosition;

        _boy.anchoredPosition = Vector3.left * 2000f;
        _infoTab.anchoredPosition = Vector3.right * 2000f;
        _buttonStart.anchoredPosition = Vector3.down * 1000f;

        yield return new WaitForEndOfFrame();

        LeanTween.move(_boy, startPosBoy, _delayBetweenAnimations).setEaseInOutSine();
        yield return new WaitForSeconds(_delayBetweenAnimations);

        LeanTween.move(_infoTab, startPosInfoTab, _delayBetweenAnimations).setEaseInOutSine();
        yield return new WaitForSeconds(_delayBetweenAnimations);

        LeanTween.move(_buttonStart, startPosButtonStart, _delayBetweenAnimations).setEaseInOutSine();
        yield return new WaitForSeconds(_delayBetweenAnimations);
    }

    private IEnumerator HideIntro()
    {
        yield return new WaitForEndOfFrame();

        LeanTween.move(_boy, Vector3.left * 2000f, _delayBetweenAnimations).setEaseInOutSine();
        yield return new WaitForSeconds(_delayBetweenAnimations);

        LeanTween.move(_infoTab, Vector3.right * 2000f, _delayBetweenAnimations).setEaseInOutSine();
        yield return new WaitForSeconds(_delayBetweenAnimations);

        LeanTween.move(_buttonStart, Vector3.down * 1000f, _delayBetweenAnimations).setEaseInOutSine();
        yield return new WaitForSeconds(_delayBetweenAnimations);

        gameObject.SetActive(false);
    }
}
