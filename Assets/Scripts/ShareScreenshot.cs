using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShareScreenshot : MonoBehaviour
{
    public void Share()
    {
        StartCoroutine(ScreenAndShare());
    }

    private IEnumerator ScreenAndShare()
    {
        yield return new WaitForEndOfFrame();

        // Take a screenshot
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenShot.Apply();

        string screenName = "screenshot_" + DateTime.Now.ToString("ddmmyyhhMMss") + ".png";
        string filePath = Path.Combine(Application.temporaryCachePath, screenName);
        File.WriteAllBytes(filePath, screenShot.EncodeToPNG());

        Destroy(screenShot);

        // Share 
        new NativeShare()
            .AddFile(filePath)
            .SetSubject("Cerealis Coloring AR")
            .SetText("#cerealis #coloring #AR")
            .Share();

    }
}
