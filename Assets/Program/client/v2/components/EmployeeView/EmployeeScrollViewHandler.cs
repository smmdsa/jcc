using System.Collections.Generic;
using System.Linq;
using Program.client;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeScrollViewHandler : MonoBehaviour
{
    [SerializeField] private EmployeeCardComponent employeeCard;
    [SerializeField] private RectTransform cardsContainer;
    [SerializeField] private Scrollbar scrollbar;

    private Dictionary<int, EmployeeCardComponent> EmployeeCardComponents =>
        _employeeCardComponents ??= new Dictionary<int, EmployeeCardComponent>();
    private Dictionary<int, EmployeeCardComponent> _employeeCardComponents;

    private List<Employee> EmployeesToShow
    {
        get => _employeesToShow ??= new List<Employee>();
        set
        {
            _employeesToShow = value;
            UpdateViewList(_employeesToShow);
        }
    }
    private List<Employee> _employeesToShow;

    public void EmployeeToShow(List<Employee> employees) => EmployeesToShow = employees;

    private void UpdateViewList(List<Employee> employees)
    {
        
        //load all the stuff
        var rows = employees.Count / 5;
        var _Y = 200 * rows;
        var _X = (220 * 5);
        cardsContainer.sizeDelta = new Vector2(_X, _Y);
        if (EmployeeCardComponents.Count == 0)
            StartFromScratch(employees);
        else
            ReusePrevCards(employees);
        //reset the scrollbar value
        scrollbar.value = 1;
    }

    private void ReusePrevCards(List<Employee> employees)
    {
        for (var i = 0; i < EmployeeCardComponents.Count; i++)
        {
            if (i >= employees.Count)
            {
                EmployeeCardComponents[i].gameObject.SetActive(false);
                continue;
            }
            EmployeeCardComponents[i].InitializeCard(new EmployeeDataCard( employees[i] ));
            EmployeeCardComponents[i].gameObject.SetActive(true);
        }
    }

    private void StartFromScratch(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            var nC = Instantiate(employeeCard, cardsContainer.transform);
            nC.InitializeCard(new EmployeeDataCard(employee));
            EmployeeCardComponents.Add(EmployeeCardComponents.Count, nC);
        }
    }
}