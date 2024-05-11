using System;
using UnityEngine;

namespace Lion.Physics
{
    public class PhysicsEngine
    {
        //public static bool DetectCollision(CircleAuthoring circle1, CircleAuthoring circle2, out float distance)
        //{
        //    distance = Vector2.Distance(circle1.transform.position, circle2.transform.position);
        //    return distance < (circle1.Radius + circle2.Radius);
        //}

        //public static void ResolveCollision(CircleAuthoring circle1, CircleAuthoring circle2, float distance)
        //{
        //    if (circle1.Mass + circle2.Mass == 0)
        //    {
        //        return; // Avoid division by zero
        //    }

        //    float overlap = (circle1.Radius + circle2.Radius) - distance;
        //    Vector2 direction = (circle2.transform.position - circle1.transform.position).normalized;
        //    circle1.transform.position -= (Vector3)(direction * (overlap * (circle2.Mass / (circle1.Mass + circle2.Mass))));
        //    circle2.transform.position += (Vector3)(direction * (overlap * (circle1.Mass / (circle1.Mass + circle2.Mass))));
        //}
    }
}