using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HSJ
{
    public class Slot : MonoBehaviour
    {
        public Button[] slotButtons = new Button[3];
        public Data data = new Data();

        private void Start()
        {
            for (int i = 0; i < slotButtons.Length; i++)
            {
                int slot = i;
                slotButtons[i].onClick.AddListener(() => Select(slot));
            }
        }

        public void Select(int slot)
        {
            data = DataManager.Instance.Load(slot);
            if (data != null)
            {
                SoundManager.Instance.PlaySoundEffect("Correct");
                slotButtons[slot].GetComponentInChildren<TMP_Text>().text = slot.ToString();
            }
            else
            {
                SoundManager.Instance.PlaySoundEffect("Warning");
                slotButtons[slot].GetComponentInChildren<TMP_Text>().text = "No save data found in slot";
                Debug.LogWarning("No save data found in slot " + slot);
            }
        }
    }
}
