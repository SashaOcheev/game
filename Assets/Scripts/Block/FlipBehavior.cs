﻿using System;
using UnityEngine;

namespace Scripts.Block
{
    public class FlipBehavior
    {
        const float DeltaAngle = 90f;

        public void FlipRight(Transform transform, ref Position currentPosition)
        {
            switch (currentPosition)
            {
                case Position.X:
                    transform.RotateAround(
                        new Vector3(transform.position.x + transform.localScale.x / 2, transform.position.y - transform.localScale.y / 2, transform.position.z),
                        new Vector3(0f, 0f, -1f),
                        DeltaAngle
                    );
                    currentPosition = Position.Y;
                    break;
                case Position.Y:
                    transform.RotateAround(
                        new Vector3(transform.position.x + transform.localScale.y / 2, transform.position.y - transform.localScale.x / 2, transform.position.z),
                        new Vector3(0f, 0f, -1f),
                        DeltaAngle
                    );
                    currentPosition = Position.X;
                    break;
                case Position.Z:
                    transform.RotateAround(
                        new Vector3(transform.position.x + transform.localScale.y / 2, transform.position.y - transform.localScale.y / 2, transform.position.z),
                        new Vector3(0f, 0f, -1f),
                        DeltaAngle
                    );
                    break;
                default:
                    throw new Exception("Undefined block Position");
            }
        }

        public void FlipLeft(Transform transform, ref Position currentPosition)
        {
            switch (currentPosition)
            {
                case Position.X:
                    transform.RotateAround(
                        new Vector3(transform.position.x - transform.localScale.x / 2, transform.position.y - transform.localScale.y / 2, transform.position.z),
                        new Vector3(0f, 0f, 1f),
                        DeltaAngle
                    );
                    currentPosition = Position.Y;
                    break;
                case Position.Y:
                    transform.RotateAround(
                        new Vector3(transform.position.x - transform.localScale.y / 2, transform.position.y - transform.localScale.x / 2, transform.position.z),
                        new Vector3(0f, 0f, 1f),
                        DeltaAngle
                    );
                    currentPosition = Position.X;
                    break;
                case Position.Z:
                    transform.RotateAround(
                        new Vector3(transform.position.x - transform.localScale.y / 2, transform.position.y - transform.localScale.y / 2, transform.position.z),
                        new Vector3(0f, 0f, 1f),
                        DeltaAngle
                    );
                    break;
                default:
                    throw new Exception("Undefined block Position");
            }
        }

        public void FlipUp(Transform transform, ref Position currentPosition)
        {
            switch (currentPosition)
            {
                case Position.X:
                    transform.RotateAround(
                        new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z + transform.localScale.z / 2),
                        new Vector3(1f, 0f, 0f),
                        DeltaAngle
                    );
                    break;
                case Position.Y:
                    transform.RotateAround(
                        new Vector3(transform.position.x, transform.position.y - transform.localScale.x / 2, transform.position.z + transform.localScale.z / 2),
                        new Vector3(1f, 0f, 0f),
                        DeltaAngle
                    );
                    currentPosition = Position.Z;
                    break;
                case Position.Z:
                    transform.RotateAround(
                        new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z + transform.localScale.x / 2),
                        new Vector3(1f, 0f, 0f),
                        DeltaAngle
                    );
                    currentPosition = Position.Y;
                    break;
                default:
                    throw new Exception("Undefined block Position");
            }
        }

        public void FlipDown(Transform transform, ref Position currentPosition)
        {
            switch (currentPosition)
            {
                case Position.X:
                    transform.RotateAround(
                        new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z - transform.localScale.z / 2),
                        new Vector3(-1f, 0f, 0f),
                        DeltaAngle
                    );
                    break;
                case Position.Y:
                    transform.RotateAround(
                        new Vector3(transform.position.x, transform.position.y - transform.localScale.x / 2, transform.position.z - transform.localScale.z / 2),
                        new Vector3(-1f, 0f, 0f),
                        DeltaAngle
                    );
                    currentPosition = Position.Z;
                    break;
                case Position.Z:
                    transform.RotateAround(
                        new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z - transform.localScale.x / 2),
                        new Vector3(-1f, 0f, 0f),
                        DeltaAngle
                    );
                    currentPosition = Position.Y;
                    break;
                default:
                    throw new Exception("Undefined block Position");
            }
        }
    }
}