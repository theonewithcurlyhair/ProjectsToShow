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
import com.alpha.models.IJobTask;
import com.alpha.models.JobTask;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.sql.rowset.CachedRowSet;

/**
 *
 * @author Nik
 */
public class JobTaskRepository implements IJobTaskRepository {
    private DAL dal = new DAL();
    
    @Override
    public IJobTask insertJobTask(IJobTask jobTask){
        List<IParameter> parms = new ArrayList<IParameter>();
        parms.add(Parameter.createInstance(jobTask.getTaskId()));
        parms.add(Parameter.createInstance(jobTask.getJobId()));
        parms.add(Parameter.createInstance(jobTask.getOperatingCost()));
        parms.add(Parameter.createInstance(jobTask.getOperatingRevenue()));
        
        return (int) dal.executeNonQuery("{call sp_InsertJobTask(?,?,?,?)}", parms).get(0) != 0 ? jobTask : null;
    }
    
    @Override
    public int updateJobTask(IJobTask jobTask){
        return 0;
    }
    
    @Override
    public int deleteJobTask(IJobTask jobTask){
        return 0;
    }
    
    @Override
    public List<IJobTask> retrieveJobTasks(int jobId) {
        List<IJobTask> jobTasks = new ArrayList();
        try {
            List<IParameter> parms = new ArrayList();
            parms.add(ParameterFactory.createInstance(jobId));
            CachedRowSet rowSet = dal.executeFill("{call sp_GetJobTasks(?)}", parms);
            while(rowSet.next()){
                IJobTask jobTask = new JobTask();
                jobTask.setJobId(rowSet.getInt("JobId"));
                jobTask.setTaskId(rowSet.getInt("TaskId"));
                jobTask.setOperatingCost(rowSet.getDouble("OperatingCost"));
                jobTask.setOperatingRevenue(rowSet.getDouble("OperatingRevenue"));
                jobTasks.add(jobTask);
            }
        } catch (SQLException ex) {
            Logger.getLogger(TaskRepository.class.getName()).log(Level.SEVERE, null, ex);
        }
        return jobTasks;
    }
    
    @Override
    public IJobTask retrieveJobTask(int teamId, int taskId){
        return null;
    }

    @Override
    public IJobTask getJobTaskTotals(int taskId, int teamId) {
        IJobTask jobTask = null;
        try {
            List<IParameter> parms = new ArrayList();
            parms.add(Parameter.createInstance(taskId));
            parms.add(Parameter.createInstance(teamId));
            
            CachedRowSet rowSet = dal.executeFill("{call sp_CalculateTotals(?,?)}", parms);
            while(rowSet.next()){
                jobTask = JobTaskFactory.createInstance(taskId,0,rowSet.getDouble("JobTaskCost"), rowSet.getDouble("JobTaskRevenue"));
            }
        } catch (SQLException ex) {
            Logger.getLogger(TaskRepository.class.getName()).log(Level.SEVERE, null, ex);
        }
        return jobTask;
    }
}
