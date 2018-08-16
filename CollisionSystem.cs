using Unity.Entities;
using UnityEngine;
using Unity.Transforms;
using Unity.Mathematics;

public class CollisionSystem : ComponentSystem
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

    public struct BlockGroup
    {
        public ComponentDataArray<Block> block;
        public ComponentDataArray<Position> blockPos;
        public EntityArray entityArray;
        public readonly int Length;
    }

    [Inject] PlayerGroup playerGroup;
    [Inject] BlockGroup blockGroup;

    protected override void OnUpdate()
    {
        for (int i = 0; i < blockGroup.Length; i++)
        {
            float dist = math.distance(playerGroup.playerPos[0].Value, blockGroup.blockPos[i].Value);

            if (dist < 1)
            {
                // Stop the falling by resetting it all
               

                // Stop the objects from clipping into eachother by setting the position to above it.

                playerGroup.playerPos[0] = new Position(new float3(playerGroup.playerPos[0].Value.x, blockGroup.blockPos[i].Value.y + 1, playerGroup.playerPos[0].Value.z));

                playerGroup.fall[0] = new Fall();
                //            newPos.Value.x += Input.GetAxis("Horizontal") * 5 * Time.deltaTime;
                //            newPos.Value.y += Input.GetAxis("Vertical") * 5 * Time.deltaTime;
                //            playerGroup.PlayerPos[i] = newPos;
            }
        }
    }
}