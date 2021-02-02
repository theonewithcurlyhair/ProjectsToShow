/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.repo;

import com.alpha.models.IEmployee;
import com.alpha.models.IGetTeamsDto;
import com.alpha.models.ITask;
import com.alpha.models.ITeam;
import java.util.List;

/**
 *
 * @author Nik
 */
public interface ITeamRepository {
    int insertTeam(ITeam team);
    int updateTeam(ITeam team);
    List<IGetTeamsDto> retrieveTeams();
    IGetTeamsDto retrieveTeam(int id);

    int deleteTeam(int id);
    
    List<ITeam> retrieveAvailableTeams(List<ITask> tasks);
List<IEmployee> retrieveTeamMembers(int teamId);
    int setTeamOnCall(int id);
}
