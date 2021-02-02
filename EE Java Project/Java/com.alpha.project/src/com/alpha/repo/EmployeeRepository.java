/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.repo;

import com.alpha.dataaccess.DAL;
import com.alpha.dataaccess.DALFactory;
import com.alpha.dataaccess.IDAL;
import com.alpha.dataaccess.IParameter;
import com.alpha.dataaccess.Parameter;
import com.alpha.dataaccess.ParameterFactory;
import com.alpha.models.EmployeeFactory;
import com.alpha.models.GetEmployeeDetailDtoFactory;
import com.alpha.models.IEmployee;
import com.alpha.models.IGetEmployeeDetailDto;
import com.alpha.models.ITask;
import com.alpha.models.ITeam;
import com.alpha.models.TaskFactory;
import com.alpha.models.TeamFactory;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.sql.rowset.CachedRowSet;

/**
 *
 * @author Mike
 */
public class EmployeeRepository extends EmployeeRepositoryFactory implements IEmployeeRepository {

    private IDAL dataAccess;

    public EmployeeRepository() {
        dataAccess = DALFactory.createInstance();
    }

    private final String SPROC_SELECT_EMPLOYEES = "CALL getEmployees(null)";
    private final String SPROC_SEARCH_EMPLOYEES = "CALL searchEmployees(?)";
    private final String SPROC_SELECT_EMPLOYEE = "CALL getEmployee(?)";
    private final String SPROC_INSERT_EMPLOYEE = "CALL createEmployee(?,?,?,?,?,?)";
    private final String SPROC_UPDATE_EMPLOYEE = "CALL updateEmployee(?,?,?,?,?)";
    private final String SPROC_DELETE_EMPLOYEE = "CALL deleteEmployee(?)";
    private final String SPROC_EMPLOYEE_SKILLS = "CALL getEmployeeSkills(?)";
    private final String SPROC_CREATE_EMPLOYEE_SKILLS = "CALL createEmployeeSkills(?,?)";
    private final String SPROC_DELETE_EMPLOYEE_SKILLS = "CALL deleteTasksOfEmployee(?)";

    @Override
    public int insertEmployee(IGetEmployeeDetailDto employee) {

        int returnId = 0;

        List<Object> returnValues;
        List<List<Object>> returnValuesSkills = new ArrayList<>();

        // Params list creation
        List<IParameter> params = ParameterFactory.createListInstance();

        params.add(ParameterFactory.createInstance(employee.getEmployee().getFirstName()));
        params.add(ParameterFactory.createInstance(employee.getEmployee().getLastName()));
        params.add(ParameterFactory.createInstance(employee.getEmployee().getSin()));
        params.add(ParameterFactory.createInstance(employee.getEmployee().getHourlyRate()));

        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy/MM/dd HH:mm:ss");
        LocalDateTime now = LocalDateTime.now();

        params.add(ParameterFactory.createInstance(dtf.format(now)));

        params.add(ParameterFactory.createInstance(returnId, IParameter.Direction.OUT, java.sql.Types.INTEGER));

        returnValues = dataAccess.executeNonQuery(SPROC_INSERT_EMPLOYEE, params);

        // INSERT EMPLOYEE SKILLS TO AGREGATION TABLE
        if (employee.getEmployeeSkills() != null) {
            for (ITask employeeSkill : employee.getEmployeeSkills()) {
                params = ParameterFactory.createListInstance();
                params.add(ParameterFactory.createInstance(employeeSkill.getId()));

                int empID = (int) returnValues.get(0);

                params.add(ParameterFactory.createInstance(empID));
                returnValuesSkills.add(dataAccess.executeNonQuery(SPROC_CREATE_EMPLOYEE_SKILLS, params));
            }
        }

        try {
            if (returnValues != null && returnValuesSkills != null) {
                returnId = Integer.parseInt(returnValues.get(0).toString());
            }
        } catch (Exception e) {
            System.out.print(e.getMessage());
        }

        return returnId;
    }

