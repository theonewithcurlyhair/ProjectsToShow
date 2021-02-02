/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.repo;

import com.alpha.models.IJobTask;
import com.alpha.models.JobTask;

/**
 *
 * @author Nik
 */
public class JobTaskFactory {
    public static IJobTaskRepository createInstance(){
        return new JobTaskRepository();
    }

    public static IJobTask createInstance(int taskId, int jobId, double cost, double revenue) {
        return new JobTask(taskId, jobId, cost, revenue);
    }
}
