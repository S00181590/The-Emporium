using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuOptions : MonoBehaviour
{
    public GameObject OptionUI, MMUi;

    public Animator menuAnim;

    private List<Image> uiItems = new List<Image>();

    private List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

    // Start is called before the first frame update
    void Start()
    {
       uiItems.AddRange(MMUi.GetComponentsInChildren<Image>());

        texts.AddRange(MMUi.GetComponentsInChildren<TextMeshProUGUI>());

        foreach(TextMeshProUGUI t in texts)
        {
            t.alpha = 0f;
        }

        foreach(Image i in uiItems)
        {
            i.color = new Color(i.color.r,i.color.g, i.color.b, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(menuAnim.GetBool())

        foreach(Image i in uiItems)
        {
            if(i.gameObject.name == "MenuPanel")
            {

            }
            else
            {
                if(i.color.a < 1)
                {
                    i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + 0.01f);
                }
            }

        }

        foreach(TextMeshProUGUI t in texts)
        {
            t.alpha += 0.02f;
        }
    }

    public void OpenOptions()
    {
        MMUi.SetActive(false);

        Instantiate(OptionUI, MMUi.transform.parent, false);
    }
}
