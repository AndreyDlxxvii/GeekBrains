using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tools : EditorWindow 
{
    private float mySlider = 1.0f;
    private string my2Slider;
    public Color myColor;
    
    [MenuItem("Редактор объектов/ Редактор")]
    public static void ShowTools()
    {
        GetWindow(typeof(Tools), false, "Tools");
    }
    
    void OnGUI()
    {
        myColor = RGBSlider(new Rect(10, 30, 200, 20), myColor);
    }

    
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText)
    {
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);
               
        GUI.Label(labelRect, labelText);   

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height); 
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue); 
        return sliderValue; 
    }

   Color RGBSlider(Rect screenRect, Color rgb)
    {
        
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");
        
       screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "alpha");

        return rgb;
    } 
}
