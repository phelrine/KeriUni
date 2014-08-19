using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        var deg = 45f;
	}

	// Update is called once per frame
	void Update () {

	}

    public void SetRotation(float deg)
    {
        deg = Mathf.Clamp(deg, 10f, 80f);
        var rot = Quaternion.Euler(0f, 0f, deg);
        transform.rotation = rot;
    }
}
