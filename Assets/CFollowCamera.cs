using UnityEngine;
using System.Collections;

public class CFollowCamera : MonoBehaviour {


    public GameObject _target;
    public Vector3 offset; 
    
    // Use this for initialization
	void Start ()
    {
        transform.position = transform.position + offset;

    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, (_target.transform.position + offset), 3) ;

    }
}
