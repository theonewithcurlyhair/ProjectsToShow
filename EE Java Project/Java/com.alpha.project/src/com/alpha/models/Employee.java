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
 * @author Mike
 */
public class Employee extends Base implements IEmployee {
//<editor-fold defaultstate="collapsed" desc="Properties">

    private int id;
    private String firstName;
    private String lastName;
    private String sin;
    private Double hourlyRate;
    private Date createdAt;
    private Date updatedAt;
    private Date deletedAt;
    private boolean isDeleted = false;
    private boolean hasTeam = false;

    @Override
    public int getId() {
        return id;
    }

    @Override
    public void setId(int id) {
        this.id = id;
    }

    @Override
    public String getFirstName() {
        return firstName;
    }

    @Override
    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    @Override
    public String getLastName() {
        return lastName;
    }

    @Override
    public String getName() {
        return firstName + " " + lastName;
    }

    @Override
    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    @Override
    public String getSin() {
        return sin;
    }

    @Override
    public void setSin(String sin) {
        this.sin = sin;
    }

    @Override
    public Double getHourlyRate() {
        return hourlyRate;
    }

    @Override
    public void setHourlyRate(Double hourlyRate) {
        this.hourlyRate = hourlyRate;
    }

    @Override
    public Date getCreatedAt() {
        return createdAt;
    }

    @Override
    public void setCreatedAt(Date createdAt) {
        this.createdAt = createdAt;
    }

    @Override
    public Date getUpdatedAt() {
        return updatedAt;
    }

    @Override
    public void setUpdatedAt(Date updatedAt) {
        this.updatedAt = updatedAt;
    }

    @Override
    public Date getDeletedAt() {
        return deletedAt;
    }

    @Override
    public void setDeletedAt(Date deletedAt) {
        this.deletedAt = deletedAt;
    }

    @Override
    public boolean getIsDeleted() {
        return isDeleted;
    }

    @Override
    public void setIsDeleted(boolean isDeleted) {
        this.isDeleted = isDeleted;
    }

    @Override
    public boolean getHasTeam() {
        return hasTeam;
    }

    @Override
    public void setHasTeam(boolean hasTeam) {
        this.hasTeam = hasTeam;
    }
    //</editor-fold>

    public Employee() {

    }
    public Employee(int id){
        this.id = id;
    }
    public Employee(String firstName, String lastName, String sin, Double hourlyRate) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.sin = sin;
        this.hourlyRate = hourlyRate;
    }

    @Override
    public ArrayList<IError> getErrors() {
        return super.getErrors();
    }

    @Override
    public void addError(IError error) {
        super.addError(error);
    }
}
