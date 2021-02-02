/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.web.models;

import com.alpha.models.IJobTask;
import com.alpha.models.ITask;
import com.alpha.models.JobTask;
import com.alpha.models.Task;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Nik
 */
public class JobTaskViewModel{
    private IJobTask task = new JobTask();
    
    public JobTaskViewModel(){}
    
    public IJobTask getTask(){
        return task;
    }
    
    public void setTask(IJobTask task){
        this.task = task;
    }
    
    private List<IJobTask> tasks = new ArrayList();
    
    public List<IJobTask> getTasks() {
        return this.tasks;
    }
    
    public void setTasks(List<IJobTask> tasks){
        this.tasks = tasks;
    }
}
