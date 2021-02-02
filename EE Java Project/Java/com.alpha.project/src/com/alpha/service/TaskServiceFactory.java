/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.service;

/**
 *
 * @author Nik
 */
public class TaskServiceFactory {
    public static ITaskService createInstance(){
        return new TaskService();
    }
}
