using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	// Use this for initialization
	public void LoadScene (int level) {
        SceneManager.LoadScene(level);
	}
}
