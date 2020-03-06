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
    [SerializeField]
    GameObject Room;
    SpriteRenderer renderer;

    private float _cameraPosX;
    private float _cameraPosY;

    // Start is called before the first frame update
    void Start()
    {
     //   renderer = Room.GetComponent<SpriteRenderer>(); 
        if (target == null)
        {
            Debug.Log("No Target For Camera Found!");
        }
        if(Room != null)
        {
        //    GetRoomBounds();
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
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        }
    }

    void GetRoomBounds()
    {
        Bounds bounds = new Bounds(Room.transform.position, Vector2.zero);

        foreach (Renderer renderer in Room.GetComponentsInChildren<Renderer>())
        {
            bounds.Encapsulate(renderer.bounds);
        }

        Vector3 localCenter = bounds.center - transform.position;
        bounds.center = localCenter;
        Debug.Log("The local bounds of this model is " + bounds);
    }
}
