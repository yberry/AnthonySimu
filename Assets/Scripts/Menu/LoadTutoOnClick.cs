using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTutoOnClick : MonoBehaviour {

	// Use this for initialization
	public void LoadTuto (int level) {
        SceneManager.LoadScene(level);
    }
}
