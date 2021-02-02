/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 *
 * @author Nik
 */
public class Team extends Base implements ITeam {

    Team(int id, String name, boolean onCall, java.sql.Date createdAt, java.sql.Date deletedAt, java.sql.Date updatedAt) {
        this.id = id;
        this.name = name;
        this.isOnCall = onCall;
        this.createdAt = createdAt;
        this.deletedAt = deletedAt;
        this.updatedAt = updatedAt;
    }

    /**
     * @return the id
     */
    public int getId() {
        return id;
    }

    /**
     * @param id the id to set
     */
    public void setId(int id) {
        this.id = id;
    }

    /**
     * @return the name
     */
    public String getName() {
        return name;
    }

    /**
     * @param name the name to set
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * @return the isOnCall
     */
    public boolean getIsOnCall() {
        return isOnCall;
    }

    /**
     * @param isOnCall the isOnCall to set
     */
    public void setIsOnCall(boolean isOnCall) {
        this.isOnCall = isOnCall;
    }

    /**
     * @return the isDeleted
     */
    public boolean isIsDeleted() {
        return isDeleted;
    }

    /**
     * @param isDeleted the isDeleted to set
     */
    public void setIsDeleted(boolean isDeleted) {
        this.isDeleted = isDeleted;
    }

    /**
     * @return the createdAt
     */
    public Date getCreatedAt() {
        return createdAt;
    }

    /**
     * @param createdAt the createdAt to set
     */
    public void setCreatedAt(Date createdAt) {
        this.createdAt = createdAt;
    }

    /**
     * @return the updatedAt
     */
    public Date getUpdatedAt() {
        return updatedAt;
    }

    /**
     * @param updatedAt the updatedAt to set
     */
    public void setUpdatedAt(Date updatedAt) {
        this.updatedAt = updatedAt;
    }

    /**
     * @return the deletedAt
     */
    public Date getDeletedAt() {
        return deletedAt;
    }

    /**
     * @param deletedAt the deletedAt to set
     */
    public void setDeletedAt(Date deletedAt) {
        this.deletedAt = deletedAt;
    }
    
    public List<IEmployee> getTeamMembers(){
        return this.teamMembers;
    }
    
    public void setTeamMbers(List<IEmployee> teamMembers){
        this.teamMembers = teamMembers;
    }
    
    //Props
    private int id;
    private String name;
    private boolean isOnCall;
    private boolean isDeleted;
    private Date createdAt;
    private Date updatedAt;
    private Date deletedAt;
    private List<IEmployee> teamMembers;
    private boolean hasJob = false;
    
    
    
    public Team(){
        
    }
    
    public Team(String name, boolean isOnCall, List<IEmployee> teamMembers){
        this.name = name;
        this.isOnCall = isOnCall;
        this.teamMembers = teamMembers;
    }
    
    @Override
    public ArrayList<IError> getErrors(){
        return super.getErrors();
    }
    
    @Override
    public void addError(IError error){
        super.addError(error);
    }

    @Override
    public void setHasJob(boolean b) {
        this.hasJob = b;
    }

    @Override
    public boolean getHasJob() {
        return hasJob;
    }
}
