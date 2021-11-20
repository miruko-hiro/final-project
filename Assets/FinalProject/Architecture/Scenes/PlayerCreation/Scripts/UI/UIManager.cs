using System;
using FinalProject.Architecture.Scenes.PlayerCreation.Scripts.UI.Selectors;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FinalProject.Architecture.Scenes.PlayerCreation.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private BaseSelector genderTypeSelector;
        [SerializeField] private BaseSelector hairStyleSelector;
        [SerializeField] private BaseSelector hairColorSelector;
        [SerializeField] private BaseSelector beardStyleSelector;
        [SerializeField] private BaseSelector beardColorSelector;

        public event Action<SelectionType> ChangedGenderType;
        public event Action<SelectionType> ChangedHairStyle;
        public event Action<SelectionType> ChangedHairColor;
        public event Action<SelectionType> ChangedBeardStyle;
        public event Action<SelectionType> ChangedBeardColor;

        private void Awake()
        {
            OnOpen();
        }

        private void OnOpen()
        {
            genderTypeSelector.Changed += NotifyAboutChangeGenderType;
            hairStyleSelector.Changed += NotifyAboutChangeHairStyle;
            hairColorSelector.Changed += NotifyAboutChangeHairColor;
            beardStyleSelector.Changed += NotifyAboutChangeBeardStyle;
            beardColorSelector.Changed += NotifyAboutChangeBeardColor;
        }

        private void NotifyAboutChangeGenderType(SelectionType type)
        {
            ChangedGenderType?.Invoke(type);
        }

        private void NotifyAboutChangeHairStyle(SelectionType type)
        {
            ChangedHairStyle?.Invoke(type);
        }

        private void NotifyAboutChangeHairColor(SelectionType type)
        {
            ChangedHairColor?.Invoke(type);
        }

        private void NotifyAboutChangeBeardStyle(SelectionType type)
        {
            ChangedBeardStyle?.Invoke(type);
        }

        private void NotifyAboutChangeBeardColor(SelectionType type)
        {
            ChangedBeardColor?.Invoke(type);
        }

        public void OnCreate()
        {
            SceneManager.LoadScene("Battle");
        }

        private void OnClose()
        {
            genderTypeSelector.Changed -= NotifyAboutChangeGenderType;
            hairStyleSelector.Changed -= NotifyAboutChangeHairStyle;
            hairColorSelector.Changed -= NotifyAboutChangeHairColor;
            beardStyleSelector.Changed -= NotifyAboutChangeBeardStyle;
            beardColorSelector.Changed -= NotifyAboutChangeBeardColor;
        }

        private void OnDestroy()
        {
            OnClose();
        }
    }
}