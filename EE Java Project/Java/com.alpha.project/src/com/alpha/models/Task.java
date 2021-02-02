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
public class Task extends Base implements  ITask{
    //<editor-fold defaultstate="collapsed" desc="Properties">
    private int id;
    private String name;
    private String description;
    private int duration;
    private Date createdAt;
    private Date updatedAt;
    private boolean isDeleted = false;
    
    @Override
    public int getId() {
        return this.id;
    }
    
    @Override
    public void setId(int id) {
        this.id = id;
    }
    
    @Override
    public String getName() {
        return this.name;
    }
    
    @Override
    public void setName(String name) {
        this.name = name;
    }
    
    @Override
    public String getDescription() {
        return this.description;
    }
    
    @Override
    public void setDescription(String desc) {
        this.description = desc;
    }
    
    @Override
    public int getDuration() {
        return this.duration;
    }
    
    @Override
    public void setDuration(int duration) {
        this.duration = duration;
    }
    
    @Override
    public Date getCreatedAt() {
        return this.createdAt;
    }
    
    @Override
    public void setCreatedAt(Date createdAt) {
        this.createdAt = createdAt;
    }
    
    @Override
    public Date getUpdatedAt() {
        return this.updatedAt;
    }
    
    @Override
    public void setUpdatedAt(Date updatedAt) {
        this.updatedAt = updatedAt;
    }
    
    @Override
    public boolean getIsDeleted() {
        return this.isDeleted;
    }
    
    @Override
    public void setIsDeleted(boolean isDeleted) {
        this.isDeleted = isDeleted;
    }
//</editor-fold>
    
    public Task(){
        
    }
    
    public Task(String name, String description, int duration){
        this.name = name;
        this.description = description;
        this.duration = duration;
    }
    
    public Task(String name, String description, int duration, int id){
        this.name = name;
        this.description = description;
        this.duration = duration;
        this.id = id;
    }
    
    
    @Override
    public ArrayList<IError> getErrors(){
        return super.getErrors();
    }
    
    @Override
    public void addError(IError error){
        super.addError(error);
    }
    
}
