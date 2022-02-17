using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    [SerializeField] float minXRot;
    [SerializeField] float maxXRot;

    [SerializeField] float minZoom;
    [SerializeField] float maxZoom;

    [SerializeField] float zoomSpeed;
    [SerializeField] float rotateSpeed;

    private float curXRot;
    private float curZoom;
    private Camera cam;

    private void Start() 
    {
        cam = Camera.main;
        curZoom = cam.transform.localPosition.y;
        curXRot = -50;
    }

    private void Update()
    {
        // zooming
        curZoom += Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
        curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);

        cam.transform.localPosition = Vector3.up * curZoom;

        // camera look
        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            curXRot += -y * rotateSpeed;
            curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);

            transform.eulerAngles = new Vector3(curXRot, transform.eulerAngles.y + (x * rotateSpeed), 0f);
        }

        // movement 
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0.0f;
        forward.Normalize();

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 dir = forward * moveZ + right * moveX;
        dir.Normalize();

        dir *= moveSpeed * Time.deltaTime;

        transform.position += dir;
    }
}
