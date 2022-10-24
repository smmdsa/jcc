using UnityEngine;

public class EmployeeDataDetailsPopupController : MonoBehaviour
{
    [SerializeField] private EmplloyeDetailsPopupHandler _detailsPopupHandler;
    [SerializeField] private GameObject _popupContainer;
    public void DataReceived(EmployeeDataCard employeeDataCard)
    {
        _detailsPopupHandler.InitializePopup(employeeDataCard);
        _popupContainer.SetActive(true);
        
    }
}
