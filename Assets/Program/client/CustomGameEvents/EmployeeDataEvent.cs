using Bricksloader.ScriptableEventsV2;
using UnityEngine;

namespace Program.client.CustomGameEvents
{
    [CreateAssetMenu(menuName = "Create EmployeeDataEvent", fileName = "EmployeeDataEvent_", order = 0)]
    public class EmployeeDataEvent : BaseGameEvent<EmployeeDataCard>
    {
        public void Invoke(EmployeeDataCard data) => Rise(data);
    }
}