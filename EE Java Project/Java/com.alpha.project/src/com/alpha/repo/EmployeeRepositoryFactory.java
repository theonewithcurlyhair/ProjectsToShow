/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.repo;

/**
 *
 * @author Mike
 */
  public abstract class EmployeeRepositoryFactory extends BaseRepository{
    
    public static IEmployeeRepository createInstance(){
              
        return new EmployeeRepository();
    }
}  
