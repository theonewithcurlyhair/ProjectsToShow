/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.service;

import com.alpha.models.IJobTask;
import java.util.List;

/**
 *
 * @author Nik
 */
public interface IJobTaskService {

    IJobTask createJobTask(IJobTask jobTask);

    int deleteJobTask(IJobTask jobTask);

    IJobTask getJobTask(int teamId, int taskId);

    List<IJobTask> getJobTasks(int jobId);

    int saveJobTask(IJobTask jobTask);
    
    IJobTask getJobTaskTotals(int taskId, int teamId);
    
}
