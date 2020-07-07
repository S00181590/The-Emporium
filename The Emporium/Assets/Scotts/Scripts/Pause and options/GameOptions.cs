using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions 
{
    public bool FullScreen;
   // public bool VSync;
    public int TextureQuality;
    public int Resolutionindex;
  //  public int DayTimeCycle;
   // public int RenderDistance;
    public float MusicVolume;
    public float Brightness = 0F;

    //void OnGui()
    //{
    //    Brightness = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 50, 90, 100, 30), Brightness, 0f, 1.0f);
    //    RenderSettings.ambientLight = new Color(Brightness, Brightness, Brightness, 1);
    //}
}
