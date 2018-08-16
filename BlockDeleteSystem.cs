//using Unity.Entities;
//using UnityEngine;
//using Unity.Transforms;
//using Unity.Mathematics;

//public class DeleteBlockSystem : ComponentSystem
//{

//    public struct PlayerGroup
//    {
//        public ComponentDataArray<Position> playerPos;
//        public ComponentDataArray<PlayerInput> input;
//    }

//    public struct BlockGroup
//    {
//        public ComponentDataArray<Block> block;
//        public ComponentDataArray<Position> blockPos;
//        public EntityArray entityArray;
//        public readonly int Length;
//    }

//    [Inject] PlayerGroup playerGroup;
//    [Inject] BlockGroup blockGroup;

//    protected override void OnUpdate()
//    {
//        for (int i = 0; i < blockGroup.Length; i++)
//        {
//            float dist = math.distance(playerGroup.playerPos[0].Value, blockGroup.blockPos[i].Value);

//            if (dist < 1)
//            {
//                PostUpdateCommands.DestroyEntity(blockGroup.entityArray[i]);
                
//            }
//        }
//    }
//}