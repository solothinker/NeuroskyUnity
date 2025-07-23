using UnityEngine;

namespace MindWave
{
    public class SaveUI : MonoBehaviour
    {
        private static SaveUI instance;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }
}

