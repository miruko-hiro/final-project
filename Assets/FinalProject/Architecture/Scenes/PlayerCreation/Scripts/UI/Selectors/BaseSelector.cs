using System;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.PlayerCreation.Scripts.UI.Selectors
{
    public class BaseSelector : MonoBehaviour
    {
        public event Action<SelectionType> Changed;

        public void OnLeftButtonClick()
        {
            Changed?.Invoke(SelectionType.Prev);
        }

        public void OnRightButtonClick()
        {
            Changed?.Invoke(SelectionType.Next);
        }
    }
}