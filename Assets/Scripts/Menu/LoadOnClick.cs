using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour {

	// Use this for initialization
	public void LoadScene (int level) {
        Application.LoadLevel(level);
	}
}
