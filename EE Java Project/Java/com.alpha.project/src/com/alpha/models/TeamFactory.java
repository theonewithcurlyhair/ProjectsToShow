/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

import java.sql.Date;
import java.util.List;

/**
 *
 * @author Nik
 */
public abstract class TeamFactory {
    public static ITeam createInstance(){
        return new Team();
    }
    
    public static ITeam createInstance(String name, boolean isOnCall, List<IEmployee> teamMembers){
        return new Team(name, isOnCall, teamMembers);
    }

    public static ITeam createInstance(int id, String name, boolean isOnCall, Date createdAt, Date deletedAt, Date updatedAt) {
        return new Team(id, name, isOnCall, createdAt, deletedAt, updatedAt);
    }
}
