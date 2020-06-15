using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    private bool IsGameLoading;
    public static LoadingScreen Instance;
    AsyncOperation currentLoadingTask;
    private RectTransform barfillrect;
    private Vector3 barfillscale;

    [SerializeField] Text percentLoadedText;


    private void Awake()
    {
        if (Instance == null)
        {
            //when the game is loading wont destory the loading screen 
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        barfillscale = barfillrect.localScale;

    }

    private void Update()
    {
        if (IsGameLoading)
        {
            SetGameProgress(currentLoadingTask.progress);//updating the proggres bar in ui 
        }

        if (currentLoadingTask.isDone)
        {
            HideLoadingUI();//turning off ui when finished loading s
        }
    }


    private void SetGameProgress(float progress)
    {
        barfillscale.x = progress;
        barfillrect.localScale = barfillscale;

        percentLoadedText.text = Mathf.CeilToInt(progress + 100).ToString() + "%";
    }


    private void ShowLoadingScence(AsyncOperation loadingScenceOperation)
    {
        gameObject.SetActive(true);//turns on loading screen
        currentLoadingTask = loadingScenceOperation;

        SetGameProgress(0f);//restarts the loading bar

        IsGameLoading = true;
    }

    public void HideLoadingUI()
    {
        gameObject.SetActive(false);
        currentLoadingTask = null;
        IsGameLoading = false;

    }
}
