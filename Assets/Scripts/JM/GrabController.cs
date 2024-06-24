using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Yuri
{
    public class GrabController : MonoBehaviour
    {
        public Transform rightHand;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("hit");
        }
    }
}
