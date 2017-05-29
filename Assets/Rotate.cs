using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    Quaternion StartRotation;
    Quaternion EndRotation;
    public float time=0;
    public float rotationSpeed=1;
	// Use this for initialization
	void Start () {
        /* StartRotation = transform.localRotation;
         EndRotation = new Quaternion(0, 0, 0,1);
         EndRotation.SetEulerAngles(0, 0, transform.rotation.ToEulerAngles().z+(Mathf.PI/2));*/
        QualitySettings.antiAliasing = 8;
        StartRotation = transform.localRotation;
        EndRotation = StartRotation;
    }
	
	// Update is called once per frame
	void Update () {
        TapInputHandle();
        transform.rotation = Quaternion.Slerp(StartRotation, EndRotation, time*rotationSpeed);
        time += Time.deltaTime;
	}
    public void RotateLeft()
    {
        StartRotation = transform.localRotation;
        EndRotation = new Quaternion(0, 0, 0, 1);
        EndRotation.SetEulerAngles(0, 0, transform.rotation.ToEulerAngles().z + (Mathf.PI / 3));
        time = 0;
    }
    public void RotateRight()
    {
        StartRotation = transform.localRotation;
        EndRotation = new Quaternion(0, 0, 0, 1);
        EndRotation.SetEulerAngles(0, 0, transform.rotation.ToEulerAngles().z - (Mathf.PI / 3));
        time = 0;
    }
    void TapInputHandle()
    {
        if (Input.touchCount > 0)
        {
            Touch tap = Input.GetTouch(0);
            if (tap.phase == TouchPhase.Began)
            {
                if (tap.position.x < Screen.width / 2)
                {
                    RotateLeft();
                }
                else if (tap.position.x >= Screen.width/2 )
                {
                    RotateRight();
                }

            }

        }
    }
}
