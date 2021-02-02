/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.service;

import com.alpha.models.IGetEmployeeDetailDto;
import com.alpha.models.IJobTask;
import com.alpha.models.ITask;
import com.alpha.repo.TaskRepository;
import java.util.List;
import java.util.stream.Collectors;

/**
 *
 * @author Nik
 */
public class TaskService implements ITaskService {

    public TaskRepository taskRepository = new TaskRepository();
    public JobTaskService jobTaskService = new JobTaskService();
    public TeamService teamService = new TeamService();

    @Override
    public ITask createTask(ITask task) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public int saveTask(ITask task) {
        return (int) taskRepository.insertTask(task);
    }

    @Override
    public int deleteTask(int id) {
        //Check if not job tasks assigned to it
        //List<IJobTask> jobTasks = jobTaskService.getJobTasks().stream().filter(t -> t.getTaskId() == id).collect(Collectors.toList());
        
        //Check for employees skills
        
//        if(jobTasks.isEmpty()){
//            return (int) taskRepository.deleteTask(id);
//        }else{
//            return 0;
//        }
        return 0;

    }

    @Override
    public ITask getTask(int id) {
        return taskRepository.retrieveTask(id);
    }

    @Override
    public List<ITask> getTasks() {
        return taskRepository.retrieveTasks();
    }

    @Override
    public int updateTask(ITask task) {
        return taskRepository.updateTask(task);
    }

}
