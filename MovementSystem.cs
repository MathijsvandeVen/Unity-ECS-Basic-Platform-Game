//using Unity.Entities;
//using UnityEngine;
//using Unity.Transforms;

//public class MovementSystem : ComponentSystem
//{
//    public struct PlayerGroup
//    {
//        public ComponentDataArray<Position> PlayerPos;
//        public ComponentDataArray<PlayerInput> playerInput;
//        public readonly int Length;
//    }

//    [Inject] PlayerGroup playerGroup;

//    protected override void OnUpdate()
//    {
//        for (int i = 0; i < playerGroup.Length; i++)
//        {
//            var newPos = playerGroup.PlayerPos[i];
//            newPos.Value.x += Input.GetAxis("Horizontal") * 5 * Time.deltaTime;
//            newPos.Value.y += Input.GetAxis("Vertical") * 5 * Time.deltaTime;
//            playerGroup.PlayerPos[i] = newPos;
//        }
//    }
//}