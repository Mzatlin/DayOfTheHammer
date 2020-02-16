using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    float xCamMin;
    [SerializeField]
    float xCamMax;
    [SerializeField]
    float yCamMin;
    [SerializeField]
    float yCamMax;

    private float _cameraPosX;
    private float _cameraPosY;

    // Start is called before the first frame update
    void Start()
    {
        if(target == null)
        {
            Debug.Log("No Target For Camera Found!");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null)
        {
            _cameraPosX = Mathf.Clamp(target.transform.position.x, xCamMin, xCamMax);
            _cameraPosY = Mathf.Clamp(target.transform.position.y, yCamMin, yCamMax);
            transform.position = new Vector3(_cameraPosX, _cameraPosY, transform.position.z);
        }
    }
}
