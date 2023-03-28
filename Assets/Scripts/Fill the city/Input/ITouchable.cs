using UnityEngine;

namespace FillTheCity
{
    public interface ITouchable
    {
        void OnTouchDown(Vector3 point);
        void OnTouch(Vector3 point);
        void OnTouchUp(Vector3 point);
    }
}
