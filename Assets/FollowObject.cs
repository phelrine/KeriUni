using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

    GameObject follow;
    Vector3 origin;

	// Use this for initialization
	void Start () {
        origin = transform.position;
	}

	// Update is called once per frame
	void Update () {
        if (follow == null)
            return;

        var pos = follow.transform.position;
        pos.z = -10f;
        transform.position = pos;
	}

    public void Follow(GameObject obj)
    {
        follow = obj;
        Invoke("Unfollow", 5f);
    }

    void Unfollow()
    {
        follow = null;
        transform.position = origin;
    }
}
