using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeOut : MonoBehaviour
{

    public CanvasGroup UiTextElmnt;

    public IEnumerator FadeCanvas(CanvasGroup cg,float start ,float endtime, float lerptime = 5f)
    {

        float timeStartedLerp = Time.time;
        float TimeSinceStartedCounting = Time.time - timeStartedLerp;
        float perctgeDone = TimeSinceStartedCounting / lerptime;

        while(true)
        {
            TimeSinceStartedCounting = Time.time - timeStartedLerp;
            perctgeDone = TimeSinceStartedCounting / lerptime;

            float currentValue = Mathf.Lerp(start, endtime, perctgeDone);
                cg.alpha = currentValue;
            if(perctgeDone >=1)
            {
                break;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public void FadeIn ()
    {
        StartCoroutine(FadeCanvas(UiTextElmnt, UiTextElmnt.alpha, 1));
    }

    public void FadeOut ()
    {
        StartCoroutine(FadeCanvas(UiTextElmnt, UiTextElmnt.alpha, 0));
    }
}
