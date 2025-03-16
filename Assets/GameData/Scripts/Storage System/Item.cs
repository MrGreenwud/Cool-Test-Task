using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "Default Item", menuName = "Items/Default", order = 0)]
    public class Item : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _prefab;

        public Sprite Icon => _icon;
        public GameObject Prefab => _prefab;
    }
}