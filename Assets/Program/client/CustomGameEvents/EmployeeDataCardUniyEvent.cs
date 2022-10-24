using System;
using UnityEngine.Events;

namespace Program.client.CustomGameEvents
{
    [Serializable]
    public class EmployeeDataCardUnityEvent : UnityEvent<EmployeeDataCard>
    {
    }
}