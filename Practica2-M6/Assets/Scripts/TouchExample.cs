using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchExample : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Camera cam;
    [SerializeField] private Text coordenateText;

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //    Vector2 touchDeltaPosition = cam.ScreenToViewportPoint(Input.GetTouch(0).deltaPosition);
        //    transform.Translate(touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0);
        //}
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.GetTouch(0);
            Vector3 newPosition = cam.ScreenToWorldPoint(myTouch.position);
            coordenateText.text = string.Format("X: {0}, Y: {1}", newPosition.x, newPosition.y);
            transform.position = new Vector3(newPosition.x, newPosition.y, 0);
        }
    }
}
