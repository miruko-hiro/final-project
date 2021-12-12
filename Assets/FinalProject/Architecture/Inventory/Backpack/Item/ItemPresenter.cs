using FinalProject.Architecture.Items.Scripts;

namespace FinalProject.Architecture.Inventory.Backpack.Item
{
    public interface IItemPresenter
    {
        public IItemProperties ItemProperties { get; }
    }
}