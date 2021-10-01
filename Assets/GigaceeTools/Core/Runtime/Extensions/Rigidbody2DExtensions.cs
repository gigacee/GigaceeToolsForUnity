﻿using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace GigaceeTools
{
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class Rigidbody2DExtensions
    {
        public static void MovePositionX(this Rigidbody2D self, float x)
        {
            self.MovePosition(new Vector2(x, self.position.y));
        }

        public static void MovePositionY(this Rigidbody2D self, float y)
        {
            self.MovePosition(new Vector2(self.position.x, y));
        }
    }
}
