using System.Collections.Generic;
using Program.client;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeScrollViewHandler : MonoBehaviour
{
    [SerializeField] private EmployeeCardComponent employeeCard;
    [SerializeField] private RectTransform cardsContainer;
    [SerializeField] private Scrollbar scrollbar;

    private List< EmployeeCardComponent> EmployeeCardComponents =>
        _employeeCardComponents ??= new List< EmployeeCardComponent>();
    private List< EmployeeCardComponent> _employeeCardComponents;
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
        DefineRectContainerFor(employees);
        LoadEmployeesCards(employees);
        ResetScrollbarPosition();
    }

    private void LoadEmployeesCards(List<Employee> employees)
    {
        if (EmployeeCardComponents.Count == 0)
            StartFromScratch(employees);
        else
            ReusePrevCards(employees);
    }
    private void ResetScrollbarPosition() =>
        scrollbar.value = 1;
    
    private void DefineRectContainerFor(List<Employee> employees)
    {
        var rows = employees.Count / 5;
        var _Y = 200 * rows;
        var _X = (220 * 5);
        cardsContainer.sizeDelta = new Vector2(_X, _Y);
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
            EmployeeCardComponents.Add( nC);
        }
    }
}