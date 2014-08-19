using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    Vector3 start;
    public Arrow arrow;
    public UnityChan unitychan;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            var pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            var diff = start - pos;

            var deg = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            arrow.SetRotation(deg);
            unitychan.SetPosition(diff.magnitude);
        }

        if (Input.GetMouseButtonUp(0))
        {
            var pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            var diff = start - pos;
            unitychan.Run(diff);
        }
	}
}
