using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Transform cameraTransform;
    public Transform playerTransform;

	// Use this for initialization
	void Start () {
        cameraTransform = GetComponent<Transform>(); 
	}
	
	// Update is called once per frame
	void Update () {
        float camZ = cameraTransform.position.z;
        Vector3 new_camPos = new Vector3(playerTransform.position.x, playerTransform.position.y, camZ);
        cameraTransform.position = new_camPos;
	}
}
