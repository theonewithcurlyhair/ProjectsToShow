/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.web.models;

import com.alpha.models.Employee;
import com.alpha.models.EmployeeFactory;
import com.alpha.models.IEmployee;
import com.alpha.models.IGetEmployeeDetailDto;
import com.alpha.models.ITask;
import com.alpha.models.ITeam;
import com.alpha.models.TaskFactory;
import com.alpha.models.TeamFactory;
import java.util.List;

/**
 *
 * @author Mike
 */
public class EmployeeViewModel extends EmployeeFactory {

    private IEmployee employee = EmployeeFactory.createInstance();

    private List<ITask> skills = TaskFactory.createListInstance();

    private List<ITask> employeeSkills = TaskFactory.createListInstance();

    private ITeam empoyeeTeam = TeamFactory.createInstance();

    public EmployeeViewModel() {
    }

    public EmployeeViewModel(IGetEmployeeDetailDto getEmpDTO) {
        this.employee = getEmpDTO.getEmployee();
        this.empoyeeTeam = getEmpDTO.getEmployeeTeam();
        this.employeeSkills = getEmpDTO.getEmployeeSkills();
    }

    public IEmployee getEmployee() {
        return employee;
    }

    public void setEmployee(IEmployee employee) {
        this.employee = employee;
    }

    public List<ITask> getTasks() {
        return skills;
    }

    public void setTasks(List<ITask> tasks) {
        this.skills = tasks;
    }

    public List<ITask> getEmployeeTasks() {
        return employeeSkills;
    }

    public void setEmployeeTasks(List<ITask> tasks) {
        this.employeeSkills = tasks;
    }

}
