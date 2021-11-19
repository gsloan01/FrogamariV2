using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpiralTransition : SingletonComponent<SpiralTransition>
{
    [SerializeField] private List<Image> sections;
    [SerializeField] private float delayBetweenSlides, fillSpeed;
    [SerializeField] GameObject tips;

    public UnityEvent OnTransitionFinishedOpening;

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
        //reset all
        for (int i = 0; i < sections.Count; i++)
        {
            StartSection(sections[i], true);
            yield return new WaitForSeconds(delayBetweenSlides);
        }

        tips.SetActive(true);
        OnTransitionFinishedOpening.Invoke();
        yield return null;
    }

    IEnumerator StartSection(Image section, bool open)
    {
        if(open)
        {
            section.fillClockwise = true;
            section.gameObject.SetActive(true);
            while(section.fillAmount != 1)
            {
                section.fillAmount += Time.deltaTime * fillSpeed;
            }
        }
        else // close
        {
            section.fillClockwise = false;
            while (section.fillAmount != 0)
            {
                section.fillAmount -= Time.deltaTime * fillSpeed;
            }
            section.gameObject.SetActive(false);
        }

        yield return null;
    }

    IEnumerator CloseTransition()
    {
        tips.SetActive(false);
        //reset all
        for (int i = 0; i < sections.Count; i++)
        {

            StartSection(sections[i], true);
            yield return new WaitForSeconds(delayBetweenSlides);
        }
        yield return null;
    }
}
