using UnityEngine;

namespace CAFU.Spawner.Utility
{
    public static class RectExtension
    {
        public static Vector2 RandomPosition(this Rect rect)
        {
            var x = (rect.xMax - rect.xMin) * Random.value + rect.xMin;
            var y = (rect.yMax - rect.yMin) * Random.value + rect.yMin;
            return new Vector2(x, y);
        }
    }
}