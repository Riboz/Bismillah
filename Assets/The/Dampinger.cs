using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Dampinger : MonoBehaviour
{
    // Start is called before the first frame update
    public static Dampinger shake{get; private set;}
    private CinemachineVirtualCamera dampinger;
    private float shakertimer;
    void Awake()
    {
        shake = this;
        dampinger = GetComponent<CinemachineVirtualCamera>();
    }
    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
        dampinger.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        shakertimer = time;
    } 
    // Update is called once per frame
    void Update()
    {
        

        if(shakertimer > 0)
        {
            
            shakertimer -= Time.deltaTime;
            if(shakertimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                dampinger.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
        else
        {

        }
    }
}
