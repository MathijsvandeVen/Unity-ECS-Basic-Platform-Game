using Unity.Entities;
using UnityEngine;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Rendering;

public class ShootBulletSystem : ComponentSystem
{
    



    public struct PlayerGroup
    {
        public ComponentDataArray<Position> playerPos;
        public ComponentDataArray<PlayerInput> input;
        //public ComponentDataArray<Acceleration> acceleration;
        //public ComponentDataArray<Gravity> gravity;
        public ComponentDataArray<Fall> fall;
        public readonly int Length;
    }


    [Inject] PlayerGroup playerGroup;


    protected override void OnUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }


    }
}