/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.repo;

import com.alpha.models.IEmployee;
import com.alpha.models.IGetEmployeeDetailDto;
import com.alpha.models.ITask;
import java.util.List;

/**
 *
 * @author Mike
 */
public interface IEmployeeRepository{

    int insertEmployee(IGetEmployeeDetailDto employee);

    int updateEmployee(IGetEmployeeDetailDto employee);

    int deleteEmployee(int id);

    List<IEmployee> retrieveEmployees();
    
    List<IEmployee> searchforEmployee(String search);

    IGetEmployeeDetailDto retrieveEmployee(int id);
}
