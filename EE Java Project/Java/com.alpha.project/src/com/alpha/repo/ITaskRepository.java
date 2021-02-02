/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.repo;

import com.alpha.models.ITask;
import java.util.List;

/**
 *
 * @author Nik
 */
public interface ITaskRepository {
    int insertTask(ITask task);
    int updateTask(ITask task);
    int deleteTask(int id);
    List<ITask> retrieveTasks();
    ITask retrieveTask(int id);
    List<ITask> retreiveEmpTasks(int empId);
}
