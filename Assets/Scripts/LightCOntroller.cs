using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCOntroller : MonoBehaviour
{
    [SerializeField] Light dirLight;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y < 0)
        {
            dirLight.intensity = 1 + (player.position.y/100f);
        }
    }
}
