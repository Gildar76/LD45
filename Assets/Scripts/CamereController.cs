using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GildarGaming.LD45
{
    public class CamereController : MonoBehaviour
    {
        public GameObject background;
        public Transform cameraTarget;
        public float damping;
        // Start is called before the first frame update
        void Start()
        {

        }

        void LateUpdate()
        {
            Vector3 backgroundPos = background.transform.position;
            
            Vector3 cameraPos = transform.position;
            cameraPos = Vector3.Lerp(cameraPos, cameraTarget.transform.position, Time.deltaTime * 60f);
            cameraPos.z = transform.position.z;
            transform.position = cameraPos;
            backgroundPos.x = cameraPos.x;
            background.transform.position = backgroundPos;
        }
    }

}
