using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalExplosion : MonoBehaviour
{

    Animator animator;
    public GameObject Castle;
    public GameObject CastleOpenPanel;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("RPGBullet"))
        {
            animator.SetBool("PortalExp", true);
            Castle.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            StartCoroutine(CastleQuestPanelOn());
            Destroy(gameObject, 10f);

        }

        
    }

    public IEnumerator CastleQuestPanelOn()
    {

        yield return new WaitForSeconds(8f);
        CastleOpenPanel.SetActive(true);


    }
}
