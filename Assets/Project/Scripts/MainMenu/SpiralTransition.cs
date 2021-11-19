using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpiralTransition : SingletonComponent<SpiralTransition>
{
    [SerializeField] private List<Image> sections;
    [SerializeField] private float delayBetweenSlides, fillSpeed;
    [SerializeField] private GameObject tips;


    public UnityEvent OnTransitionFinishedOpening;
    public UnityEvent OnTransitionFinishedClosing;
    public UnityEvent OnTransitionStartedOpening;
    public UnityEvent OnTransitionStartedClosing;

    public void Open()
    {
        StartCoroutine(OpenTransition());
    }
    public void Close()
    {
        StartCoroutine(CloseTransition());
    }

    IEnumerator OpenTransition()
    {
        OnTransitionStartedOpening?.Invoke();
        for (int i = 0; i < sections.Count; i++)
        {
            StartCoroutine(StartSection(sections[i], true));
            yield return new WaitForSeconds(delayBetweenSlides);
        }
        yield return new WaitForSeconds(1/fillSpeed);

        tips.SetActive(true);
        OnTransitionFinishedOpening?.Invoke();

        yield return null;
    }

    IEnumerator StartSection(Image section, bool opening)
    {
        if(opening)
        {
            section.fillClockwise = true;
            section.gameObject.SetActive(true);
            while(section.fillAmount < 1)
            {
                section.fillAmount += Time.deltaTime * fillSpeed;
                yield return null;
            }
        }
        else // close
        {
            section.fillClockwise = false;
            while (section.fillAmount != 0)
            {
                section.fillAmount -= Time.deltaTime * fillSpeed;
                yield return null;
            }
            section.gameObject.SetActive(false);
        }

        yield return null;
    }

    IEnumerator CloseTransition()
    {
        OnTransitionStartedClosing?.Invoke();
        tips.SetActive(false);
        //reset all
        for (int i = sections.Count-1; i >= 0; i--)
        {

            StartCoroutine(StartSection(sections[i], false));
            yield return new WaitForSeconds(delayBetweenSlides);
        }
        OnTransitionFinishedClosing?.Invoke();
        yield return null;
    }
}
