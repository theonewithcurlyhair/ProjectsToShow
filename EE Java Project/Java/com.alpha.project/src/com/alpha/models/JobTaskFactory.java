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
public class JobTaskFactory {
    public static IJobTask createInstance(){
        return new JobTask();
    }
    
    public static IJobTask createInstance(int taskId, int jobId, double operatingCost, double operatingRevenue){
        return new JobTask(taskId, jobId, operatingCost, operatingRevenue);
    }
}
