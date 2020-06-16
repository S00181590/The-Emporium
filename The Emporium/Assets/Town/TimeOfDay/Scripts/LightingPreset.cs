using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="Lighting Preset", menuName ="Scriptables/Lighting Presets", order =1)]
public class LightingPreset : ScriptableObject
{
    public Gradient AmbientColor;
    public Gradient LightColor;
    public Gradient FogColor;

}
