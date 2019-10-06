using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GildarGaming.Ld45
{
    public class GameManager : MonoBehaviour
    {
        public static bool playerIsDead = false;

        void Update()
        {
            if (!playerIsDead) return;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}

