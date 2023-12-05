using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessControl : MonoBehaviour
{

    public GameObject QuestPanel, QuestPanelOpenInfoPanel;
    public GameObject KeyBox;



    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("Görev alýndý");
            QuestPanel.SetActive(true);
            QuestPanelOpenInfoPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            KeyBox.SetActive(true);

        }
    }

}
