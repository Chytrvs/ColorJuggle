using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    Quaternion StartRotation,EndRotation;
    float time=0;
    [SerializeField]
    float rotationSpeed;
    bool isRotating = false;
	// Use this for initialization
	void Start () {
        QualitySettings.antiAliasing = 8;
        StartRotation = transform.localRotation;
        EndRotation = StartRotation;
    }
	
	// Update is called once per frame
	void Update () {
        if (isRotating)
        {
        transform.rotation = Quaternion.Slerp(StartRotation, EndRotation, time*rotationSpeed);
        time += Time.deltaTime;
        isRotating = (time * rotationSpeed - Time.deltaTime * rotationSpeed )<= 1;
        }
        else
        {
            KeyboardInputHandle();
        }

	}
    public void RotateLeft()
    {
        StartRotation = transform.localRotation;
        EndRotation = new Quaternion(0, 0, 0, 1);
        EndRotation.SetEulerAngles(0, 0, transform.rotation.ToEulerAngles().z + (Mathf.PI / 3));
        time = 0;
        isRotating = true;
    }
    public void RotateRight()
    {
        StartRotation = transform.localRotation;
        EndRotation = new Quaternion(0, 0, 0, 1);
        EndRotation.SetEulerAngles(0, 0, transform.rotation.ToEulerAngles().z - (Mathf.PI / 3));
        time = 0;
        isRotating = true;
    }
    void TapInputHandle()
    {
        if (Input.touchCount > 0)
        {
            Touch tap = Input.GetTouch(0);
            if (tap.phase == TouchPhase.Began ) 
            {
                if (tap.position.x < Screen.width / 2)
                {
                    RotateLeft();
                }
                else if (tap.position.x >= Screen.width/2)
                {
                    RotateRight();
                }

            }

        }
    }
    void KeyboardInputHandle()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateRight();
        }
    }
}
