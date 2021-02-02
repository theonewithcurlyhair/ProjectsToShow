/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

import java.util.Date;

/**
 *
 * @author Nik
 */
public interface ITask extends IBase {
    int getId();
    
    void setId(int id);
    
    String getName();
    
    void setName(String name);
    
    String getDescription();
    
    void setDescription(String desc);
    
    int getDuration();
    
    void setDuration(int duration);
    
    Date getCreatedAt();
    
    void setCreatedAt(Date createdAt);
    
    Date getUpdatedAt();
    
    void setUpdatedAt(Date updatedAt);
    
    boolean getIsDeleted();
    
    void setIsDeleted(boolean isDeleted);
}
