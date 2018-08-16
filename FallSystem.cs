using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Assets
{
    class FallSystem : JobComponentSystem
    {
        private struct GravityJob : IJobProcessComponentData<Position, Fall>
        {
            public float dt;


            public void Execute(ref Position position, ref Fall Fall)
            {
                Fall.Acceleration = 9.81f;
                Fall.FallTime += dt;
                Fall.FallSpeed += Fall.Acceleration * Mathf.Pow((Fall.FallTime), 2);
                // Always put an downward force upon this entity, by subtracting a Y value.
                // Use a threshold to counter wonky movement behaviour
                if (Fall.FallTime > 5* dt)
                {
                    position.Value.y -= Fall.FallSpeed * dt;
                }
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            // Apparently we are falling, start the clock!
            var job = new GravityJob
            {
                dt = Time.deltaTime,
                // No clue what this will be in the end. 
            };

            return job.Schedule(this, 1, inputDeps);
        }
    }
}
