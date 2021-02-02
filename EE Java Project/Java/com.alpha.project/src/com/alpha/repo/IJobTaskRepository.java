/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.repo;

import com.alpha.models.IJobTask;
import java.util.List;

/**
 *
 * @author Nik
 */
public interface IJobTaskRepository {

    int deleteJobTask(IJobTask jobTask);

    IJobTask insertJobTask(IJobTask jobTask);

    IJobTask retrieveJobTask(int teamId, int taskId);

    List<IJobTask> retrieveJobTasks(int jobId);

    int updateJobTask(IJobTask jobTask);
    
    IJobTask getJobTaskTotals(int taskId, int teamId);
    
}
