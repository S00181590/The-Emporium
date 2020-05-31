using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLight : MonoBehaviour
{
    bool On = false;
    bool day;
    GameObject Sun;
    public GameObject Light,selfLight;
    Material panelMat, lightMat;
    //Light light;
    DayNightCycle cycle;

    // Start is called before the first frame update
    void Start()
    {
        Sun = GameObject.Find("Town");

        cycle = Sun.GetComponent<DayNightCycle>();

        day = cycle.Day;

        Organise();
    }

    // Update is called once per frame
    void Update()
    {
        day = cycle.Day;

        if(day == true)
        {
            On = false;
        }
        else
        {
            On = true;
        }

        SwitchOn();
    }

    void Organise()
    {
        //light = gameObject.GetComponentInChildren<Light>();

        panelMat = GetComponentInChildren<MeshRenderer>().material;

    }

    void SwitchOn()
    {
        if (On == true)
        {
            //if(Light.activeSelf == false)
            //{
            //    Light.SetActive(true);
            //}
            //else
            //{
                FadeIn(Light);
            FadeIn(selfLight);
            //}
        }
        else
        {
            //if(Light.activeSelf == true)
            //{
            //    Light.SetActive(false);
            //}
            //else
            //{
                FadeOut(Light);
            FadeOut(selfLight);
            //}
        }
        
    }

    void FadeOut(GameObject l)
    {
        if(l.name == "Enviro")
        {
            if (l.GetComponent<Light>().intensity > 0f)
            {
                l.GetComponent<Light>().intensity -= 10 * Time.deltaTime;
            }
        }
        else
        {
            if (l.GetComponent<Light>().intensity > 0f)
            {
                l.GetComponent<Light>().intensity -= 0.5f * Time.deltaTime;
            }
        }
        

    }

    void FadeIn(GameObject l)
    {
        if(l.name == "Enviro")
        {
            if (l.GetComponent<Light>().intensity < 40f)
            {
                l.GetComponent<Light>().intensity += 10f * Time.deltaTime;
            }
        }
        else
        {
            if(l.GetComponent<Light>().intensity < 2f)
            {
                l.GetComponent<Light>().intensity += 0.5f * Time.deltaTime;
            }
        }

        
    }
}