    @Override
    public int updateEmployee(IGetEmployeeDetailDto employee) {

        int returnId = 0;

        List<Object> returnValues;
        List<Object> returnValuesOfDelete;
        List<List<Object>> returnValuesSkills = new ArrayList<>();

        // Params list creation
        List<IParameter> params = ParameterFactory.createListInstance();

        params.add(ParameterFactory.createInstance(employee.getEmployee().getFirstName()));
        params.add(ParameterFactory.createInstance(employee.getEmployee().getLastName()));
        params.add(ParameterFactory.createInstance(employee.getEmployee().getSin()));
        params.add(ParameterFactory.createInstance(employee.getEmployee().getHourlyRate()));
        params.add(ParameterFactory.createInstance(employee.getEmployee().getId()));

        returnValues = dataAccess.executeNonQuery(SPROC_UPDATE_EMPLOYEE, params);

        // We need to delete all existing tasks from the agregation table to readd them after
        params = ParameterFactory.createListInstance();
        params.add(ParameterFactory.createInstance(employee.getEmployee().getId()));
        returnValuesOfDelete = dataAccess.executeNonQuery(SPROC_DELETE_EMPLOYEE_SKILLS, params);

        if (employee.getEmployeeSkills() != null) {
            for (ITask employeeSkill : employee.getEmployeeSkills()) {
                params = ParameterFactory.createListInstance();
                params.add(ParameterFactory.createInstance(employeeSkill.getId()));
                params.add(ParameterFactory.createInstance(employee.getEmployee().getId()));
                returnValuesSkills.add(dataAccess.executeNonQuery(SPROC_CREATE_EMPLOYEE_SKILLS, params));
            }
        }

        try {
            if (returnValues != null) {
                returnId = Integer.parseInt(returnValues.get(0).toString());
            }
        } catch (Exception e) {
            System.out.print(e.getMessage());
        }

        return returnId;
    }

    @Override
    public int deleteEmployee(int id) {
        int returnId = 0;

        List<Object> returnValues;
        List<Object> returnValuesDeleteSkills;

        // Params list creation
        List<IParameter> params = ParameterFactory.createListInstance();

        params.add(ParameterFactory.createInstance(id));

        returnValues = dataAccess.executeNonQuery(SPROC_DELETE_EMPLOYEE, params);

        try {
            if (returnValues != null) {
                returnId = Integer.parseInt(returnValues.get(0).toString());
            }
        } catch (Exception e) {
            System.out.print(e.getMessage());
        }

        return returnId;
    }

