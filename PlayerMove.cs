using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{

    public Camera cam;

    [Range(1.0f, 10.0f)] public float SensibilityX;

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
        

    }


    void Update()
    {
        if (!isLocalPlayer)
        {
            cam.enabled = false;
            GetComponent<MeshRenderer>().material.color = Color.blue;
            return;
        }            

        float x = Input.GetAxis("Horizontal") * 0.1f;
        float z = Input.GetAxis("Vertical") * 0.1f;

        float mouseX = Input.GetAxis("Mouse X")*SensibilityX;

        transform.Translate(x, 0, z);
        transform.Rotate(0, mouseX, 0);
    }
}