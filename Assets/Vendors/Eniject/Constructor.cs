using UnityEngine;

namespace Enigmatic.Experimental.Eniject
{
    [DefaultExecutionOrder(-998)]
    public class Constructor : MonoBehaviour
    {
        private void Awake()
        {
            GameObject[] rootObjects = gameObject.scene.GetRootGameObjects();

            foreach (GameObject gameObject in rootObjects)
                ConstructChildren(gameObject);
        }

        public static GameObject Instantiate(GameObject gameObject)
        {
            GameObject newGameObject = GameObject.Instantiate(gameObject);
            ConstructChildren(newGameObject);
            return newGameObject;
        }

        public static void AddComponent<T>(GameObject gameObject)
        {
            Component component = gameObject.AddComponent(typeof(T));

            if (component is IConstructable constructable)
                constructable.Construct();
        }

        public static void Construct(IConstructable constructable)
        {
            constructable.Construct();
        }

        public static void ConstructChildren(GameObject gameObject)
        {
            ConstructGameObject(gameObject);

            if (gameObject.transform.childCount == 0)
                return;

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Transform child = gameObject.transform.GetChild(i);
                ConstructChildren(child.gameObject);
            }
        }

        public static void ConstructGameObject(GameObject gameObject)
        {
            MonoBehaviour[] components = gameObject.GetComponents<MonoBehaviour>();

            foreach (MonoBehaviour component in components)
            {
                if (component is IConstructable constructable)
                    constructable.Construct();
            }
        }
    }
}