    @Override
    public List<IEmployee> retrieveEmployees() {

        
        try {
            CachedRowSet rowSet = dataAccess.executeFill(SPROC_SELECT_EMPLOYEES, null);
            List<IEmployee> returnValues = EmployeeFactory.createListInstance();

            while (rowSet.next()) {
                IEmployee retrievedEmployee = EmployeeFactory.createInstance();

                int teamId = super.getInt("TeamId", rowSet);
                
                retrievedEmployee.setId(super.getInt("Id", rowSet));
                retrievedEmployee.setFirstName(rowSet.getString("FirstName"));
                retrievedEmployee.setLastName(rowSet.getString("LastName"));
                retrievedEmployee.setDeletedAt(super.getDate("DeletedAt", rowSet));

                if (retrievedEmployee.getDeletedAt() != null) {
                    retrievedEmployee.setIsDeleted(true);
                }
                
                if(teamId != 0){
                    retrievedEmployee.setHasTeam(true);
                }

                returnValues.add(retrievedEmployee);
            }

            return returnValues;
        } catch (SQLException ex) {
            Logger.getLogger(TaskRepository.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    @Override
    public IGetEmployeeDetailDto retrieveEmployee(int id) {
        List<IParameter> parms = new ArrayList<>();
        parms.add(Parameter.createInstance(id));
        IGetEmployeeDetailDto retrievedEmployeeData = GetEmployeeDetailDtoFactory.createInstance();

        // heer we will store ALL skills from our DB 
        List<ITask> allSkills = new ArrayList<>();

        IEmployee retrievedEmployee = null;
        ITask skill = null;
        ITeam team = null;

        try {
            CachedRowSet rowSet = dataAccess.executeFill(SPROC_SELECT_EMPLOYEE, parms);

            // HERE WE RETRIEVE BASIC INFO ABOUT EMPLOYEE WITH A CERTAIN ID
            while (rowSet.next()) {
                retrievedEmployee = EmployeeFactory.createInstance(
                        rowSet.getString("FirstName"),
                        rowSet.getString("LastName"),
                        rowSet.getString("SIN"),
                        super.getDouble("HourlyRate", rowSet)
                );

                retrievedEmployee.setId(super.getInt("EmployeeId", rowSet));
                retrievedEmployee.setCreatedAt(super.getDate("CreatedAt", rowSet));
                retrievedEmployee.setUpdatedAt(super.getDate("UpdatedAt", rowSet));

                team = TeamFactory.createInstance();

                // to check what do we get in the dataset
                ResultSetMetaData rsmd = rowSet.getMetaData();
                int columnsNumber = rsmd.getColumnCount();
//                Map<String, String> map = new HashMap<String, String>();
//                for (int i = 1; i <= columnsNumber; i++) {
//                    String columnValue = rowSet.getString(i);
//                    map.put(rsmd.getColumnName(i), columnValue);
//                    map.put(rsmd.getColumnLabel(i), columnValue);
//                }

                // GETTING TEAM WHERE HE WAS ASSIGNED TO
//                team.setId(super.getInt("TeamsId", rowSet));
//                
//                int teamNamePosition = super.getByColumnLabel("TeamName", rowSet);
//                team.setName(rowSet.getString(teamNamePosition));
                
                retrievedEmployeeData.setEmployee(retrievedEmployee);
                retrievedEmployeeData.setEmployeeTeam(team);
            }

            // HERE WE RETRIEVE SKILLS THAT EMPLOYEE ALREADY POSESS 
            rowSet = dataAccess.executeFill(SPROC_EMPLOYEE_SKILLS, parms);
            while (rowSet.next()) {
                skill = TaskFactory.createInstance();
                skill.setId(super.getInt("Id", rowSet));
                skill.setName(rowSet.getString("Name"));

//                ResultSetMetaData rsmd = rowSet.getMetaData();
//                int columnsNumber = rsmd.getColumnCount();
//                Map<String, String> map = new HashMap<String, String>();
//                for (int i = 1; i <= columnsNumber; i++) {
//                    String columnValue = rowSet.getString(i);
//                    map.put(rsmd.getColumnName(i), columnValue);
//                }
                allSkills.add(skill);
            }

            retrievedEmployeeData.setEmployeeSkills(allSkills);

        } catch (Exception e) {
            System.out.print(e.getMessage());
        }

        return retrievedEmployeeData;

    }

    @Override
    public List<IEmployee> searchforEmployee(String search) {

        try {
            List<IParameter> parms = new ArrayList<>();
            parms.add(Parameter.createInstance(search));
            CachedRowSet rowSet = null;
            if (!search.equalsIgnoreCase("")) {
                rowSet = dataAccess.executeFill(SPROC_SEARCH_EMPLOYEES, parms);
            } else {
                rowSet = dataAccess.executeFill(SPROC_SELECT_EMPLOYEES, null);
            }
            List<IEmployee> returnValues = EmployeeFactory.createListInstance();

            while (rowSet.next()) {
                IEmployee retrievedEmployee = EmployeeFactory.createInstance();

                retrievedEmployee.setId(super.getInt("Id", rowSet));
                retrievedEmployee.setFirstName(rowSet.getString("FirstName"));
                retrievedEmployee.setLastName(rowSet.getString("LastName"));
//                retrievedEmployee.setCreatedAt(super.getDate("CreatedAt", rowSet));
//                retrievedEmployee.setUpdatedAt(super.getDate("UpdatedAt", rowSet));
                retrievedEmployee.setDeletedAt(super.getDate("DeletedAt", rowSet));

                if (retrievedEmployee.getDeletedAt() != null) {
                    retrievedEmployee.setIsDeleted(true);
                } else {
                    returnValues.add(retrievedEmployee);
                }
            }

            return returnValues;
        } catch (SQLException ex) {
            Logger.getLogger(TaskRepository.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }
}
