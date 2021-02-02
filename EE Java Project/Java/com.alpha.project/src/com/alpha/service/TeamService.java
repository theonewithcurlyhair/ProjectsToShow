/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.service;

import com.alpha.models.IEmployee;
import com.alpha.models.IGetTeamsDto;
import com.alpha.models.ITask;
import com.alpha.models.ITeam;
import com.alpha.repo.EmployeeRepositoryFactory;
import com.alpha.repo.ITaskRepository;
import com.alpha.repo.ITeamRepository;
import com.alpha.repo.TaskRepoFactory;
import com.alpha.repo.TaskRepository;
import com.alpha.repo.TeamRepository;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

/**
 *
 * @author Nik
 */
public class TeamService implements ITeamService{

    private ITeamRepository teamRepo = new TeamRepository();
    private ITaskRepository taskRepo = new TaskRepository();
    
    @Override
    public ITeam createTeam(ITeam team) {
        return null;
    }

    @Override
    public int saveTeam(ITeam team) {
        return teamRepo.insertTeam(team);
    }

    @Override
    public int deleteTeam(int id) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public IGetTeamsDto getTeam(int id) {
        return teamRepo.retrieveTeam(id);
    }

    @Override
    public List<IGetTeamsDto> getTeams() {
        return teamRepo.retrieveTeams();
    }

   @Override
    public List<IGetTeamsDto> getAvailableTeams(List<ITask> tasks) {
        List<IGetTeamsDto> availableTeams = new ArrayList();
        List<IGetTeamsDto> allTeams = teamRepo.retrieveTeams();
        for(IGetTeamsDto team : allTeams){
            //select employees for the specific teams
            List<IEmployee> teamEmps = team.getTeamsEmployee();
            List<ITask> totalTasks = new ArrayList();
            
            for(IEmployee e : teamEmps){
                List<ITask> employeeTasks = taskRepo.retreiveEmpTasks(e.getId());
                employeeTasks.forEach(t-> totalTasks.add(t));
            }
            
            //check if mathincg
            int requiredTasksCount = tasks.size();
            int matchedTasksCount = 0;
            for(ITask t : totalTasks){
                matchedTasksCount = tasks.stream().filter((requiredT) -> (t.getId() == requiredT.getId())).map((_item) -> 1).reduce(matchedTasksCount, Integer::sum);
            }
            
            if(matchedTasksCount >= requiredTasksCount) availableTeams.add(team);
        }
        
        return availableTeams;
    }

    @Override
    public int setTeamOnCall(int id) {
        List<IGetTeamsDto> teams = teamRepo.retrieveTeams().stream().filter(t-> t.getTeam().getIsOnCall() == true).collect(Collectors.toList());
        if(teams.isEmpty()){
            return teamRepo.setTeamOnCall(id);
        }else{
            return 0;
        }
    }
}
