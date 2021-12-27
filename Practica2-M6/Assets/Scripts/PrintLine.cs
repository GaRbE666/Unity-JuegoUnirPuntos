using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintLine : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private LineRenderer lineRender;
    [SerializeField] private Transform[] points;
    [SerializeField] private float distance;
    [SerializeField] private Material[] materials;

    Camera cam;
    private bool canSpawn;
    private bool canStart;
    private LineRenderer lineRenderClone;
    int index;
    private Vector3 startPoint;
    #endregion

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        canSpawn = true;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (index < points.Length - 1)
        {
            if (Input.touchCount > 0)
            {
                Touch myTouch = Input.GetTouch(0);
                RaycastHit hit;
                if (Physics.Raycast(cam.ScreenToWorldPoint(myTouch.position), transform.TransformDirection(Vector3.forward), out hit, 1000))
                {
                    if (canSpawn)
                    {
                        canSpawn = false;
                        lineRenderClone = Instantiate(lineRender, hit.transform.position, Quaternion.identity);
                        if (index == 0 && hit.transform.position == points[0].position)
                        {
                            canStart = true;
                            startPoint = hit.transform.position;
                        }
                    }

                }
                else if (lineRenderClone && canStart)
                {
                    FloatingLine(lineRenderClone, startPoint, myTouch);
                }
                if (myTouch.phase == TouchPhase.Moved)
                {
                    if (index < points.Length - 1)
                    {
                        if (canStart)
                        {
                            CheckActualPoint(myTouch);
                        }
                    }
                }
            }
            else if (lineRenderClone)
            {
                Destroy(lineRenderClone.gameObject);
                canSpawn = true;
            }
        }

    }

    private void CheckActualPoint(Touch myTouch)
    {
        Vector3 aux = new Vector3(cam.ScreenToWorldPoint(myTouch.position).x, cam.ScreenToWorldPoint(myTouch.position).y, 0);
        
        if (Vector3.Distance(aux, points[index + 1].position) < distance)
        {
            index++;
            LineRenderer lineaux = Instantiate(lineRender, startPoint, Quaternion.identity);
            SetLine(lineaux, startPoint, points[index].position);
            startPoint = points[index].position;
            SetFirstLine(lineRenderClone, myTouch);
            if (index == points.Length - 1)
            {
                Debug.Log("Dibujo terminado");
            }
        }
    }

    private void SetFirstLine(LineRenderer lineRender, Touch myTouch)
    {
        Vector3 resetZ = new Vector3(cam.ScreenToWorldPoint(myTouch.position).x, cam.ScreenToWorldPoint(myTouch.position).y, 0);
        lineRender.SetPosition(0, resetZ);
        lineRender.SetPosition(1, resetZ);
        SetLineRenderColor(lineRender);
        SetLineRenderSize(lineRender);
    }

    private void FloatingLine(LineRenderer lineRender, Vector3 start, Touch myTouch)
    {
        Vector3 resetZ = new Vector3(cam.ScreenToWorldPoint(myTouch.position).x, cam.ScreenToWorldPoint(myTouch.position).y, 0);
        lineRender.SetPosition(0, start);
        lineRender.SetPosition(1, resetZ);
        SetLineRenderColor(lineRender);
        SetLineRenderSize(lineRender);
    }

    private void SetLine(LineRenderer lineRender, Vector3 firstPoint, Vector3 secondPoint)
    {
        lineRender.SetPosition(0, firstPoint);
        lineRender.SetPosition(1, secondPoint);
        SetLineRenderColor(lineRender);
        SetLineRenderSize(lineRender);
    }

    private void SetLineRenderSize(LineRenderer lineRender)
    {
        lineRender.startWidth = PlayerPrefs.GetFloat("size");
        lineRender.endWidth = PlayerPrefs.GetFloat("size");
    }

    private void SetLineRenderColor(LineRenderer lineRender)
    {
        switch (PlayerPrefs.GetInt("color"))
        {
            case 0:
                lineRender.material = materials[0];
                break;
            case 1:
                lineRender.material = materials[1];
                break;
            case 2:
                lineRender.material = materials[2];
                break;
            case 3:
                lineRender.material = materials[3];
                break;
            case 4:
                lineRender.material = materials[4];
                break;
            case 5:
                lineRender.material = materials[5];
                break;
            case 6:
                lineRender.material = materials[6];
                break;
            case 7:
                lineRender.material = materials[7];
                break;
        }
    }
}
