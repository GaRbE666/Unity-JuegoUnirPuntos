using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRender;
    [SerializeField] private Transform[] points;
    [SerializeField] private float distance;

    private Camera cam;
    private int index;
    private bool canSpawn;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.GetTouch(0);
            Vector3 aux = new Vector3(cam.ScreenToWorldPoint(myTouch.position).x, cam.ScreenToWorldPoint(myTouch.position).y, 0);
            RaycastHit hit;
            if (Physics.Raycast(aux, Vector3.forward, out hit, 1000) && canSpawn)
            {
                canSpawn = false;

            }
            else
            {

            }
        }
    }



    private bool CheckDistance(Vector3 start, Vector3 end)
    {
        if (Vector3.Distance(start, end) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
