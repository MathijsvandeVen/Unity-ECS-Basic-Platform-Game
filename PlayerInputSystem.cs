using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class PlayerInputSystem : JobComponentSystem
{
    public struct PlayerInputJob : IJobProcessComponentData<PlayerInput>
    {
        public bool Left;
        public bool Right;
        public bool Up;
        public bool Down;

        public bool UpLeft;
        public bool UpRight;
        public bool DownLeft;
        public bool DownRight;

        public float Horizontal;
        public float Vertical;

        public void Execute(ref PlayerInput input)
        {
            //input.Horizontal = Left || UpLeft || DownLeft ? -1f : Right || UpRight || DownRight ? 1f : 0f;
            //input.Vertical = Down || DownLeft || DownRight ? -1f : Up || UpRight || UpLeft ? 1f : 0f;
            input.Horizontal = Horizontal;
            input.Vertical = Vertical;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {

        var job = new PlayerInputJob
        {
            Horizontal = Input.GetAxisRaw("Horizontal"),
            Vertical = Input.GetAxisRaw("Vertical")


            //Left = Input.GetKeyDown(KeyCode.A),
            //Right = Input.GetKeyDown(KeyCode.D),
            //Up = Input.GetKeyDown(KeyCode.W),
            //Down = Input.GetKeyDown(KeyCode.S),

            //UpLeft = Input.GetKeyDown(KeyCode.Q),
            //UpRight = Input.GetKeyDown(KeyCode.E),
            //DownLeft = Input.GetKeyDown(KeyCode.Z),
            //DownRight = Input.GetKeyDown(KeyCode.X),
        };

        // This 1 here is the InnerLoop batch. Lower numbers mean bigger jobs.
        return job.Schedule(this, 1, inputDeps);
    }
}