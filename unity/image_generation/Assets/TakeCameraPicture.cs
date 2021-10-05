using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCameraPicture : MonoBehaviour
{
    public GameObject prefab;
    public GameObject camera;
    public float turnAmount = 10.0f;
    public int imgNumber = 0;
    public int frameNumber = 0;

    private GameObject gameObject = null;

    void Start()
    {
        Screen.SetResolution(200, 200, false);
        gameObject = GameObject.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.Euler(45.0f, 60.0f, 45.0f));
    }
    void FixedUpdate()
    {
        Screen.SetResolution(200, 200, false);
        
        if (gameObject != null) {
            float scaleX = Random.Range(0.0f, 2.0f);
            float scaleY = Random.Range(0.0f, 2.0f);
            float scaleZ = Random.Range(0.0f, 8.0f);

            gameObject.transform.Rotate(scaleX*turnAmount, scaleY*turnAmount, scaleZ*turnAmount, Space.Self);

            if ((imgNumber < 16) && (frameNumber % 50 == 0)) {
                string filename = "cube_" + imgNumber.ToString() + ".png";
                ScreenCapture.CaptureScreenshot(filename);
                imgNumber++;
            }

            frameNumber++;
        }
    }
}
