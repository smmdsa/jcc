using Program.client;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Program.client.CustomGameEvents;

public class EmployeeCardComponent : MonoBehaviour
{
    [SerializeField] private Image pictureImg;
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text roleLabel;
    [SerializeField] private TMP_Text salaryLabel;
    [SerializeField] private Button mCardButton;
    [SerializeField] private EmployeeDataEvent employeeDataCardUnityEvent;
    
    public void InitializeCard(EmployeeDataCard dataCard)
    {
        nameLabel.text = $"{ dataCard._Employee.Seniority.ShortSeniorityLabel} { dataCard._Employee.Name }";
        roleLabel.text = dataCard._Employee.Role.GetType().Name;
        salaryLabel.text = $"{dataCard._Employee.Salary.CurrentSalary:C}";
        
        OnButtonClickedInitialize(dataCard);
    }

    private void OnButtonClickedInitialize(EmployeeDataCard dataCard)
    {
        mCardButton.onClick.RemoveAllListeners();
        mCardButton.onClick.AddListener(()=> employeeDataCardUnityEvent.Invoke(dataCard));
    }
}

public struct EmployeeDataCard
{
    //-- no implemented 
    //--- public Sprite mPhoto;
    public Salary PrevSalary;
    public Employee _Employee;

    public EmployeeDataCard(Employee employee)
    {
        PrevSalary = employee.Salary.Clone();
        _Employee = employee;
    }
}