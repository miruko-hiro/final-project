using UnityEngine;

namespace FinalProject.Architecture.Helpers.Scripts
{
    public class TranslatorScreenToWorld
    {
        public Vector2 ScreenToWorldSpace(Vector2 screenPos, Camera cam, RectTransform area)
        {
            Vector2 worldPoint = cam.ScreenToWorldPoint(screenPos);
 
            Vector3 worldPos;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(area, worldPoint, cam, out worldPos))
            {
                return worldPos;
            }
 
            return worldPoint;
        }
    }
}