using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    int time = 240;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(CountDown());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CountDown()
    {
        while (true)
        {
            GetComponentInChildren<Text>().text = Mathf.Floor(time / 60).ToString() + " : " + (time % 60).ToString();

            time = time - 1; ;

            yield return new WaitForSeconds(1);
        }

    }
}
