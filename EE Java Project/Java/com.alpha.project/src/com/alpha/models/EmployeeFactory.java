/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

import java.util.ArrayList;

/**
 *
 * @author Mike
 */
public abstract class EmployeeFactory {

    public static IEmployee createInstance() {
        return new Employee();
    }

    public static IEmployee createInstance(String firstname, String lastname, String sin, double hourltrate) {
        return new Employee(firstname, lastname, sin, hourltrate);
    }

    public static ArrayList<IEmployee> createListInstance() {
        return new ArrayList<>();
    }
    
    public static IEmployee createInstance(int employeeId){
        return new Employee(employeeId);
    }
}
