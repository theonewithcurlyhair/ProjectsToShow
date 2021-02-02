/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.service;

import com.alpha.models.ITask;
import java.util.List;

/**
 *
 * @author Nik
 */
public interface ITaskService {
    ITask createTask(ITask task);
    int saveTask(ITask task);
    int updateTask(ITask task);
    int deleteTask(int id);
    
    ITask getTask(int id);
    List<ITask> getTasks();
}
