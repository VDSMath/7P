using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveP : MonoBehaviour
{

    //Ship variables.
    public GameObject playerShip;
    Rigidbody pS;
    public float speed;
    public float turnSpeed;

    //Camera variables.
    public Camera mainCamera;
    public GameObject camPos;
    public float camLerp;
    public float camTurnSpeed;

    void Start()
    {
        pS = playerShip.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //This part takes care of the player movement.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.back * moveHorizontal * turnSpeed);
        transform.Rotate(Vector3.right * moveVertical);

        pS.transform.position += transform.forward * Time.deltaTime * speed;

        //Lerping the camera to its place.
        mainCamera.transform.DOMove(new Vector3(camPos.transform.position.x, camPos.transform.position.y, camPos.transform.position.z), camLerp);
        //Lerping the camera rotation.
        mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, camPos.transform.rotation, Time.deltaTime * camTurnSpeed);

    }
}