using System.Collections.Generic;
using UnityEngine;

namespace Lion.Physics
{
    public class Player : MonoBehaviour
    {
        void Update()
        {
            transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f) / 60f;
        }
    }
}