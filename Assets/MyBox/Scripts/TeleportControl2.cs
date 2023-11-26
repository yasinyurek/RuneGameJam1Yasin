using System.Collections;
using UnityEngine;

public class TeleportControl2 : MonoBehaviour
{
    public Transform PlayerPos;
    public Transform CityPos1;
    public GameObject Player;

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

        characterControl.disabled = true;
        fPSShoot.disabled = true;
        PlayerPos.position = CityPos1.position;
        yield return new WaitForSeconds(0.3f);
        characterControl.disabled = false;
        fPSShoot.disabled = false;

    }
}
