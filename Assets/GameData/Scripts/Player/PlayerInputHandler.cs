using UnityEngine;

namespace Gameplay
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [Header("Move Axes")]
        [SerializeField] private string MoveHorizontalAxisName;
        [SerializeField] private string MoveVerticalAxisName;

        [Space(10)]

        [Header("Head Rotate Axes")]
        [SerializeField] private string HeadRotateX;
        [SerializeField] private string HeadRotateY;

        [Space(10)]

        [SerializeField] private string RunButtonName;
        [SerializeField] private string InteractButtonName;
        [SerializeField] private string DropButtenName;

        [Space(10)]

        [SerializeField] private string HotBarScrollWheelName;
        [SerializeField] private string HotBarScrollButtonName;

        public Vector2 GetMoveDirection()
        {
            float x = Input.GetAxis(MoveHorizontalAxisName);
            float y = Input.GetAxis(MoveVerticalAxisName);

            return new Vector2(x, y);
        }

        public Vector2 GetHeadRotationDirection()
        {
            float x = Input.GetAxis(HeadRotateX);
            float y = Input.GetAxis(HeadRotateY);

            return new Vector2(x, y);
        }

        public bool RunButtonPressed()
        {
            return Input.GetButton(RunButtonName);
        }

        public bool InteractButtonDown()
        {
            return Input.GetButtonDown(InteractButtonName);
        }

        public int HotBarScrollDirection()
        {
            float direction = Input.GetAxis(HotBarScrollWheelName);

            if(direction == 0)
                direction = Input.GetAxis(HotBarScrollButtonName);

            if (direction > 0)
                return 1;
            else if(direction < 0)
                return -1;

            return 0;
        }

        public int HotBarNumeric()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                return 0;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                return 1;
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                return 2;
            else if (Input.GetKeyDown(KeyCode.Alpha4))
                return 3;
            else if (Input.GetKeyDown(KeyCode.Alpha5))
                return 4;
            else if (Input.GetKeyDown(KeyCode.Alpha6))
                return 5;
            else if (Input.GetKeyDown(KeyCode.Alpha7))
                return 6;
            else if (Input.GetKeyDown(KeyCode.Alpha8))
                return 7;
            else if (Input.GetKeyDown(KeyCode.Alpha9))
                return 8;
            else if (Input.GetKeyDown(KeyCode.Alpha0))
                return 9;

            return -1;
        }

        public bool DropButtonDown()
        {
            return Input.GetButton(DropButtenName);
        }
    }
}