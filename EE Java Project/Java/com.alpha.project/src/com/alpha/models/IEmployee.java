/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

import java.util.Date;

/**
 *
 * @author Mike
 */
public interface IEmployee extends IBase {

    int getId();

    void setId(int id);

    String getFirstName();

    void setFirstName(String firstName);

    String getLastName();

    void setLastName(String lastName);

    String getSin();

    void setSin(String Sin);

    Double getHourlyRate();

    void setHourlyRate(Double hourlyRate);

    Date getCreatedAt();

    void setCreatedAt(Date createdAt);

    Date getUpdatedAt();

    void setUpdatedAt(Date updatedAt);

    Date getDeletedAt();

    void setDeletedAt(Date createdAt);

    boolean getIsDeleted();

    void setIsDeleted(boolean isDeleted);

    boolean getHasTeam();

    void setHasTeam(boolean isDeleted);

    String getName();

}
