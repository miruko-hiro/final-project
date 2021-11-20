using UnityEngine;

namespace Template.Creatures.Appearance.Armor
{
    public class BootsCollection : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private Sprite[] boots = new Sprite[12];
        public Sprite GetSprite(int index)
        {
            return boots[index];
        }
    }
}