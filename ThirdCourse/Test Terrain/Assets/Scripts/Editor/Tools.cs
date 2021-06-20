using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.Utility;

public class Tools : EditorWindow 
{
    //private float mySlider = 1.0f;
    //private string my2Slider;
    public Color myColor;
    public Vector3 myTrans;
    public MeshRenderer MyMeshRender;
    private float hSliderValue = 0.0f;
    
    [MenuItem("Редактор объектов/ Редактор")]
    public static void ShowTools()
    {
        GetWindow(typeof(Tools), false, "Редактор");
    }
    
    void OnGUI()
    {
        MyMeshRender = (MeshRenderer) EditorGUILayout.ObjectField("Меш", MyMeshRender, typeof(MeshRenderer), true);
        var i = Quaternion.AngleAxis(10f, Vector3.back);
        if (MyMeshRender)
        {
            
            myColor = RGBSlider(new Rect(10, 30, 200, 20), myColor);
            
            myTrans = TransSlider(new Rect(10, 120, 200, 20), myTrans);
            
            MyMeshRender.sharedMaterial.color = myColor;
            MyMeshRender.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(myTrans);
        }
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

   Vector3 TransSlider(Rect screenRect, Vector3 pos)
   {
       
       pos.x = LabelSlider(screenRect, pos.x, 360f, "X rotate");

       screenRect.y += 20;
       pos.y = LabelSlider(screenRect, pos.y, 360f, "Y rotate");

       screenRect.y += 20;
       pos.z = LabelSlider(screenRect, pos.z, 360f, "Z rotate");
       return pos;
   }
}
