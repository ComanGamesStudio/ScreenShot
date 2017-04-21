using UnityEngine;
using System.Collections;

public class ScreenShot : MonoBehaviour
{
    public Camera ScreenshotCamera;
    public Material TextureMaterial;

    public void MakeAndSaveScreenShot()
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
        ScreenshotCamera.targetTexture = rt;

        Texture2D myTexture2D =  new Texture2D(rt.width,rt.height);

        ScreenshotCamera.Render();
        RenderTexture.active = rt;

        myTexture2D.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        myTexture2D.Apply();

        ScreenshotCamera.targetTexture = null;
        RenderTexture.active = null;


        TextureMaterial.mainTexture = myTexture2D;
    }
}
