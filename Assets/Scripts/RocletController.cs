using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GildarGaming.LD45
{
    public class RocletController : MonoBehaviour
    {

        public GameObject mainBody;
        public GameObject leftEngine;
        public GameObject rightEngine;
        public GameObject upper;
        public GameObject holder;
        bool allPartsActive = false;
        [SerializeField] GameObject[] thrusters;
        void Start()
        {
            //holder.SetActive(false);
            //mainBody.SetActive(false);
            //upper.SetActive(false);
            //leftEngine.SetActive(false);
            //rightEngine.SetActive(false);
            foreach (var thruster in thrusters)
            {
                thruster.SetActive(false);
            }
            
        }
        void AddPart(BuildingPart part)
        {
            Debug.Log("Adding part" + part);
            switch (part)
            {
                case BuildingPart.Main:
                    mainBody.SetActive(true);
                    break;
                case BuildingPart.Upper:
                    upper.SetActive(true);
                    break;
                case BuildingPart.LeftEngine:
                    leftEngine.SetActive(true);
                    break;
                case BuildingPart.RightEngine:
                    rightEngine.SetActive(true);
                    break;
                case BuildingPart.Holder:
                    holder.SetActive(true);
                    break;
                
            }
            CheckActiveParts();
        }

        private void CheckActiveParts()
        {
            allPartsActive = true;
            if (!holder.activeInHierarchy) allPartsActive = false;
            if (!mainBody.activeInHierarchy) allPartsActive = false;
            if (!upper.activeInHierarchy) allPartsActive = false;
            if (!leftEngine.activeInHierarchy) allPartsActive = false;
            if (!rightEngine.activeInHierarchy) allPartsActive = false;

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //Not the best way to check tags, but will do for now.
            if (allPartsActive && other.gameObject.tag == "Player")
            {
                AttackProbe(other.gameObject);
                InitializeFlightSequence();
            }
            BuildingPartController bpc = other.gameObject.GetComponent<BuildingPartController>();
            if (bpc != null)
            {
                AddPart(bpc.part);
                Destroy(other.gameObject);
            }
        }

        private void AttackProbe(GameObject player)
        {
            PlayerController pc = player.GetComponent<PlayerController>();
            pc.enabled = false;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            player.transform.position = holder.transform.position;
            Destroy(rb);
            player.transform.parent = this.transform;
            player.transform.localPosition = new Vector3(0, 2.55f, 0f);
        }

        private void InitializeFlightSequence()
        {
            foreach (var thruster in thrusters)
            {
                thruster.SetActive(true);
                GetComponent<RocketFlyer>().enabled = true;
                
                

            }
        }
    }
}

