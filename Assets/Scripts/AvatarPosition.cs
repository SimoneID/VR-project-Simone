using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarPosition : MonoBehaviour
{
    [SerializeField] Transform Origin;
    [SerializeField] float ActionTime = 2f;
    [SerializeField] float WaitTime = 0.1f;
    float CurrentProgress = 0f;
    bool IsBusy = true;
    
    float x;
    float y;
    float z;
    Vector3 pos;

    [SerializeField] HapticEffectSO HBEffect;
    void Start()
    {
        x = Random.Range(-4.5f, 4.5f);
        y = 0.85f;
        z = -4.5f;
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    void Update()
    {
        CurrentProgress += Time.deltaTime / (IsBusy ? ActionTime : WaitTime);

        if (CurrentProgress >= 1f)
        {
            if (!IsBusy)
                HapticManager.PlayEffect(HBEffect, Origin.transform.position);

            IsBusy = !IsBusy;
            CurrentProgress = 0f;
        }        
    }
}
