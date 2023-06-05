using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGear : MonoBehaviour
{
    [SerializeField] private GameObject handGear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("HandLandmarks Annotation") != null)
        {
            handGear.SetActive(true);
        }
        else
        {
            handGear.SetActive(false);
        }
    }
}
