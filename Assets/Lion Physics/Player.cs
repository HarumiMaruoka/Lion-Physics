using System.Collections.Generic;
using UnityEngine;

namespace Lion.Physics
{
    // �m�F�p
    public class Player : MonoBehaviour
    {
        Circle circle;

        private void Start()
        {
            circle = GetComponent<Circle>();
        }

        void Update()
        {
            // �v���C���[�̈ړ����W�b�N
            MovePlayer();
        }

        void MovePlayer()
        {
            var oldPos = transform.position;
            transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f) / 60f;
            GridManager.Instance.MoveObject(circle, transform.position, oldPos);
        }
    }
}