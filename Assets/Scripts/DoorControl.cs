using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public GameObject EText;
    public GameObject Close;
    public GameObject Open;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            EText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                Open.SetActive(true);
                Close.SetActive(false);
            }
        }

        
    }


    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            EText.SetActive(false);
        }
    }


}
