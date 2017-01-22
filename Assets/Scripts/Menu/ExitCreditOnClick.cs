using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCreditOnClick : MonoBehaviour {


    public GameObject credit;
    public GameObject canvas;

    void Start()
    {
        credit.SetActive(true);
    }

    public void StopCreditOnClick()
    {
        if (credit.activeSelf == true)
        {
            credit.SetActive(false);
            canvas.SetActive(true);
        }

    }
}
