using Unity.Entities;
using UnityEngine;
using Unity.Transforms;
using Unity.Jobs;

public class playerMovementSystem : JobComponentSystem
{
    public struct PlayerInputJob : IJobProcessComponentData<Position, PlayerInput>
    {
        public float dt;
        public void Execute(ref Position position, ref PlayerInput playerInput)
        {
            position.Value.x += playerInput.Horizontal * 5 * dt;
            position.Value.y += playerInput.Vertical * 10 * dt;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {

        var job = new PlayerInputJob
        {
            dt = Time.deltaTime,   
        };

        // This 1 here is the InnerLoop batch. Lower numbers mean bigger jobs.
        return job.Schedule(this, 1, inputDeps);
    }
}