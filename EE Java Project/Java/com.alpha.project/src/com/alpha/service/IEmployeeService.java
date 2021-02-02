/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.service;

import com.alpha.models.IEmployee;
import com.alpha.models.IGetEmployeeDetailDto;
import java.util.List;

/**
 *
 * @author Mike
 */
public interface IEmployeeService {

    int insertEmployee(IGetEmployeeDetailDto employee);

    int updateEmployee(IGetEmployeeDetailDto employee);

    int deleteEmployee(int id);
    
    List<IEmployee> searchforEmployee(String search);

    List<IEmployee> retrieveEmployees();

    IGetEmployeeDetailDto retrieveEmployee(int id);
}
