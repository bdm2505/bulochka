
    using System;
    using UnityEngine;

    public class JumpController : MoveController
    {
        public float jump = 3f;
        public float duration = 1;
        private float current = 0;
        private bool way = false;
        public override Vector2 Movies()
        {
            if(way)
                return new Vector2(0, jump);
            return new Vector2(0, -jump);
        }

        private void FixedUpdate()
        {
            current += Time.deltaTime;
            if (current > duration)
            {
                current = 0f;
                way = !way;
            }
        }
    }
