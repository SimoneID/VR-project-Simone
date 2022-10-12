using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR;

public class VibrationManager : MonoBehaviour
{
    public static VibrationManager singleton;


    // Start is called before the first frame update
    void Start()
    {
        if (singleton && singleton != this)
            Destroy(this);
        else
            singleton = this;
    }

    public void TriggerVibration(AudioClip vibrationAudio, OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip(vibrationAudio);
        OVRHaptics.LeftChannel.Preempt(clip);

        //if (controller == OVRInput.Controller.LTouch)
        //{
        //    OVRHaptics.LeftChannel.Preempt(clip);
        //}
    }

    // public void TriggerVibration(int iteration, int frequency, int strength, OVRInput.Controller controller)
    // {
    //   OVRHapticsClip clip = new OVRHapticsClip();

    // for (int i = 0; i < iteration; i++)
    //{
    //  clip.Writesample(i % frequency == 0 ? (byte) strength : (byte) 0)
    //}
    //}
}
