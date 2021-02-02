/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

/**
 *
 * @author Nik
 */
public interface IJobTask {

    /**
     * @return the jobId
     */
    int getJobId();

    /**
     * @return the operatingCost
     */
    double getOperatingCost();

    /**
     * @return the operatingRevenue
     */
    double getOperatingRevenue();

    /**
     * @return the taskId
     */
    int getTaskId();

    /**
     * @param jobId the jobId to set
     */
    void setJobId(int jobId);

    /**
     * @param operatingCost the operatingCost to set
     */
    void setOperatingCost(double operatingCost);

    /**
     * @param operatingRevenue the operatingRevenue to set
     */
    void setOperatingRevenue(double operatingRevenue);

    /**
     * @param taskId the taskId to set
     */
    void setTaskId(int taskId);
    
}
