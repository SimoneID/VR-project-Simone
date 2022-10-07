using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Zone2 : MonoBehaviour
{
    [SerializeField] string TagToCheck = "Player"; //You can overwrite this in the field in Unity
    List<GameObject> PlayersInZone2 = new List<GameObject>();

    public AudioClip vibAudio;


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
            if (PlayersInZone2.Count == 0)
                GetComponent<AudioSource>().PlayOneShot(vibAudio);
                VibrationManager.singleton.TriggerVibration(vibAudio, OVRInput.Controller.Touch);
            Debug.Log("Player is in the zone now");
            PlayersInZone2.Add(other.gameObject);       
        }
    }
}