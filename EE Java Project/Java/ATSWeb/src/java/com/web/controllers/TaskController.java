/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.web.controllers;

import com.alpha.models.ITask;
import com.alpha.models.Task;
import com.alpha.service.TaskService;
import com.web.models.ErrorViewModel;
import com.web.models.TaskViewModel;
import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author Nik
 */
public class TaskController extends CommonController {

    private static final String TASKS_VIEW = "/tasks.jsp";
    private static final String TASKS_MAINT_VIEW = "/task.jsp";
    private static final String TASK_SUMMARY_VIEW = "/tasksummary.jsp";
    
    //Task service instance
    private TaskService taskService = new TaskService();

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        String pathInfo = request.getPathInfo(); //gets the url
        Task task = new Task();
        TaskViewModel vm = new TaskViewModel();
        if (pathInfo != null) {
            String[] pathParts = pathInfo.split("/");
            int id = super.getInteger(pathParts[1]);
            
            if (id != 0) {
                //Get the task in a variable
                Task queriedTask = (Task) taskService.getTask(id);
                if(queriedTask != null){
                    vm.setTask(queriedTask);
                    request.setAttribute("vm", vm);
                }else{
                    //No Task found
                    request.setAttribute("error", new ErrorViewModel("Task ID: " + id + " not found"));
                }
            } else {
                //No ID in query string after creating task
                request.setAttribute("vm", vm);
            }
            super.setView(request, TASKS_MAINT_VIEW);
        } else {
            //Coming from /tasks, no id is selected so retrieving all tasks from the db and setting them to request vm
            request.setAttribute("vm", taskService.getTasks());
            
            super.setView(request, TASKS_VIEW);
        }

        super.getView().forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        
        //super.setView(request, TASK_SUMMARY_VIEW);
        super.setView(request, TASKS_MAINT_VIEW);
        
        try {
            String action = super.getValue(request, "action");
            int id = super.getInteger(request, "hdnTaskId");
            
            //Declare Task variable
            Task t = new Task();
            switch (action.toLowerCase()) {
                case "create":
                    loadTaskProperties(request, t);
                    request.setAttribute("createdTask",taskService.saveTask(t));
                    break;
                case "update":
                    t.setId(super.getInteger(request, "hdnTaskId"));
                    t.setDescription(super.getValue(request, "taskDesc"));
                    t.setDuration(super.getInteger(request, "taskDuration"));
                    t.setName(super.getValue(request, "taskName"));

                    int isUpdated = taskService.updateTask(t);

                    if (isUpdated > 0) {
                        response.sendRedirect("/ATSWeb/tasks");
                        return;
                    }
                    break;
                case "delete":
                    if(taskService.deleteTask(id) == 0){
                        request.setAttribute("error", new ErrorViewModel("Task was previously assigned and cannot be deleted"));
                    };
                    response.sendRedirect("/ATSWeb/tasks");
                    break;
            }
        } catch (Exception e) {
            super.setView(request, TASKS_MAINT_VIEW);
            request.setAttribute("error", new ErrorViewModel("An error occurred attempting to maintain tasks"));
        }

        super.getView().forward(request, response);
    }
    
    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

    /**
     * common method to load book properties
     *
     * @param request
     * @param b
     */
    private void loadTaskProperties(HttpServletRequest request, Task t) {
        String name = super.getValue(request, "taskName");
        String desc = super.getValue(request, "taskDesc");
        int duration = super.getInteger(request, "taskDuration");

        t.setName(name);
        t.setDescription(desc);
        t.setDuration(duration);
    }
}
