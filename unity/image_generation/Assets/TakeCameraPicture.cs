using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCameraPicture : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject camera;
    public float turnAmount = 0.1f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(turnAmount, turnAmount, turnAmount, Space.Self);

        //Quaternion target = Quaternion.Euler(gameObject.transform.rotation.x + 1, 0, 0);
        //gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, target, Time.deltaTime);
    }
}
