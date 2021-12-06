using FinalProject.Architecture.Characters.Scripts.Types;

namespace FinalProject.Architecture.Items.Scripts
{
    public interface IItemProperties
    {
        public ItemType ItemType { get; set; }
        public int SpriteIndex { get; set; }
        public int Price { get; }
        public string Name { get; }
        
        public string GetString();
    }
}