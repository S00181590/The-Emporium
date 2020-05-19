using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light Sun;
    [SerializeField, Range(0,24)] private float timeofDay;
    [SerializeField] private LightingPreset preset;

    public bool Day;

    private void OnValidate()
    {
        if (Sun != null)
            return;

        if(RenderSettings.sun != null)
        {
            Sun = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    Sun = light;
                    return;
                }
            }
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);

        if(Sun != null)
        {
            Sun.color = preset.LightColor.Evaluate(timePercent);
            Sun.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, -170, 0));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(timeofDay >= 10 && timeofDay <= 24)
        {
            Day = true;
        }
        else
        {
            Day = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (preset == null)
            return;

        if(Application.isPlaying)
        {
            timeofDay += Time.deltaTime;
            timeofDay %= 24; //clamp between 0-24, remember this shiz.
            UpdateLighting(timeofDay / 24f);
        }
        else
        {
            UpdateLighting(timeofDay / 24f);
        }

        if (timeofDay >= 10 && timeofDay <= 24)
        {
            Day = true;
        }
        else
        {
            Day = false;
        }
    }
}
