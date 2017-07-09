using System;
using UnityEngine;

namespace Scripts.Block
{
    public class Block : MonoBehaviour
    {
        [SerializeField]
        private Position _currentPosition;
        private const float DeltaAngle = 90f;

        public Position CurrentPosition
        {
            get
            {
                return _currentPosition;
            }
            set
            {
                _currentPosition = value;
            }
        }

        #region MonoBehavior Members
        private void Start()
        {
            
        }
        #endregion

        public void FlipRight()
        {
            switch (CurrentPosition)
            {
                case Position.X:
                    transform.RotateAround(
                        new Vector3(transform.position.x + transform.localScale.x / 2, transform.position.y - transform.localScale.y / 2, transform.position.z),
                        new Vector3(0f, 0f, -1f),
                        DeltaAngle
                    );
                    CurrentPosition = Position.Y;
                    break;
                case Position.Y:
                    break;
                case Position.Z:
                    break;
                default:
                    throw new Exception("Undefined block Position");
            }
        }

        public void FlipLeft()
        {
            switch (_currentPosition)
            {
                case Position.X:
                    transform.RotateAround(
                        new Vector3(transform.position.x - transform.localScale.x / 2, transform.position.y - transform.localScale.y / 2, transform.position.z),
                        new Vector3(0f, 0f, 1f),
                        DeltaAngle
                    );
                    CurrentPosition = Position.Y;
                    break;
                case Position.Y:
                    break;
                case Position.Z:
                    break;
                default:
                    throw new Exception("Undefined block Position");
            }
        }

        public void FlipUp()
        {
            switch (_currentPosition)
            {
                case Position.X:
                    transform.RotateAround(
                        new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z + transform.localScale.z / 2),
                        new Vector3(1f, 0f, 0f),
                        DeltaAngle
                    );
                    break;
                case Position.Y:
                    break;
                case Position.Z:
                    break;
                default:
                    throw new Exception("Undefined block Position");
            }
        }

        public void FlipDown()
        {
            switch (_currentPosition)
            {
                case Position.X:
                    transform.RotateAround(
                        new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z - transform.localScale.z / 2),
                        new Vector3(-1f, 0f, 0f),
                        DeltaAngle
                    );
                    break;
                case Position.Y:
                    break;
                case Position.Z:
                    break;
                default:
                    throw new Exception("Undefined block Position");
            }
        }
    }
}
