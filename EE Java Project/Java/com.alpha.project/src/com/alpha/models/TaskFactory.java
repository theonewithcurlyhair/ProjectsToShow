/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

import java.util.ArrayList;
import java.util.Date;
/**
 *
 * @author Nik
 */
public abstract class TaskFactory {
    public static ITask createInstance(){
        return new Task();
    }
    
    public static ITask createInstance(String name, String description, int duration){
        return new Task(name, description, duration);
    }
    
    public static ITask createInstance(String name, String description, int duration, int id){
        return new Task(name, description, duration, id);
    }
    
    public static ArrayList<ITask> createListInstance(){
        return  new ArrayList<>();
    }
}
