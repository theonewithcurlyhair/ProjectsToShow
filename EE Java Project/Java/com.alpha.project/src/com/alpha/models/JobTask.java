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
public class JobTask implements IJobTask {
    private int taskId;
    private int jobId;
    private double operatingCost;
    private double operatingRevenue;

    /**
     * @return the taskId
     */
    @Override
    public int getTaskId() {
        return taskId;
    }

    /**
     * @return the jobId
     */
    @Override
    public int getJobId() {
        return jobId;
    }

    /**
     * @return the operatingCost
     */
    @Override
    public double getOperatingCost() {
        return operatingCost;
    }

    /**
     * @return the operatingRevenue
     */
    @Override
    public double getOperatingRevenue() {
        return operatingRevenue;
    }

    /**
     * @param taskId the taskId to set
     */
    @Override
    public void setTaskId(int taskId) {
        this.taskId = taskId;
    }

    /**
     * @param jobId the jobId to set
     */
    @Override
    public void setJobId(int jobId) {
        this.jobId = jobId;
    }

    /**
     * @param operatingCost the operatingCost to set
     */
    @Override
    public void setOperatingCost(double operatingCost) {
        this.operatingCost = operatingCost;
    }

    /**
     * @param operatingRevenue the operatingRevenue to set
     */
    @Override
    public void setOperatingRevenue(double operatingRevenue) {
        this.operatingRevenue = operatingRevenue;
    }
    
    
    public JobTask(){
        
    }
    
    public JobTask(int taskId, int jobId, double operatingCost, double operatingRevenue){
        this.taskId = taskId;
        this.jobId = jobId;
        this.operatingCost = operatingCost;
        this.operatingRevenue = operatingRevenue;
    }
    
    public JobTask(int id){
        this.taskId = id;
    }
}
