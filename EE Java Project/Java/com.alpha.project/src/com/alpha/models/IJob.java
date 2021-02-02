/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

import java.util.Date;
import org.joda.time.DateTime;

/**
 *
 * @author Nik
 */
public interface IJob {

    /**
     * @return the clientName
     */
    String getClientName();

    /**
     * @return the description
     */
    String getDescription();

    /**
     * @return the end
     */
    DateTime getEnd();

    /**
     * @return the id
     */
    int getId();

    /**
     * @return the start
     */
    DateTime getStart();

    /**
     * @return the teamId
     */
    int getTeamId();

    /**
     * @param clientName the clientName to set
     */
    void setClientName(String clientName);

    /**
     * @param description the description to set
     */
    void setDescription(String description);

    /**
     * @param end the end to set
     */
    void setEnd(DateTime end);

    /**
     * @param id the id to set
     */
    void setId(int id);

    /**
     * @param start the start to set
     */
    void setStart(DateTime start);

    /**
     * @param teamId the teamId to set
     */
    void setTeamId(int teamId);
    
    
    void calculateEndDateTime(int durationMins);
    
    String getStartString();
    
    String getEndString();
}
