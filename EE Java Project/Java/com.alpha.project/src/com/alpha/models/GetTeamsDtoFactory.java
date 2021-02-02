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
public abstract class GetTeamsDtoFactory {

    public static IGetTeamsDto createInstance() {
        return new GetTeamsDto();
    }

    public static IGetTeamsDto createInstance(ITeam team, List<IEmployee> emps) {
        return new GetTeamsDto(team, emps);
    }
}
