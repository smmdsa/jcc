using TMPro;
using UnityEngine;

namespace Program.client.v2.components
{
    public class EmployeesCounterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text counterLabel;
        public void UpdateView(int amount) => counterLabel.text =$" {amount:000}";

    }
}