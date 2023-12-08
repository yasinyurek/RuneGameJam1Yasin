using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{

    public GameObject key;
    public GameObject[] Portals;
    public GameObject Player;
    public GameObject KeyCollectPanel;

  

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {

            key.SetActive(true);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;

            foreach (var portal in Portals)
            {
                portal.SetActive(true);
            }
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            KeyCollectPanel.SetActive(true);
            Destroy(gameObject, 10f);
        }
    }




}
