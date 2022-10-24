using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmplloyeDetailsPopupHandler : MonoBehaviour
{
    [SerializeField] private Image pictureImg;
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text roleLabel;
    [SerializeField] private TMP_Text salaryLabel;
    [SerializeField] private Button revertBtn;
    [SerializeField] private Button applyIncrementBtn;

    private EmployeeDataCard _dataCard;
    
    internal void InitializePopup(EmployeeDataCard dataCard)
    {
            UpdatePopupView(dataCard);
            _dataCard= dataCard;
            OnButtonClickedInitialize(dataCard);
    }

    private void UpdatePopupView(EmployeeDataCard dataCard)
    {
        nameLabel.text = $" {dataCard._Employee.Seniority.ShortSeniorityLabel}  {dataCard._Employee.Name}";
        roleLabel.text = dataCard._Employee.Role.GetType().Name;
        salaryLabel.text = $"{dataCard._Employee.Salary.CurrentSalary:C}";
    }

    private void OnButtonClickedInitialize(EmployeeDataCard dataCard)
    {
        revertBtn.onClick.RemoveAllListeners();
        applyIncrementBtn.onClick.RemoveAllListeners();
        revertBtn.onClick.AddListener(()=>OnRevertClicked(dataCard));
        applyIncrementBtn.onClick.AddListener(()=>OnApplyIncrementClicked(dataCard));
    }

    private void OnRevertClicked(EmployeeDataCard dataCard)
    {
        dataCard._Employee.UpdateSalary(dataCard.PrevSalary);
        UpdatePopupView(dataCard);
    }

    private void OnApplyIncrementClicked(EmployeeDataCard dataCard)
    {
        dataCard._Employee.Role.CalculateIncrement();
        UpdatePopupView(dataCard);

    }
}
