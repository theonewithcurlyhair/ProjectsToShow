/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.repo;

import com.alpha.dataaccess.DAL;
import com.alpha.dataaccess.IParameter;
import com.alpha.dataaccess.Parameter;
import com.alpha.models.IJob;
import com.alpha.models.Job;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.sql.rowset.CachedRowSet;
import org.joda.time.DateTime;

/**
 *
 * @author Nik
 */
public class JobRepository implements IJobRepository{
    private DAL dal = new DAL();
    
    @Override
    public IJob insertJob(IJob job) {
        List<IParameter> parms = new ArrayList<IParameter>();
        //Create output p
        IParameter idOut = Parameter.createInstance();
        idOut.setDirection(IParameter.Direction.OUT);
        idOut.setSQLType(0);
        idOut.setValue("idOut");
        parms.add(idOut);
        
        parms.add(Parameter.createInstance(job.getTeamId()));
        parms.add(Parameter.createInstance(job.getDescription()));
        parms.add(Parameter.createInstance(job.getClientName()));
        parms.add(Parameter.createInstance(job.getStart().toDate()));
        parms.add(Parameter.createInstance(job.getEnd().toDate()));
        
        
        
        job.setId((int) dal.executeNonQuery("{call sp_InsertJob(?,?,?,?,?,?)}", parms).get(0));
        
        return job;
    }

    @Override
    public int updateJob(IJob job) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public int deleteJob(int id) {
        List<IParameter> parms = new ArrayList();
        parms.add(Parameter.createInstance(id));
        int result = (int) dal.executeScalar("{call sp_DeleteJob(?)}", parms);
        return result;
    }

    @Override
    public List<IJob> retrieveJobs() {
        try {
            CachedRowSet rowSet = dal.executeFill("select * from Jobs", null);
            List<IJob> jobsList = new ArrayList();
            while(rowSet.next()){
                IJob job = new Job();
                job.setTeamId(rowSet.getInt("TeamId"));
                job.setDescription(rowSet.getString("Description"));
                job.setId(rowSet.getInt("Id"));
                job.setClientName(rowSet.getString("ClientName"));
                job.setStart(new DateTime(rowSet.getDate("Start")));
                job.setEnd(new DateTime(rowSet.getDate("End")));
                jobsList.add(job);
            }
            
            return jobsList;
        } catch (SQLException ex) {
            Logger.getLogger(TaskRepository.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    @Override
    public IJob retrieveJob(int id) {
        try {
            List<IParameter> parms = new ArrayList();
            parms.add(Parameter.createInstance(id));
            CachedRowSet rowSet = dal.executeFill("{call sp_GetJobDetails(?)}", parms);
            IJob job = new Job();
            while(rowSet.next()){
                job.setTeamId(rowSet.getInt("TeamId"));
                job.setDescription(rowSet.getString("Description"));
                job.setId(rowSet.getInt("Id"));
                job.setClientName(rowSet.getString("ClientName"));
                job.setStart(new DateTime(rowSet.getDate("Start")));
                job.setEnd(new DateTime(rowSet.getDate("End")));
            }
            
            return job;
        } catch (SQLException ex) {
            Logger.getLogger(TaskRepository.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }
    
}
