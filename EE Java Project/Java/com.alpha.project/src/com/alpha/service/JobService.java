/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.service;

import com.alpha.models.IJob;
import com.alpha.repo.JobRepository;
import java.util.List;

/**
 *
 * @author Nik
 */
public class JobService implements IJobService {

    private JobRepository jobRepo = new JobRepository();
    
    @Override
    public IJob createJob(IJob job) {
        return jobRepo.insertJob(job);
    }

    @Override
    public int saveJob(IJob job) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public int deleteJob(int id) {
        return jobRepo.deleteJob(id);
    }

    @Override
    public IJob getJob(int id) {
        return jobRepo.retrieveJob(id);
    }

    @Override
    public List<IJob> getJobs() {
        return jobRepo.retrieveJobs();
    }
    
}
