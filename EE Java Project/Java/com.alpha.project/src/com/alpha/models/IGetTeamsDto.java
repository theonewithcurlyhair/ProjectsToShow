/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

import java.util.List;

/**
 *
 * @author MSI
 */
public interface IGetTeamsDto extends IBase {

    ITeam getTeam();

    List<IEmployee> getTeamsEmployee();

    void setTeam(ITeam team);

    void setTeamEmployees(List<IEmployee> employees);
}
