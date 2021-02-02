/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.service;

import com.alpha.models.IEmployee;
import com.alpha.models.IGetEmployeeDetailDto;
import com.alpha.repo.EmployeeRepositoryFactory;
import com.alpha.repo.IEmployeeRepository;
import java.util.List;

/**
 *
 * @author Mike
 */
public class EmployeeService extends EmployeeServiceFactory implements IEmployeeService {

    private IEmployeeRepository repo;

    public EmployeeService() {
        repo = EmployeeRepositoryFactory.createInstance();
    }

    @Override
    public int insertEmployee(IGetEmployeeDetailDto employee) {
        return repo.insertEmployee(employee);
    }

    @Override
    public int updateEmployee(IGetEmployeeDetailDto employee) {
        return repo.updateEmployee(employee);
    }

    @Override
    public int deleteEmployee(int id) {
        return repo.deleteEmployee(id);
    }

    @Override
    public List<IEmployee> retrieveEmployees() {
        return repo.retrieveEmployees();
    }

    @Override
    public IGetEmployeeDetailDto retrieveEmployee(int id) {
        return repo.retrieveEmployee(id);
    }

    @Override
    public List<IEmployee> searchforEmployee(String search) {
        return repo.searchforEmployee(search);
    }
}
