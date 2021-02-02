/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

import java.util.Date;
import java.util.Locale;
import org.joda.time.DateTime;
import org.joda.time.format.DateTimeFormat;
import org.joda.time.format.DateTimeFormatter;

/**
 *
 * @author Nik
 */
public class Job implements IJob {

    private int id;
    private int teamId;
    private String description;
    private String clientName;
    private DateTime start;
    private DateTime end;

    /**
     * @return the id
     */
    @Override
    public int getId() {
        return id;
    }

    /**
     * @return the teamId
     */
    @Override
    public int getTeamId() {
        return teamId;
    }

    /**
     * @return the description
     */
    @Override
    public String getDescription() {
        return description;
    }

    /**
     * @return the clientName
     */
    @Override
    public String getClientName() {
        return clientName;
    }

    /**
     * @return the start
     */
    @Override
    public DateTime getStart() {
        return start;
    }

    /**
     * @return the end
     */
    @Override
    public DateTime getEnd() {
        return end;
    }

    /**
     * @param id the id to set
     */
    @Override
    public void setId(int id) {
        this.id = id;
    }

    /**
     * @param teamId the teamId to set
     */
    @Override
    public void setTeamId(int teamId) {
        this.teamId = teamId;
    }

    /**
     * @param description the description to set
     */
    @Override
    public void setDescription(String description) {
        this.description = description;
    }

    /**
     * @param clientName the clientName to set
     */
    @Override
    public void setClientName(String clientName) {
        this.clientName = clientName;
    }

    /**
     * @param start the start to set
     */
    @Override
    public void setStart(DateTime start) {
        this.start = start;
    }

    /**
     * @param end the end to set
     */
    @Override
    public void setEnd(DateTime end) {
        this.end = end;
    }

    public Job() {

    }

    
    
    public Job(int id, int teamId, String description, String clientName, DateTime start, DateTime end) {
        this.id = id;
        this.teamId = teamId;
        this.description = description;
        this.clientName = clientName;
        this.start = start;
        this.end = end;
    }

    
    
    @Override
    public void calculateEndDateTime(int taskDurationMins) {
        this.end = this.start.plusMinutes(taskDurationMins);
    }

    @Override
    public String getStartString() {
        
        DateTimeFormatter fmt = DateTimeFormat.mediumDateTime();
        return this.start.toString(fmt);
        
    }

    @Override
    public String getEndString() {
        DateTimeFormatter fmt = DateTimeFormat.mediumDateTime();
        return this.end.toString(fmt);
    }
}
