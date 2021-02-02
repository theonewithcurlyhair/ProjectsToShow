/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.web.models;

import com.alpha.models.ITask;
import com.alpha.models.Task;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

/**
 *
 * @author Nik
 */
public class TaskViewModel {

    private ITask task = new Task();

    public TaskViewModel() {
    }

    public ITask getTask() {
        return task;
    }

    public void setTask(ITask task) {
        this.task = task;
    }

    private List<ITask> tasks = new ArrayList();

    /**
     * @return the tasks
     */
    public List<ITask> getTasks() {
        return tasks;
    }

    /**
     * @param tasks the tasks to set
     */
    public void setTasks(List<ITask> tasks) {
        this.tasks = tasks;
    }

    public void addTaskToList(ITask task) {
        this.tasks.add(task);
    }

    public boolean contains(ITask task) {
        List<ITask> query = tasks.stream().filter(t -> t.getId() == task.getId()).collect(Collectors.toList());

        if (query.size() > 0) {
            return true;
        } else {
            return false;
        }
    }

}
