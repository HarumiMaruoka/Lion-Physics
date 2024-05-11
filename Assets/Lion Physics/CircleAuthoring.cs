using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;

namespace Lion.Physics
{
    public struct Circle : IComponentData
    {
        public float Radius;
        public float Mass;

        public static bool operator ==(Circle lhs, Circle rhs) => lhs.Radius == rhs.Radius && lhs.Mass == rhs.Mass;
        public static bool operator !=(Circle lhs, Circle rhs) => lhs.Radius != rhs.Radius || lhs.Mass != rhs.Mass;
    }

    public class CircleAuthoring : MonoBehaviour
    {
        public float _radius = 0.5f;
        public float _mass = 1f;

        class Baker : Baker<CircleAuthoring>
        {
            public override void Bake(CircleAuthoring src)
            {
                var data = new Circle() { Radius = src._radius, Mass = src._mass };
                AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
            }
        }
    }
}