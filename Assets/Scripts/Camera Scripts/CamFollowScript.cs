using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script makes the cam follow the gameObject that this script is attached to
public class CamFollowScript : MonoBehaviour {
	public Camera cam;
	private Vector3 distance;
    private int mode;

	// Use this for initialization
	void Start () {
        //cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //distance = cam.gameObject.transform.position- gameObject.transform.position;
        mode = 0;
        //Debug.Log("vector = " + distance.ToString());
        changeCamView();

	}

	// Update is called once per frame	
	void Update () {
		cam.transform.position = Vector3.Lerp(cam.transform.position, gameObject.transform.position + distance, 4.0f*Time.deltaTime);
        //cam.transform.LookAt (gameObject.transform);

        if (Input.GetKeyDown(KeyCode.M))
        {
            changeCamView();
        }
	}

    void changeCamView()
    {

        if (mode >= 2)
        {
            mode = 0;
        }
        else
        {
            mode++;
        }

        if (mode == 0)
        {
            cam.transform.eulerAngles = new Vector3(90, 0, 0);
            distance = new Vector3(0, 18, 0);
        } else if(mode == 1)
        {
            distance = new Vector3(0, 6, -6.2f);
            cam.transform.eulerAngles = new Vector3(40, 0, 0);
        } else if(mode == 2)
        {
            distance = new Vector3(0, 2, -6.2f);
            cam.transform.eulerAngles = new Vector3(10, 0, 0);
        }
    }
}
