//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class GreyScale : MonoBehaviour
//{
//    public Image image;
//    void Start()
//    {
//        image = GetComponent<Image>();
//        Color newColor = new Color(0.3f, 0.4f, 0.6f);
//        image.color = newColor;
//        Debug.Log(newColor.grayscale);

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    public float GreyScaler()
//    {
//        Color newColor = new Color(0.3f, 0.4f, 0.6f);
//        return newColor.grayscale;
//    }
//}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// klasa służąca do zmiany obrazka na monochromatyczny
/// </summary>

public class GreyScale : MonoBehaviour
{
    public Material mat;
    /// <summary>obrazek do zamiany</summary>
    Image image; 

    void Start()
    {
        image = GetComponent<Image>();
        //mat.SetFloat("_Power", 1.0f);
        AddGray();

    }

    /// <summary>
    /// Ta metoda zmienia obrazek na szaro
    /// </summary>
    public void AddGray()
    {
        image.material = mat;
    }





    //void OnRenderImage(RenderTexture source, RenderTexture destination)
    //{
    //    Graphics.Blit(source, destination, mat);
    //}
}
