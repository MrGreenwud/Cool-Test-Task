using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class SlotView : ISlotView
    {
        private Image _image;

        public SlotView(Image image)
        {
            _image = image;
        }

        public void Update(Item item)
        {
            if (item == null)
            {
                _image.gameObject.SetActive(false);
                _image.sprite = null;
            }
            else
            {
                _image.gameObject.SetActive(true);
                _image.sprite = item.Icon;
            }
        }
    }
}