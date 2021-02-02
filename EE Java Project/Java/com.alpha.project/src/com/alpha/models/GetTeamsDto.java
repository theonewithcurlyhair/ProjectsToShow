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
 * @author MSI
 */
public class GetTeamsDto implements IGetTeamsDto {

    protected ITeam empoyeeTeam;
    protected List<IEmployee> teamEmployees;
    protected ArrayList<IError> errors;

    public GetTeamsDto() {

    }

    public GetTeamsDto(ITeam team, List<IEmployee> emps) {

    }

    @Override
    public ITeam getTeam() {
        return empoyeeTeam;
    }

    @Override
    public List<IEmployee> getTeamsEmployee() {
        return teamEmployees;
    }

    @Override
    public void setTeam(ITeam team) {
        this.empoyeeTeam = team;
    }

    @Override
    public void setTeamEmployees(List<IEmployee> employees) {
        this.teamEmployees = employees;
    }

    @Override
    public ArrayList<IError> getErrors() {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void addError(IError error) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

}
