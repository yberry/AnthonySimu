using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeProfondeur : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().sortingOrder = (int)(100-(transform.position.z *10 ));
		//transform.position = new Vector3( )
	}
}
