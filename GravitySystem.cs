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

namespace Assets
{
    class GravitySystem : JobComponentSystem
    {
        public Stopwatch sw = new Stopwatch();

        private struct GravityJob : IJobProcessComponentData<Position, Gravity, Acceleration>
        {

            //public bool AffectedByGravity;

            public float dt;
            

            public void Execute(ref Position position, ref Gravity Gravity, ref Acceleration Acceleration)
            {
                Gravity.FallSpeed = 0.6f;
                Gravity.FallTime += dt;
                Acceleration.Vertical -= Gravity.FallSpeed * Mathf.Pow(Gravity.FallTime, 2) * dt;

                position.Value.y += Acceleration.Vertical;
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
