using System.Collections.Generic;
using UnityEngine;

namespace Lion.Physics
{
    // 確認用
    public class Player : MonoBehaviour
    {
        Circle circle;

        private void Start()
        {
            circle = GetComponent<Circle>();
        }

        void Update()
        {
            // プレイヤーの移動ロジック
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