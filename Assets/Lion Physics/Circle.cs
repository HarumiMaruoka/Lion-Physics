using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Lion.Physics
{
    public class Circle : MonoBehaviour
    {
        public float Radius;
        public float Mass;
        private List<Circle> colliders = new List<Circle>();


        private void OnEnable()
        {
            GridManager.Instance.AddCircle(this, transform.position);
        }



        private void Update()
        {
            // è’ìÀåüèo
            GridManager.Instance.RetrieveNeighbors(this, ref colliders);
            foreach (Circle neighbor in colliders)
            {
                GridManager.calcCount++;

                if (PhysicsEngine.DetectCollision(this, neighbor, out float distance))
                {
                    // è’ìÀâûìö
                    var oldThisPos = transform.position;
                    var oldNeighborPos = neighbor.transform.position;
                    PhysicsEngine.ResolveCollision(this, neighbor, distance);
                    GridManager.Instance.MoveObject(this, transform.position, oldThisPos);
                    GridManager.Instance.MoveObject(neighbor, neighbor.transform.position, oldNeighborPos);
                    HandleCollision(neighbor);
                }
            }
        }

        private void HandleCollision(Circle neighbor)
        {

        }
    }
}