using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class DeviceCamera : MonoBehaviour
{
    private RawImage m_rawImage;
    private WebCamTexture m_cameraTexture;
    
    private void Start()
    {
	    m_rawImage = GetComponent<RawImage>();
	    m_cameraTexture = new WebCamTexture();
	    
	    m_rawImage.texture = m_cameraTexture;
	    m_rawImage.material.mainTexture = m_cameraTexture;
	    
	    PlayDeviceCamera();
    }

    private void Update()
    {
	    
    }

    public void PauseDeviceCamera()
    {
	    m_cameraTexture.Pause();
    }

    public void PlayDeviceCamera()
    {
	    m_cameraTexture.Play();
    }
}
