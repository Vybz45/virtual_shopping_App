using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
   
   public  bool unbi;
    public bool inTr;
    float raa;
    public bool camr;
    public GameObject ca;
    public Text ouyroRo;
    public Text yroAttitude;
    public Text upintr;
    public Text accelr;
    public Text camRot;

    public InputField xof;
   public InputField yof;
    public InputField zof;
    public InputField subtThis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gyroscope gyro = Input.gyro;
        gyro.enabled = true;
        if (inTr) {
           
           // gameObject.transform.eulerAngles -= gyro.rotationRate;
        }
        if (unbi)
        {
           
            //gameObject.transform.eulerAngles += gyro.rotationRateUnbiased;
        }
        if (camr)
        {
            // Quaternion a = new Quaternion(gyro.attitude.x *- 90f, gyro.attitude.y *- 90f, gyro.attitude.z *- 90f, gyro.attitude.w*-90f);
            //ca.transform.rotation = a;
            Vector3 gyrAttiEuler = gyro.attitude.eulerAngles;
            Vector3 gayroAttToworld = new Vector3(gyrAttiEuler.x ,gyrAttiEuler.y,gyrAttiEuler.z);
            float axf=0,ayf=0,azf=0;
            /*
            float axi = gayroAttToworld.x;
            if (axi > 270) {
                axf = (axi + 90) - 360;
            }
            else
            {
                axf = axi + 90;
                
            }
            axf = axf * -1;*/
            int _yoff, _xoff, _zoff,_subd;
            int.TryParse(xof.text,out _xoff);
            int.TryParse(yof.text, out _yoff);
            int.TryParse(zof.text, out _zoff);
            int.TryParse(subtThis.text, out _subd);

            ayf = gayroAttToworld.y*-1;
            //azf = gayroAttToworld.z+_zoff;
            azf = gayroAttToworld.z;
            //  axf = oriant(gayroAttToworld.x, _xoff, -1, 270, _subd);
            axf = gayroAttToworld.x*-1;
            ca.transform.eulerAngles = new Vector3(axf,ayf,azf);

            float pox, poy, poz;
            if (gyro.userAcceleration.x > 0.1 || gyro.userAcceleration.x < -0.1)
            {
                pox = gyro.userAcceleration.x;
            }
            else { pox = 0; }
            if (gyro.userAcceleration.y > 0.1 || gyro.userAcceleration.y < -0.1)
            {
                poy = gyro.userAcceleration.y;
            }
            else { poy = 0; }
            if (gyro.userAcceleration.z > 0.1 || gyro.userAcceleration.z< -0.1)
            {
                poz = gyro.userAcceleration.z;
            }
            else { poz = 0; }
            ca.transform.position += new Vector3(pox,poy,poz);

            string outGireoRotRa = "Rotation Rate : " + gyro.rotationRate.ToString();
            string outgyroAttitude = "Attitude : " + gyro.attitude.eulerAngles.ToString();
            string outgyroUpdaIntv = "update Interval : " + gyro.updateInterval.ToString();
            string outgyroAccl = "accelr : " + gyro.userAcceleration.ToString();
            string camROtation = "camera rot : " + ca.transform.position.ToString();
            
            
            ouyroRo.text = outGireoRotRa;
                yroAttitude.text=outgyroAttitude;
                 upintr.text= outgyroUpdaIntv;
                 accelr.text= outgyroAccl;
            camRot.text = camROtation;

        }

    }
    public void reset()
    {
        ca.transform.eulerAngles = new Vector3(13, 0, 0);
        camr = !camr;
        gameObject.transform.eulerAngles = new Vector3(0,0,0);
        ca.transform.position = new Vector3(0, 0, 0);
    }
    public float oriant(float ainit,int ofsset,int axissign,int intGratThanThis,int subtractThis)
    {
        float ai = ainit;
        float af;
        if (ai > intGratThanThis&&subtractThis!=0)
        {
            af = (ai + ofsset) - subtractThis;
        }
        else
        {
            af = ai + ofsset;

        }
        af = af * axissign;
        return af;
    }
}
