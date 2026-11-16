using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public AnimationCurve curve;
    float timer;
    bool screenState;

    void Start()
    {
        screenState = false;
    }


    void Update()
    {

        if (screenState)
        {
            FadeScreenIn();
        }
        if (!screenState)
        {
            FadeScreenOut();
        }

    }

    void FadeScreenIn()
    {
        float x = curve.Evaluate(timer -  Time.time);
        GetComponent<RectTransform>().sizeDelta = new Vector2(x * 2000, x * 2000);
    }

    void FadeScreenOut()
    {
        float x = curve.Evaluate(1 -(timer - Time.time));
        GetComponent<RectTransform>().sizeDelta = new Vector2(x * 2000, x * 2000);
    }

    public void TriggerFade(bool state)
    {
        if (state)
        {
            timer = Time.time + 1;
            screenState = true;
        }
        else
        {
            timer = Time.time + 1;
            screenState = false;
        }
    }
}
