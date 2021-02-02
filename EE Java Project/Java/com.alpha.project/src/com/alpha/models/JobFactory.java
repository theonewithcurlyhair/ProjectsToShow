/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.models;

import java.util.Date;
import org.joda.time.DateTime;

/**
 *
 * @author Nik
 */
public class JobFactory {
    public static IJob createInstance(){
        return new Job();
    }
    
    public static IJob createInstance(int id, int teamId, String description, String clientName, DateTime start, DateTime end){
        return new Job(id, teamId, description, clientName, start, end);
    }
}
