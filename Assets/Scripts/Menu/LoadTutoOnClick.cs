using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTutoOnClick : MonoBehaviour {

	// Use this for initialization
	public void LoadTuto (int level) {
        Application.LoadLevel(level);
	}
}
