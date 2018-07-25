using CAFU.Spawner.Utility;
using UnityEngine;

namespace CAFU.Spawner.Presentation.View
{
    public static class TransformExtension
    {
        public static void SetRandomPositionInRectTransform(this Transform transform, RectTransform rect)
        {
            transform.SetRandomPositionByRect(rect.rect);
        }

        public static void SetRandomPositionByRect(this Transform transform, Rect rect)
        {
            var xy = rect.RandomPosition();
            transform.localPosition = new Vector3(xy.x, xy.y, transform.localPosition.z);
        }
    }
}