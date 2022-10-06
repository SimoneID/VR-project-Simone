using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] string TagToCheck = "Player"; //You can overwrite this in the field in Unity
    [SerializeField] HapticEffectSO HapticEffect;

    HapticEffectSO ActiveEffect = null;

    List<GameObject> PlayersInZone = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other) //Collider only reacts to objects with a RigidBody (so not the MainCamera or Controllers)
    {
        if (other.CompareTag(TagToCheck))
        {
            // players now in the zone - start the effect
            if (PlayersInZone.Count == 0)
                ActiveEffect = HapticManager.PlayEffect(HapticEffect, transform.position);
            Debug.Log("Player is in the zone now");

            PlayersInZone.Add(other.gameObject);
                            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagToCheck))
        {
            PlayersInZone.Remove(other.gameObject);

            // no players left in the zone, stop the effect
            if (PlayersInZone.Count == 0)
            {
                Debug.Log("Player is out the zone now");
                HapticManager.StopEffect(ActiveEffect);
                ActiveEffect = null;
            }
        }
    }
}
