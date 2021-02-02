/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Mike
 */
public class GetEmployeeDetailDto implements IGetEmployeeDetailDto {

    protected IEmployee employee;
    protected ITeam empoyeeTeam;
    protected List<ITask> employeeSkills;
    protected ArrayList<IError> errors;

    GetEmployeeDetailDto() {

    }

    GetEmployeeDetailDto(IEmployee emp, List<ITask> skills, ITeam team) {
        this.employee = emp;
        this.employeeSkills = skills;
        this.empoyeeTeam = team;
    }

    @Override
    public IEmployee getEmployee() {
        return this.employee;
    }

    @Override
    public ITeam getEmployeeTeam() {
        return this.empoyeeTeam;
    }

    @Override
    public List<ITask> getEmployeeSkills() {
        return this.employeeSkills;
    }

    @Override
    public void setEmployee(IEmployee employee) {
        this.employee = employee;
    }

    @Override
    public void setEmployeeTeam(ITeam team) {
        this.empoyeeTeam = team;
    }

    @Override
    public void setEmployeeSkills(List<ITask> tasks) {
        this.employeeSkills = tasks;
    }

    @Override
    public ArrayList<IError> getErrors() {
        return this.errors;
    }

    @Override
    public void addError(IError error) {
        errors.add(error);
    }

    @Override
    public void addSkill(ITask task) {
        employeeSkills.add(task);
    }

}
