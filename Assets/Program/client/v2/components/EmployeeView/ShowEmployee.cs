using TMPro;
using UnityEngine;

namespace Program.client.v2.components
{
    public class ShowEmployee : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown dropdown;

        private void Awake()
        {
            var optionDataList = new TMP_Dropdown.OptionDataList();
            for (var i = 0; i < 10; i++)
                optionDataList.options.Add(new TMP_Dropdown.OptionData($"hola-{i}"));
            

            dropdown.options = optionDataList.options;
            dropdown.onValueChanged.AddListener(foo);
        }

        private void foo(int index)
        {
            Debug.Log($"ITEM SELECTED: {dropdown.options[index].text} ");
        }
    }
}