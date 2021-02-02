/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

import java.util.Date;
import java.util.List;

/**
 *
 * @author Nik
 */
public interface ITeam extends IBase {
    
    /**
     * @return the id
     */
    int getId();

    /**
     * @param id the id to set
     */
    void setId(int id);

    /**
     * @return the name
     */
    String getName();
    /**
     * @param name the name to set
     */
    void setName(String name);

    /**
     * @return the isOnCall
     */
    boolean getIsOnCall();

    /**
     * @param isOnCall the isOnCall to set
     */
    void setIsOnCall(boolean isOnCall);

    /**
     * @return the isDeleted
     */
    boolean isIsDeleted();

    /**
     * @param isDeleted the isDeleted to set
     */
    void setIsDeleted(boolean isDeleted);

    /**
     * @return the createdAt
     */
    Date getCreatedAt();

    /**
     * @param createdAt the createdAt to set
     */
    void setCreatedAt(Date createdAt);

    /**
     * @return the updatedAt
     */
    Date getUpdatedAt();

    /**
     * @param updatedAt the updatedAt to set
     */
    void setUpdatedAt(Date updatedAt);

    /**
     * @return the deletedAt
     */
    Date getDeletedAt();

    /**
     * @param deletedAt the deletedAt to set
     */
    void setDeletedAt(Date deletedAt);
    
    List<IEmployee> getTeamMembers();
    
    void setTeamMbers(List<IEmployee> teamMembers);

    void setHasJob(boolean b);
    
    boolean getHasJob();
}
