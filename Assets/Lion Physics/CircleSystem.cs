using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Lion.Physics
{
    public partial struct DancerSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (circle, transform) in SystemAPI.Query<RefRO<Circle>, RefRW<LocalTransform>>())
            {
                // var neighbors = SystemAPI.Query<RefRO<Circle>, RefRO<LocalTransform>>();

                foreach (var (neighborCircle, neighborTransform) in SystemAPI.Query<RefRO<Circle>, RefRW<LocalTransform>>())
                {
                    if (transform.ValueRO.Position.x == neighborTransform.ValueRO.Position.x &&
                        transform.ValueRO.Position.y == neighborTransform.ValueRO.Position.y) continue;

                    var distance = math.distance(transform.ValueRO.Position, neighborTransform.ValueRO.Position);
                    if (distance < (circle.ValueRO.Radius + neighborCircle.ValueRO.Radius))
                    {
                        float overlap = (circle.ValueRO.Radius + neighborCircle.ValueRO.Radius) - distance;
                        float3 direction = math.normalize((neighborTransform.ValueRO.Position - transform.ValueRO.Position));
                        transform.ValueRW.Position -= (float3)(direction * (overlap * (neighborCircle.ValueRO.Mass / (circle.ValueRO.Mass + neighborCircle.ValueRO.Mass))));
                        neighborTransform.ValueRW.Position += (float3)(direction * (overlap * (circle.ValueRO.Mass / (circle.ValueRO.Mass + neighborCircle.ValueRO.Mass))));
                    }
                }
            }
        }
    }
}