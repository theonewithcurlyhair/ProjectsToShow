/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.service;

import com.alpha.models.IGetTeamsDto;
import com.alpha.models.ITask;
import com.alpha.models.ITeam;
import java.util.List;

/**
 *
 * @author Nik
 */
public interface ITeamService {
    ITeam createTeam(ITeam team);
    int saveTeam(ITeam team);
    int deleteTeam(int id);
    
    IGetTeamsDto getTeam(int id);
    List<IGetTeamsDto> getTeams();

    List<IGetTeamsDto> getAvailableTeams(List<ITask> tasks);

    int setTeamOnCall(int id);
}
