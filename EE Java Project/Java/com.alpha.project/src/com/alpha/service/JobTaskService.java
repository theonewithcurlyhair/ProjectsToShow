/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.service;

import com.alpha.models.IJobTask;
import com.alpha.repo.IJobTaskRepository;
import com.alpha.repo.JobTaskRepository;
import java.util.List;

/**
 *
 * @author Nik
 */
public class JobTaskService implements IJobTaskService {
    private IJobTaskRepository jobTaskRepo = new JobTaskRepository();
    
    @Override
    public IJobTask createJobTask(IJobTask jobTask){
        return jobTaskRepo.insertJobTask(jobTask);
    }
    
    @Override
    public int saveJobTask(IJobTask jobTask){
        return 0;
    }
    
    @Override
    public int deleteJobTask(IJobTask jobTask){
        return 0;
    }
    
    @Override
    public List<IJobTask> getJobTasks(int jobId){
        return jobTaskRepo.retrieveJobTasks(jobId);
    }
    
    @Override
    public IJobTask getJobTask(int teamId, int taskId){
        return null;
    }

    @Override
    public IJobTask getJobTaskTotals(int taskId, int teamId) {
       return jobTaskRepo.getJobTaskTotals(taskId, teamId);
    }
}
