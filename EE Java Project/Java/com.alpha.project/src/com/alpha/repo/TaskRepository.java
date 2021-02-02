/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.repo;

import com.alpha.dataaccess.DAL;
import com.alpha.dataaccess.IParameter;
import com.alpha.dataaccess.Parameter;
import com.alpha.dataaccess.ParameterFactory;
import com.alpha.models.ITask;
import com.alpha.models.TaskFactory;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.sql.rowset.CachedRowSet;

/**
 *
 * @author Nik
 */
public class TaskRepository implements ITaskRepository {

    private DAL dal = new DAL();

    @Override
    public int insertTask(ITask task) {
        //Populate parms list
        List<IParameter> parms = new ArrayList<IParameter>();
        parms.add(Parameter.createInstance(task.getName()));
        parms.add(Parameter.createInstance(task.getDescription()));
        parms.add(Parameter.createInstance(task.getDuration()));

        //Create output p
        IParameter idOut = Parameter.createInstance();
        idOut.setDirection(IParameter.Direction.OUT);
        idOut.setSQLType(0);
        idOut.setValue("idOut");
        parms.add(idOut);

        //Execute procedure createTask with OUT Parameter for the last inserted task
        return (int) dal.executeNonQuery("{call createTask(?,?,?,?)}", parms).get(0);
    }

    @Override
    public int updateTask(ITask task) {

        int returnId = 0;

        List<Object> returnValues;

        // Params list creation
        List<IParameter> params = ParameterFactory.createListInstance();

        params.add(ParameterFactory.createInstance(task.getId()));
        params.add(ParameterFactory.createInstance(task.getName()));
        params.add(ParameterFactory.createInstance(task.getDescription()));
        params.add(ParameterFactory.createInstance(task.getDuration()));

        returnValues = dal.executeNonQuery("{call updateTask(?,?,?,?)}", params);

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
    public int deleteTask(int id) {
        List<IParameter> parms = new ArrayList();
        parms.add(Parameter.createInstance(id));
        int result = (int) dal.executeScalar("{call deleteTask(?)}", parms);
        return result;
    }

    @Override
    public List<ITask> retrieveTasks() {
        try {
            CachedRowSet rowSet = dal.executeFill("{call listTasks()}", null);
            List<ITask> tasksList = new ArrayList<ITask>();
            while(rowSet.next()){
                ITask task = TaskFactory.createInstance();
                task.setName(rowSet.getString("name"));
                task.setDescription(rowSet.getString("description"));
                task.setId(rowSet.getInt("id"));
                task.setDuration(rowSet.getInt("duration"));
                task.setCreatedAt(rowSet.getDate("CreatedAt"));
                task.setIsDeleted(rowSet.getBoolean("IsDeleted"));
                task.setUpdatedAt(rowSet.getDate("UpdatedAt"));
                
                tasksList.add(task);
            }
            
            return tasksList;
        } catch (SQLException ex) {
            Logger.getLogger(TaskRepository.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    @Override
    public ITask retrieveTask(int id) {
        ITask task = null;
        try {
            List<IParameter> parms = new ArrayList();
            parms.add(Parameter.createInstance(id));
            
            CachedRowSet rowSet = dal.executeFill("{call showTask(?)}", parms);
            while(rowSet.next()){
                task = TaskFactory.createInstance(rowSet.getString("name"), rowSet.getString("description"), rowSet.getInt("duration"), rowSet.getInt("id"));
            }
        } catch (SQLException ex) {
            Logger.getLogger(TaskRepository.class.getName()).log(Level.SEVERE, null, ex);
        }
        return task;
    }

    @Override
    public List<ITask> retreiveEmpTasks(int empId) {
        try {
            List<IParameter> parms = new ArrayList();
            parms.add(Parameter.createInstance(empId));
            CachedRowSet rowSet = dal.executeFill("{call sp_GetEmployeeTasks(?)}", parms);
            List<ITask> tasksList = new ArrayList();
            while(rowSet.next()){
                ITask task = TaskFactory.createInstance();
                task.setId(rowSet.getInt("TaskId"));
                
                tasksList.add(task);
            }
            
            return tasksList;
        } catch (SQLException ex) {
            Logger.getLogger(TaskRepository.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

}
