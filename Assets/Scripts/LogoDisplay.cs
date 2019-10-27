using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoDisplay : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup FadeSystemLogo;

    [SerializeField]
    private CanvasGroup MainMenuUI;

    private float LoadTime;
    private float MinimumTime = 3f;
    private float LoadingButtonsSpeed = 0.5f;

    // Start is called before the first frame update
    private void Start()
    {
        FadeSystemLogo.alpha = 1;
        MainMenuUI.alpha = 0;

        if (Time.time < MinimumTime)
        {
            LoadTime = MinimumTime;
        }
        else
        {
            LoadTime = Time.time;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //fade in
        if (Time.time < MinimumTime)
        {
            FadeSystemLogo.alpha = 1 - Time.time;
        }

        //fade out
        if (Time.time > MinimumTime && LoadTime != 0)
        {
            FadeSystemLogo.alpha = Time.time - MinimumTime;

            if (FadeSystemLogo.alpha >= 1 && MainMenuUI.alpha < 1)
            {
                MainMenuUI.alpha += LoadingButtonsSpeed * Time.deltaTime;
            }
        }
    }
}
