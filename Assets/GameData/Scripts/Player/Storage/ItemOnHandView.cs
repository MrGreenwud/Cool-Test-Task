using UnityEngine;
using System.Collections.Generic;
using Enigmatic.Experimental.Eniject;

namespace Gameplay
{
    public class ItemOnHandView : MonoBehaviour, IConstructable
    {
        [SerializeField] private Transform _hand;

        private Dictionary<GameObject, GameObject> _registeredItemOnHand = new Dictionary<GameObject, GameObject>();

        private SlotSelector _slotSelector;

        public void Construct()
        {
            _slotSelector = GlobalContainer.Get<SlotSelector>();
        }

        private void OnEnable()
        {
            _slotSelector.Model.ChangeSelectedSlot += SwitchItem;
        }

        private void OnDisable()
        {
            _slotSelector.Model.ChangeSelectedSlot -= SwitchItem;
        }

        private void SwitchItem(Slot slot)
        {
            if(_slotSelector.LastSelectedSlot != null)
                _slotSelector.LastSelectedSlot.Model.OnItemChanged -= SwitchItem;
            
            _slotSelector.SelectedSlot.Model.OnItemChanged += SwitchItem;

            SwitchItem(slot.Model.Item);
        }

        private void SwitchItem(Item item)
        {
            if (item == null)
            {
                _hand.gameObject.SetActive(false);
                return;
            }

            _hand.gameObject.SetActive(true);

            if (_registeredItemOnHand.ContainsKey(item.Prefab) == false)
            {
                GameObject gameObject = Instantiate(item.Prefab, _hand);
                gameObject.transform.localPosition = Vector3.zero;
                Destroy(gameObject.GetComponent<ItemObject>());
                Destroy(gameObject.GetComponent<Rigidbody>());
                Destroy(gameObject.GetComponent<Collider>());
                _registeredItemOnHand.Add(item.Prefab, gameObject);
                gameObject.SetActive(false);
            }

            _registeredItemOnHand[item.Prefab].SetActive(true);
        }
    }
}