/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

import java.util.List;

/**
 *
 * @author Mike
 */
public abstract class GetEmployeeDetailDtoFactory {

    public static IGetEmployeeDetailDto createInstance() {
        return new GetEmployeeDetailDto();
    }

    public static IGetEmployeeDetailDto createInstance(IEmployee emp, ITeam team, List<ITask> skills) {
        return new GetEmployeeDetailDto(emp, skills, team);
    }
}
