/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.web.models;

import com.alpha.models.GetTeamsDto;
import com.alpha.models.IGetTeamsDto;
import com.alpha.models.ITeam;
import com.alpha.models.Team;


/**
 *
 * @author Nik
 */
public class TeamViewModel {
    private IGetTeamsDto team = new GetTeamsDto();
    
    public TeamViewModel(){}
    
    public ITeam getTeam(){
        return team.getTeam();
    }
    
    public void setTeam(IGetTeamsDto team){
        this.team = team;
    }
}
