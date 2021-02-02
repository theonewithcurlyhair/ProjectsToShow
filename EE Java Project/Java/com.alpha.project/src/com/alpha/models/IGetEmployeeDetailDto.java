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
public interface IGetEmployeeDetailDto extends IBase {
    IEmployee getEmployee();
    ITeam getEmployeeTeam();
    List<ITask>getEmployeeSkills();
    
    void setEmployee(IEmployee employee);
    void setEmployeeTeam(ITeam team);
    void setEmployeeSkills(List<ITask> tasks);
    ArrayList<IError> getErrors();
    void addSkill(ITask task);
}
