using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour {

    #region Fields
    public float zSensitivity,
                 ySensitivity,
                 xSensitivity,
                 forwardSpeed;               
    private float rotationY, reversedF;
    private Vector3 movement,
                   initialMousePosition;
    private Rigidbody rb;
    public bool reversedY;
    #endregion

    #region Start and Update
    // Use this for initialization
    void Start () {
        if (reversedY)
            reversedF = -1;
        else
        {
            reversedF = 1;
        }
        rotationY = 0;
		movement = new Vector3 (0,0,0);
		rb = GetComponent <Rigidbody> ();
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        initialMousePosition = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
        Accelerate();
	}
    #endregion

    #region Movement
    void Accelerate()
    {
        if (Input.GetAxis("Vertical") > 0 && forwardSpeed <= 20)
        {
            forwardSpeed += Input.GetAxis("Vertical");
        }
        else if (Input.GetAxis("Vertical") < 0 && forwardSpeed >= 5)
        {
            forwardSpeed += Input.GetAxis("Vertical");
        }
    }

    void Move()
    {
        
        movement = transform.forward * forwardSpeed;
        rb.velocity = (movement);

        /*
        rotationY = Input.GetAxis("Mouse X") * ySensitivity;
        rotationY = Mathf.Clamp(rotationY, -2f, 2f);
        Debug.Log(rotationY);
        */
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Quaternion rotation = Quaternion.LookRotation(ray.direction);

        transform.rotation = Quaternion.FromToRotation(ray.direction, transform.forward);
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * zSensitivity * reversedF);
    }
    #endregion
}


