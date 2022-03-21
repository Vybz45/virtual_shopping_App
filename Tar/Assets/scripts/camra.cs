using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camra : MonoBehaviour
{
    public Text textInput;
    public InputField textOutput;
    WebCamTexture WebCam;
    Texture texture;
    int i=0;
   public  RawImage backgr;
    AspectRatioFitter fit;
    // Start is called before the first frame update
    void Start()
    {
//       

      
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CameraBackgroundPlay(){
         int.TryParse(textInput.text, out i);
          WebCamDevice[] dev =  WebCamTexture.devices;
        if (dev.Length != 0)
        {
             WebCam = new WebCamTexture(dev[i].name, Screen.width, Screen.height,30);
             
                WebCam.Play();
                backgr.texture = WebCam;
                
            
           
        }
    }
}
