using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamController : MonoBehaviour
{
    private float xAxisRotation;
    private float yAxisRotation;

    public Transform curr_perspective;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Mouse X") * Time.deltaTime;
        float yInput = Input.GetAxisRaw("Mouse Y") * Time.deltaTime;
        //hard coding sensitivity
        yAxisRotation += xInput * 100; 
        xAxisRotation -= yInput * 100;

        //prevents players from looking all the way around vertically
        xAxisRotation = Mathf.Clamp(xAxisRotation, -90f, 90f);

        //could clamp horizontally
        transform.rotation = Quaternion.Euler(xAxisRotation, yAxisRotation, 0);
        curr_perspective.rotation = Quaternion.Euler(0, yAxisRotation, 0);
    }
}
