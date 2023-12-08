using System.Collections;
using UnityEngine;

public class TeleportControl : MonoBehaviour
{
    public Transform PlayerPos;
    public Transform Pos1;
    public GameObject Player;
    public GameObject TeleportVFX;

    CharacterControl characterControl;
    FPSShoot fPSShoot;
    void Start()
    {
        characterControl = Player.GetComponent<CharacterControl>();
        fPSShoot = Player.GetComponent<FPSShoot>();

    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("teleport");
            StartCoroutine(Teleport());
        }
    }


    public IEnumerator Teleport()
    {
        TeleportVFX.SetActive(true);
        characterControl.disabled = true;
        fPSShoot.disabled = true;
        yield return new WaitForSeconds(1.65f);
        TeleportVFX.SetActive(false);
        PlayerPos.position = Pos1.position;
        yield return new WaitForSeconds(0.1f);
        characterControl.disabled = false;
        fPSShoot.disabled = false;

    }
}
