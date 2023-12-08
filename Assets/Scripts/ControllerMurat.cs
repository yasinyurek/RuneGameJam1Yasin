using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMurat : MonoBehaviour
{

    public GameObject Mekan1;
    public GameObject Mekan2;
    public GameObject Mekan3;



    public void CloseMekan2()
    {
        Mekan2 .SetActive(false);
        Mekan1.SetActive(true);

    }
    public void CloseMekan3()
    {
        Mekan3.SetActive(false);
        Mekan1.SetActive(true);

    }


}
