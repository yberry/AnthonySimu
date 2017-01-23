using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCreditOnClick : MonoBehaviour {

    public GameObject credit;
    public GameObject canvas;

    void Start()
    {
        credit.SetActive(false);
    }

    public void CreditOnClick()
    {
        credit.SetActive(true);
    }

}
